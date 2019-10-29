using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Oap.Audit;
using Ensco.Irma.Models.Domain.Security;
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Models.Domain.Oap;

using System.Data.Entity;
using Ensco.Irma.Interfaces.Domain;

namespace Ensco.Irma.Data.Context
{
    public interface IIrmaOapDbContext : IDbContext,  IExecuteSql
    {
        #region Workflows
        DbSet<WorkflowActivity> WorkflowActivities { get; set; }

        DbSet<WorkflowInstanceActivity> WorkflowInstanceActivities { get; set; }

        DbSet<Workflow> Workflows { get; set; }

        DbSet<WorkflowState> WorkflowStates { get; set; }

        DbSet<WorkflowTransition> WorkflowTransitions { get; set; }
        #endregion

        #region CORP OAP
        DbSet<OapHierarchy> OapHierarchies { get; set; }

        //DbSet<Models.Domain.Oap.Localization.OapCulture> OapCultures { get; set; }

        //DbSet<Models.Domain.Oap.Localization.OapCultureItem> OapCultureItems { get; set; }

        DbSet<OapChecklist> OapChecklists { get; set; }

        DbSet<OapChecklistTopic> OapChecklistTopics { get; set; }

        DbSet<OapChecklistQuestion> OapChecklistQuestions { get; set; }

        DbSet<OapGraphic> OapGraphics { get; set; }

        DbSet<OapProtocolFormType> OapProtocolFormTypes { get; set; }

        DbSet<OapFrequencyType> OapFrequencyTypes { get; set; }

        DbSet<OapChecklistGroup> OapChecklistGroups { get; set; }

        DbSet<OapChecklistSubGroup> OapChecklistSubGroups { get; set; }

        DbSet<OapChecklistComment> OapChecklistComments { get; set; }

        DbSet<OapProtocolQuestionHeader> OapProtocolQuestionHeaders { get; set; }

        DbSet<OapChecklistLayout> OapChecklistLayouts { get; set; }

        DbSet<OapChecklistLayoutColumn> OapChecklistLayoutColumns { get; set; }

        DbSet<OapChecklistQuestionTag> OapChecklistQuestionTags { get; set; }

        DbSet<OapChecklistQuestionTagMap> OapChecklistQuestionTagMaps { get; set; }
        

        DbSet<OapSystem> OapSystems { get; set; }

        DbSet<OapSystemGroup> OapSystemGroups { get; set; }

        DbSet<OapSubSystem> OapSubSystems { get; set; }
        DbSet<OapEquipment> OapEquipments { get; set; }
        DbSet<OapWorkInstruction> OapWorkInstructions { get; set; }
        DbSet<OapChecklistEquipment> OapChecklistEquipments { get; set; }
        DbSet<OapChecklistWorkInstruction> OapChecklistWorkInstructions { get; set; }  
        DbSet<OapAssetDataManagement> OapAssetDataManagements { get; set; }
         
        DbSet<OapFrequency> OapFrequencies { get; set; }

        DbSet<OapChecklistQuestionDataType> OapChecklistQuestionDataTypes { get; set; }

        DbSet<OapChecklistReviewer> OapChecklistReviewers { get; set; }
        DbSet<OapAudit> OapAudits { get; set; }
        DbSet<OapAuditRight> OapAuditRights { get; set; }
        DbSet<OapAuditProtocol> OapAuditProtocols { get; set; }

        #endregion

        #region Rig OAP

        DbSet<RigOapChecklist> RigOapChecklists { get; set; }

        DbSet<RigOapChecklistQuestion> RigOapChecklistQuestions { get; set; }

        DbSet<RigOapChecklistWorkflow> RigOapChecklistWorkflows { get; set; }

        DbSet<RigOapChecklistQuestionFinding> RigOapChecklistQuestionFindings { get; set; }

        DbSet<RigOapChecklistAssessor> RigOapChecklistAssessors { get; set; }

        DbSet<RigOapChecklistVerifier> RigOapChecklistVerifiers { get; set; }

        DbSet<FindingType> FindingTypes { get; set; }

        DbSet<FindingSubType> FindingSubTypes { get; set; }

        DbSet<OapCheckListQuestionRelatedQuestionMap> OapCheckListQuestionRelatedQuestionMaps { get; set; }

        DbSet<RigOapChecklistQuestionComment> RigOapCheckListQuestionComments { get; set; }

        DbSet<RigOapChecklistQuestionNoAnswerComment> RigOapCheckListQuestionNoAnswerComments { get; set; }

        DbSet<RigOapChecklistGroupAsset> RigOapChecklistGroupAssets { get; set; }

        DbSet<RigOapChecklistWorkInstruction> RigOapChecklistWorkInstructions { get; set; }

        DbSet<RigOapChecklistThirdPartyJob> RigOapChecklistThirdPartyJobs { get; set; }

        #endregion
    }
}