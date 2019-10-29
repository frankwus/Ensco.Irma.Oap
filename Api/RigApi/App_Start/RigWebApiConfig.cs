using System.Web.Http;
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

namespace Ensco.Irma.Oap.Api.Rig
{
    public class RigWebApiConfig: OapWebApiConfig<RigWebApiConfig>
    {
        public override void RegisterApiModules(Container container)
        {
            base.RegisterApiModules(container);



            #region OAP Modules

            container.Register<IOapChecklistWorkInstructionRepository, OapChecklistWorkInstructionRepository>(Lifestyle.Scoped);

            container.Register<IPobPersonnelRepository, PobPersonnelRepository>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistRepository, RigOapChecklistRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistAssessorRepository, RigOapChecklistAssessorRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistService, RigOapChecklistService>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistWorkflowRepository, RigOapChecklistWorkflowRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistWorkflowService, RigOapChecklistWorkflowService>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistQuestionAnswerRepository, RigOapChecklistQuestionAnswerRepository>(Lifestyle.Scoped);

            container.Register<IOapChecklistQuestionRelatedQuestionMapRepository, OapChecklistQuestionRelatedQuestionMapRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistQuestionRelatedQuestionMapService, OapChecklistQuestionRelatedQuestionMapService>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistQuestionCommentRepository, RigOapChecklistQuestionCommentRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistQuestionCommentService, RigOapChecklistQuestionCommentService>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistQuestionNoAnswerCommentRepository, RigOapChecklistQuestionNoAnswerCommentRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistQuestionNoAnswerCommentService, RigOapChecklistQuestionNoAnswerCommentService>(Lifestyle.Scoped);
             
            container.Register<IRigOapChecklistGroupAssetRepository, RigOapChecklistGroupAssetRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistGroupAssetService, RigOapChecklistGroupAssetService>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistWorkInstructionRepository, RigOapChecklistWorkInstructionRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistWorkInstructionService, RigOapChecklistWorkInstructionService>(Lifestyle.Scoped);

            container.Register<IRigOapChecklistThirdPartyJobRepository, RigOapChecklistThirdPartyJobRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistThirdPartyJobService, RigOapChecklistThirdPartyJobService>(Lifestyle.Scoped);

            container.Register<IOapDPARepository, OapDPARepository>(Lifestyle.Scoped);
            container.Register<IOapDPAService, OapDPAService>(Lifestyle.Scoped);

            container.Register<IReviewService, ReviewService>(Lifestyle.Scoped);
            container.Register<IIrmaReviewRepository, IrmaReviewRepository>(Lifestyle.Scoped);

            container.Register<ILifesaverService, LifesaverService>(Lifestyle.Scoped);                        

            #endregion


            #region IRMA 
            container.Register<IIrmaTaskRepository, IrmaTaskRepository>(Lifestyle.Scoped);
            container.Register<IIrmaTaskService, IrmaTaskService>(Lifestyle.Scoped);
             
            #endregion
        }

        public override void MapRoutes(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
             name: "RigApi",
             routeTemplate: "rigapi/{controller}/{id}",
             defaults: new { id = RouteParameter.Optional }
            );
        }

    }
 
}
