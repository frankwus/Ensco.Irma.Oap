using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Data.Repositories.Irma;
using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Interfaces.Services.Irma;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Interfaces.Services.Oap.DPA;
using Ensco.Irma.Oap.Api.Common;
using Ensco.Irma.Services.Irma;
using Ensco.Irma.Services.Oap;
using Ensco.Irma.Services.Oap.DPA;
using SimpleInjector;
using System.Web.Http;

namespace Ensco.Irma.Oap.Api.Corp
{
    public class CorpWebApiConfig: OapWebApiConfig<CorpWebApiConfig>
    {
        public override void MapRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
             name: "CorpApi",
             routeTemplate: "corpapi/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
            );
        }

        public override void RegisterApiModules(Container container)
        {
            base.RegisterApiModules(container);

            #region Checklist

            container.Register<IRigOapChecklistRepository, RigOapChecklistRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistService, RigOapChecklistService>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistAssessorRepository, RigOapChecklistAssessorRepository>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistQuestionAnswerRepository, RigOapChecklistQuestionAnswerRepository>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistGroupAssetRepository, RigOapChecklistGroupAssetRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistGroupAssetService, RigOapChecklistGroupAssetService>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistWorkInstructionRepository, RigOapChecklistWorkInstructionRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistWorkInstructionService, RigOapChecklistWorkInstructionService>(Lifestyle.Scoped);

            container.Register<IPobPersonnelRepository, PobPersonnelRepository>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistQuestionNoAnswerCommentRepository, RigOapChecklistQuestionNoAnswerCommentRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistQuestionNoAnswerCommentService, RigOapChecklistQuestionNoAnswerCommentService>(Lifestyle.Scoped);
            //

            container.Register<IReviewService, ReviewService>(Lifestyle.Scoped);
            container.Register<IIrmaReviewRepository, IrmaReviewRepository>(Lifestyle.Scoped);

            container.Register<IOapChecklistTopicRepository, OapChecklistTopicRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistTopicService, OapChecklistTopicService>(Lifestyle.Scoped);

            container.Register<IOapChecklistQuestionRepository, OapChecklistQuestionRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistQuestionService, OapChecklistQuestionService>(Lifestyle.Scoped);            

            container.Register<IOapHierarchyRepository, OapHierarchyRepository>(Lifestyle.Scoped);
            container.Register<IOapHierarchyService, OapHierarchyService>(Lifestyle.Scoped);

            container.Register<IOapProtocolFormTypeRepository, OapProtocolFormTypeRepository>(Lifestyle.Scoped);
            container.Register<IOapProtocolFormTypeService, OapProtocolFormTypeService>(Lifestyle.Scoped);

            container.Register<IOapFrequencyTypeRepository, OapFrequencyTypeRepository>(Lifestyle.Scoped);
            container.Register<IOapFrequencyTypeService, OapFrequencyTypeService>(Lifestyle.Scoped);

            container.Register<IOapGraphicRepository, OapGraphicRepository>(Lifestyle.Scoped);
            container.Register<IOapGraphicService, OapGraphicService>(Lifestyle.Scoped);

            container.Register<IOapChecklistGroupRepository, OapChecklistGroupRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistGroupService, OapChecklistGroupService>(Lifestyle.Scoped);

            container.Register<IOapChecklistSubGroupRepository, OapChecklistSubGroupRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistSubGroupService, OapChecklistSubGroupService>(Lifestyle.Scoped);

            container.Register<IOapChecklistCommentRepository, OapChecklistCommentRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistCommentService, OapChecklistCommentService>(Lifestyle.Scoped);

            container.Register<IOapProtocolQuestionHeaderRepository, OapProtocolQuestionHeaderRepository>(Lifestyle.Scoped);
            container.Register<IOapProtocolQuestionHeaderService, OapProtocolQuestionHeaderService>(Lifestyle.Scoped);

            container.Register<IOapChecklistLayoutRepository, OapChecklistLayoutRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistLayoutService, OapChecklistLayoutService>(Lifestyle.Scoped);

            container.Register<IOapChecklistLayoutColumnRepository, OapChecklistLayoutColumnRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistLayoutColumnService, OapChecklistLayoutColumnService>(Lifestyle.Scoped);


            container.Register<IOapChecklistQuestionTagMapRepository, OapChecklistQuestionTagMapRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistQuestionTagMapService, OapChecklistQuestionTagMapService>(Lifestyle.Scoped);

            container.Register<IOapChecklistQuestionTagRepository, OapChecklistQuestionTagRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistQuestionTagService, OapChecklistQuestionTagService>(Lifestyle.Scoped);

            container.Register<IOapChecklistQuestionRelatedQuestionMapRepository, OapChecklistQuestionRelatedQuestionMapRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistQuestionRelatedQuestionMapService, OapChecklistQuestionRelatedQuestionMapService>(Lifestyle.Scoped);

            container.Register<IOapChecklistQuestionDataTypeRepository, OapChecklistQuestionDataTypeRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistQuestionDataTypeService, OapChecklistQuestionDataTypeService>(Lifestyle.Scoped);
            
            container.Register<IOapChecklistWorkInstructionRepository, OapChecklistWorkInstructionRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistWorkInstructionService, OapChecklistWorkInstructionService>(Lifestyle.Scoped);

            container.Register<IOapChecklistEquipmentRepository, OapChecklistEquipmentRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistEquipmentService, OapChecklistEquipmentService>(Lifestyle.Scoped);

            container.Register<IOapSystemGroupRepository, OapSystemGroupRepository>(Lifestyle.Scoped);
            container.Register<IOapSystemGroupService, OapSystemGroupService>(Lifestyle.Scoped);

            container.Register<IOapSystemRepository,OapSystemRepository>(Lifestyle.Scoped);
            container.Register<IOapSystemService, OapSystemService>(Lifestyle.Scoped);

            container.Register<IOapSubSystemRepository, OapSubSystemRepository>(Lifestyle.Scoped);
            container.Register<IOapSubSystemService, OapSubSystemService>(Lifestyle.Scoped);

            container.Register<IOapEquipmentRepository, OapEquipmentRepository>(Lifestyle.Scoped);
            container.Register<IOapEquipmentService, OapEquipmentService>(Lifestyle.Scoped);

            container.Register<IOapWorkInstructionRepository, OapWorkInstructionRepository>(Lifestyle.Scoped);
            container.Register<IOapWorkInstructionService, OapWorkInstructionService>(Lifestyle.Scoped);

            container.Register<IOapAccountableService, OapAccountableService>(Lifestyle.Scoped);
            container.Register<IOapAccountableRepository, OapAccountableRepository>(Lifestyle.Scoped);

            container.Register<IOapAuditService, OapAuditService>(Lifestyle.Scoped);
            container.Register<IOapAuditRepository, OapAuditRepository>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistWorkflowService, RigOapChecklistWorkflowService>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistWorkflowRepository, RigOapChecklistWorkflowRepository>(Lifestyle.Scoped);

            container.Register<IIrmaTaskService, IrmaTaskService>(Lifestyle.Scoped);
            container.Register<IIrmaTaskRepository, IrmaTaskRepository>(Lifestyle.Scoped);

            container.Register<IOapDPARepository, OapDPARepository>(Lifestyle.Scoped);
            container.Register<IOapDPAService, OapDPAService>(Lifestyle.Scoped);


            #endregion
        }
    } 
}