using Ensco.Irma.Data.Conventions;
using Ensco.Irma.Data.Mappings;
using Ensco.Irma.Interfaces.Domain;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Models.Domain.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Security;
using Ensco.Irma.Models.Domain.Workflow;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using System.ComponentModel;
using Ensco.Irma.Models.Domain.Attributes;

namespace Ensco.Irma.Data.Context
{
    public class IrmaOapDbContext : DbContext, IDbContext, IIrmaOapDbContext
    {
        protected readonly ILog Log = Logging.Log.GetLogger(typeof(IrmaOapDbContext));

        public ConcurrentDictionary<Type, object> DbSets { get; } = new ConcurrentDictionary<Type, object>();

        #region Workflows
        public DbSet<Workflow> Workflows { get; set; }

        public DbSet<WorkflowActivity> WorkflowActivities { get; set; }

        public DbSet<WorkflowState> WorkflowStates { get; set; }

        public DbSet<WorkflowTransition> WorkflowTransitions { get; set; }


        public DbSet<WorkflowInstanceActivity> WorkflowInstanceActivities { get; set; }
        #endregion

        #region Corp OAP
        public DbSet<OapHierarchy> OapHierarchies { get; set; }

        public DbSet<OapChecklist> OapChecklists { get; set; }

        public DbSet<OapChecklistTopic> OapChecklistTopics { get; set; }

        public DbSet<OapChecklistQuestion> OapChecklistQuestions { get; set; }

        public DbSet<OapGraphic> OapGraphics { get; set; }

        public DbSet<OapProtocolFormType> OapProtocolFormTypes { get; set; }

        public DbSet<OapFrequencyType> OapFrequencyTypes { get; set; }

        public DbSet<OapChecklistGroup> OapChecklistGroups { get; set; }

        public DbSet<OapChecklistSubGroup> OapChecklistSubGroups { get; set; }

        public DbSet<OapChecklistComment> OapChecklistComments { get; set; }

        public DbSet<OapProtocolQuestionHeader> OapProtocolQuestionHeaders { get; set; }

        public DbSet<OapChecklistLayout> OapChecklistLayouts { get; set; }

        public DbSet<OapChecklistLayoutColumn> OapChecklistLayoutColumns { get; set; }

        public DbSet<OapChecklistQuestionTag> OapChecklistQuestionTags { get; set; }

        public DbSet<OapChecklistQuestionTagMap> OapChecklistQuestionTagMaps { get; set; }

        public DbSet<OapCheckListQuestionRelatedQuestionMap> OapCheckListQuestionRelatedQuestionMaps { get; set; }

        public DbSet<OapFrequency> OapFrequencies { get; set; }

        public DbSet<OapChecklistQuestionDataType> OapChecklistQuestionDataTypes { get; set; }

        public DbSet<OapSystem> OapSystems { get; set; }

        public DbSet<OapSystemGroup> OapSystemGroups { get; set; }

        public DbSet<OapSubSystem> OapSubSystems { get; set; }

        public DbSet<OapEquipment> OapEquipments { get; set; }

        public DbSet<OapWorkInstruction> OapWorkInstructions { get; set; }

        public DbSet<OapChecklistEquipment> OapChecklistEquipments { get; set; }

        public DbSet<OapChecklistWorkInstruction> OapChecklistWorkInstructions { get; set; }

        public DbSet<OapAssetDataManagement> OapAssetDataManagements { get; set; }

        public DbSet<OapChecklistReviewer> OapChecklistReviewers { get; set; }

        public DbSet<OapAccountable> OapAccountables { get; set; }

        public DbSet<OapAudit> OapAudits {get;set;}

        public DbSet<OapAuditRight> OapAuditRights { get; set; }

        public DbSet<OapAuditProtocol> OapAuditProtocols { get; set; }

        #endregion

        #region Rig OAP 
        public DbSet<RigOapChecklist> RigOapChecklists { get; set; }

        public DbSet<RigOapChecklistQuestion> RigOapChecklistQuestions { get; set; }

        public DbSet<RigOapChecklistWorkflow> RigOapChecklistWorkflows { get; set; }

        public DbSet<RigOapChecklistQuestionFinding> RigOapChecklistQuestionFindings { get; set; }

        public DbSet<RigOapChecklistAssessor> RigOapChecklistAssessors { get; set; }

        public DbSet<RigOapChecklistVerifier> RigOapChecklistVerifiers { get; set; }

        public DbSet<Models.Domain.Oap.FindingType> FindingTypes { get; set; }

        public DbSet<Models.Domain.Oap.FindingSubType> FindingSubTypes { get; set; }

        public DbSet<RigOapChecklistQuestionComment> RigOapCheckListQuestionComments { get; set; }

        public DbSet<RigOapChecklistQuestionNoAnswerComment> RigOapCheckListQuestionNoAnswerComments { get; set; }        

        public DbSet<RigOapChecklistGroupAsset> RigOapChecklistGroupAssets { get; set ; }

        public DbSet<RigOapChecklistWorkInstruction> RigOapChecklistWorkInstructions { get; set; }

        public DbSet<RigOapChecklistThirdPartyJob> RigOapChecklistThirdPartyJobs { get; set; }

        public DbSet<DPA> DPAs { get; set; }

        #endregion

        public IrmaOapDbContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer<IrmaOapDbContext>(new  CreateDatabaseIfNotExists<IrmaOapDbContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Log.Debug("OnModelCreating()");

            Configuration.LazyLoadingEnabled = true;
            base.OnModelCreating(modelBuilder); 

            modelBuilder.Conventions.Add<OapTablePrefixConvention>();
            var defaultSqlConvention = new AttributeToColumnAnnotationConvention<SqlDefaultValueAttribute, string>("SqlDefaultValue", (p, attributes) => attributes.SingleOrDefault().Value.ToString());
            modelBuilder.Conventions.Add(defaultSqlConvention);

            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Configurations.Add(new RigOapChecklistQuestionMap());
            modelBuilder.Configurations.Add(new DPAMapping());

            if (Model != null)
            {
                throw new InvalidOperationException("Duplicate Model Creation");
            }

            Model = modelBuilder.Build(Database.Connection).Compile();
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

        public int ExecuteSql(string sql, params object[] sqlparams)
        {
            return this.Database.ExecuteSqlCommand(sql, sqlparams);
        }

        public IEnumerable<T> Sql<T>(string sql, params object[] sqlparams)
        {
            return this.Database.SqlQuery<T>(sql, sqlparams).ToList();
        }
    }
}
