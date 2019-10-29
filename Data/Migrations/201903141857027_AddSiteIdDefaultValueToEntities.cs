namespace Ensco.Irma.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddSiteIdDefaultValueToEntities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Oap_FindingSubTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_FindingTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapAccountables", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapAssetDataManagements", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistGroups", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklists", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistComments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapFrequencyTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapProtocolFormTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapHierarchys", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistLayouts", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistLayoutColumns", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapGraphics", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistSubGroups", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistTopics", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistQuestions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerReviews", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistQuestionDataTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistQuestionTagMaps", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistQuestionTags", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapCheckListQuestionRelatedQuestionMaps", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapFrequencys", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapProtocolQuestionHeaders", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapSubSystems", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapSystems", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapSystemGroups", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapAuditProtocols", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapAudits", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapAuditRights", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklists", "RigId", c => c.Int(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetRigId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklists", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistAssessors", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistGroupAssets", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistComments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionAnswers", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionComments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionFindings", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistThirdPartyJobs", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistVerifiers", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistWorkInstructions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistWorkInstructions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapWorkInstructions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistEquipments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapEquipments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistReviewers", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_WorkflowInstances", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_WorkflowTransitions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_WorkflowStates", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_Workflows", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_WorkflowActivitys", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
            AlterColumn("dbo.Oap_WorkflowInstanceActivitys", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: null, newValue: "dbo.fn_GetSiteId()")
                    },
                }));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Oap_WorkflowInstanceActivitys", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_WorkflowActivitys", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_Workflows", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_WorkflowStates", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_WorkflowTransitions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_WorkflowInstances", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistReviewers", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapEquipments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistEquipments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapWorkInstructions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistWorkInstructions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistWorkInstructions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistVerifiers", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistThirdPartyJobs", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionFindings", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionComments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionAnswers", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistComments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistGroupAssets", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistAssessors", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklists", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklists", "RigId", c => c.Int(nullable: false,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetRigId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapAuditRights", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapAudits", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapAuditProtocols", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapSystemGroups", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapSystems", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapSubSystems", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapProtocolQuestionHeaders", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapFrequencys", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapCheckListQuestionRelatedQuestionMaps", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistQuestionTags", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistQuestionTagMaps", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistQuestionDataTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerReviews", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_RigOapChecklistQuestionNoAnswerComments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistQuestions", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistTopics", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistSubGroups", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapGraphics", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistLayoutColumns", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistLayouts", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapHierarchys", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapProtocolFormTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapFrequencyTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistComments", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklists", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapChecklistGroups", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapAssetDataManagements", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_OapAccountables", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_FindingTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
            AlterColumn("dbo.Oap_FindingSubTypes", "SiteId", c => c.String(maxLength: 10, fixedLength: true,
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SqlDefaultValue",
                        new AnnotationValues(oldValue: "dbo.fn_GetSiteId()", newValue: null)
                    },
                }));
        }
    }
}
