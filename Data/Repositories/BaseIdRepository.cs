using Ensco.Irma.Data.Context;
using Ensco.Irma.Interfaces.Data;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Ensco.Irma.Data.Repositories
{
    public abstract class BaseIdRepository<TC, TE, TI> : IBaseIdRepository<TE, TI> 
        where TC: DbContext, IDbContext , IExecuteSql
        where TE: class, IEntityId<TI>
        where TI: struct
    {
        protected virtual IDbSet<TE> Items { get; set; }

        protected virtual IQueryable<TE> AllItems { get; set; }

        protected TC Context { get; set; }

        protected ILog Log { get; set; }

        public BaseIdRepository(TC context, ILog log)
        {
            Context = context;
            Items = Context.Set<TE>() as IDbSet<TE>;
            AllItems = Items;
            Log = log;
        }

        public virtual TE Get(TI id)
        {
            var r = AllItems.FirstOrDefault(i => i.Id.ToString() == (id.ToString()));
             
            return r;
        }

        public virtual TE Get(params object [] ids)
        {
            var r = AllItems.FirstOrDefault(i => ids.Contains(i.Id));

            return r;
        }

        public virtual IEnumerable<TE> GetAll()
        {
            var r = AllItems.ToList();

            return r;
        }

        public virtual TI Add(TE entity)
        {
            var r = Items.Add(entity); 

            //Context.SetAuditValues(entity, false);

            Context.SaveChanges();
            return r.Id;
        }

        public virtual TE Update(TE entity)
        {
            Log.Debug($"Update({entity})");

            var ret = default(TE);

            SaveChanges(entity);

            ret = entity;              
            return ret;
        }

        private int SaveChanges()
        {
            int changes = 0;
            
            foreach (var change in Context.ChangeTracker.Entries()
                        .Where(c => c.Entity is Models.Domain.Entity<TI>
                                && (c.State == EntityState.Modified)))
            {
                changes += Save((TE)change.Entity, change); 
            }

            return changes;
        }

        public virtual int SaveChanges(TE entity)
        {
            int changes = 0;

            var dbEntryEntity = Context.ChangeTracker.Entries().FirstOrDefault(e => e.Entity == entity);
            
            changes = Save(entity, dbEntryEntity); 

            return changes;
        }

        public bool HasChanged(TE entity)
        {
            var dbEntryEntity = Context.ChangeTracker.Entries().FirstOrDefault(e => e.Entity == entity);

            if(dbEntryEntity == null)
            {
                return false;
            }

            return dbEntryEntity.State == EntityState.Added || dbEntryEntity.State == EntityState.Modified || dbEntryEntity.State == EntityState.Deleted;
        }

        protected virtual int Save(TE entity, DbEntityEntry dbEntryEntity)
        {
            int changes = 0;
             
            if (Context.ChangeTracker.HasChanges() && (dbEntryEntity == null) && (dbEntryEntity.State != EntityState.Modified))
            {
                throw new InvalidOperationException($"Attempt to save either a detached or non-modified entity: {entity}.  Must load entity and save.");
            }

            try
            { 
               //Context.SetAuditValues<TE>((TE)dbEntryEntity.Entity); 

               changes = Context.SaveChanges(); 
            }
            catch (DbEntityValidationException exception)
            {
                string validationErrMessage = exception.EntityValidationErrors.Aggregate(new StringBuilder(), (sb, next) => next.ValidationErrors.Aggregate(sb, (s, verr) => s.AppendLine($"\t{verr.PropertyName}: {verr.ErrorMessage}"))).ToString();
                string message = $"Validation error saving '{entity}': {exception.Message}.\r\n{validationErrMessage}";
                Log.Error(message, exception);
                //Uncomment following to dump changes
                foreach (var group in Context.ChangeTracker.Entries()
                                .GroupBy(e => e.State)
                                .OrderBy(g => g.Key))
                {
                    Log.Debug("{group.Key}: {group.ToString(e => e.Entity)}");
                }
                throw new InvalidOperationException(message, exception);
            }
            catch (DbUpdateConcurrencyException exception)
            {
                var innerMsg = exception.Entries.Aggregate(new StringBuilder(), (sb, next) => sb.AppendLine(next.Entity.ToString()));
                string message = $"Concurrency error saving '{entity}'.\r\n{innerMsg}";
                Log.Warn(message, exception);
                //Uncomment following to dump changes
                foreach (var group in Context.ChangeTracker.Entries()
                                .GroupBy(e => e.State)
                                .OrderBy(g => g.Key))
                {
                    Log.Error($"Error while grouping {group.Key}: {group.Aggregate(new StringBuilder(), (sb, next) => sb.AppendLine(next.Entity.ToString()))}", exception);
                }
                throw new InvalidOperationException(message, exception);
            }
            catch (SqlException exception)
            {
                if (exception.Message.StartsWith("Violation of PRIMARY KEY constraint"))
                    throw new InvalidOperationException("Failed to save {0}.  Possible attempt to save entity that doesn't belong to a Hierarchy with an IDbSet<> on the Data Context class", exception);
                throw;
            }
            catch (Exception exception)
            {
                string message = $"General Error saving '{entity}': {exception.Message}.";
                Log.Warn(message, exception);
                //Uncomment following to dump changes
                foreach (var group in Context.ChangeTracker.Entries()
                                .GroupBy(e => e.State)
                                .OrderBy(g => g.Key))
                {
                    Log.Debug("{group.Key}: {group.ToString(e => e.Entity)}");
                }
                throw new InvalidOperationException(message, exception);
            }

            return changes;
        }

        public virtual bool Delete(TI id)
        {
            var v = Get(id);

            if (v == null)
            {
                return false;
            }

            Items.Remove(v);

            var t = Context.SaveChanges();

            return t > 0;
        }

        public virtual bool Delete(TE entity)
        {
            if (entity == null)
            {
                return false;
            }

            Items.Remove(entity);

            var t = Context.SaveChanges();

            return t > 0;
        }

        public virtual bool Delete(IEnumerable<TE> entities)
        {
            if (!entities.Any())
            {
                return false;
            }

            (Items as DbSet<TE>)?.RemoveRange(entities);

            var t = Context.SaveChanges();

            return t > 0; 
        }

        public int ExecuteSql(string sql, params object[] sqlparams)
        {
            return Context.ExecuteSql(sql, sqlparams);
        }

        public IEnumerable<TE> Sql(string sql, params object[] sqlparams)
        {
            return Context.Sql<TE>(sql, sqlparams);
        }

        public int SendEmail(string to, string subject, string body, string cc = "")
        {
            var emailParams = new object[]
           {
                new SqlParameter("@email", to),
                new SqlParameter("@title", subject),
                new SqlParameter("@s", body),
                new SqlParameter("@cc", cc)
           };

            var i = ExecuteSql("usp_sendEmail @email, @title, @s, @cc", emailParams);

            return i;
        }
    }
}
