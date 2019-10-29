using Ensco.Irma.Data.Mappings;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.IRMA;
using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Models.Domain.Security;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace Ensco.Irma.Data.Context
{
    public class IrmaDbContext : DbContext, IDbContext, IIrmaDbContext
    {
        protected readonly ILog Log = Logging.Log.GetLogger(typeof(IrmaOapDbContext));

        public ConcurrentDictionary<Type, object> DbSets { get; } = new ConcurrentDictionary<Type, object>();
  
        public DbSet<Rig> Rigs { get; set; }

        #region Security
        public DbSet<Person> People { get; set; }


        //public DbSet<Role> Roles { get; set; }

        #endregion
             

        public DbSet<IrmaTask> Tasks { get; set; }
        public DbSet<IrmaReview> Reviews { get; set; }

        public DbSet<IrmaCapa> CAPAs { get; set; }

        #region lookups
        public DbSet<Criticality> Criticalities { get; set; }


        #endregion

        public DbSet<AdminCustom> AdminCustoms { get; set; }

        public DbSet<PobPersonnel> PobPeople { get; set; }

        public DbSet<PobTour> PobTours { get; set; }

        public IrmaDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<IrmaDbContext>(null);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Log.Debug("OnModelCreating()");

            Configuration.LazyLoadingEnabled = true;
            base.OnModelCreating(modelBuilder);
             
            RegisterExistingTypes(modelBuilder);

            if (Model != null)
            {
                throw new InvalidOperationException("Duplicate Model Creation");
            }

            Model = modelBuilder.Build(Database.Connection).Compile();
        }

        private void RegisterExistingTypes(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rig>().ToTable("Master_Rig");
            modelBuilder.Entity<PobTour>().ToTable("Pob_Tour");

            modelBuilder.Configurations.Add(new PersonMap());
            modelBuilder.Configurations.Add(new AdminCustomMap());
            modelBuilder.Configurations.Add(new IrmaTaskMap());
            modelBuilder.Configurations.Add(new PobPersonnelMap());
            modelBuilder.Configurations.Add(new OAPReviewMap());

            modelBuilder.Entity<Criticality>().ToTable("Master_Criticality");

            //modelBuilder.Entity<PersonRole>().ToTable("Master_UserRoles");
        }

        public DbSet RegisterType(Type type)
        {
            var dbset = Set(type);
            DbSets.TryAdd(type, dbset);

            return dbset;
        }

        public object Model { get; set; }
        
        public void SetAuditValues<TE>(TE entity, bool update = true)
        where TE : class, IAudit
        {

            var user = Thread.CurrentPrincipal?.Identity?.Name ?? "none";
            var updatetime = DateTime.UtcNow;

            if (update)
            {
                //TODO: ADD the Logic to get the principle
                entity.UpdatedBy = user;
                entity.UpdatedDateTime = updatetime;
                return;
            }

            SetProperties(entity, "CreatedBy", user);
            SetProperties(entity, "UpdatedBy", user);
            SetProperties(entity, "CreatedDateTime", updatetime);
            SetProperties(entity, "UpdatedDateTime", updatetime);
        }

        public void SetProperties<TE>(TE entity, string propertyName, object value)
             where TE : class, IAudit
        {
            if (entity == null)
            {
                return;
            }

            var properties = from p in entity.GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public)
                             where typeof(IAudit).IsAssignableFrom(p.GetType()) || typeof(ICollection<IAudit>).IsAssignableFrom(p.GetType())
                             select p;

            foreach (var p in properties)
            {
                var propValue = (TE)p.GetValue(entity, null);
                SetProperties(propValue, propertyName, value);
            }
            var property = entity.GetType().GetProperty(propertyName);
            var val = property.GetValue(entity);

            var setProperty = string.IsNullOrEmpty(val?.ToString());

            if (property.PropertyType.Name.Equals("DateTime") && !setProperty)
            {
                if (DateTime.TryParse(val.ToString(), out DateTime t))
                {
                    if (t.Year < 1900)
                    {
                        setProperty = true;
                    }
                }
            }

            if (setProperty)
            {
                property?.SetValue(entity, value);
            }
        }

        public int ExecuteSql(string sql, params object [] sqlparams)
        {
            return this.Database.ExecuteSqlCommand(sql, sqlparams);
        }

         

        public IEnumerable<T> Sql<T>(string sql, params object[] sqlparams)
        {
            return this.Database.SqlQuery<T>(sql, sqlparams).ToList();
        }
    }
}
