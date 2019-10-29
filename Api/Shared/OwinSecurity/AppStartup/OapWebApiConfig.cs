using AutoMapper;
using Ensco.Irma.Business.Workflow;
using Ensco.Irma.Data.Context;
using Ensco.Irma.Data.Repositories;
using Ensco.Irma.Framework.Configuration;
using Ensco.Irma.Interfaces.Data.Repositories;
using Ensco.Irma.Interfaces.Services;
using Ensco.Irma.Interfaces.Services.Data;
using Ensco.Irma.Interfaces.Services.Irma;
using Ensco.Irma.Interfaces.Services.Logging;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Interfaces.Services.Security;
using Ensco.Irma.Interfaces.Services.Workflow;
using Ensco.Irma.Logging;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.ActionFilters;
using Ensco.Irma.Oap.Api.Common.AppStartup;
using Ensco.Irma.Oap.Api.Common.Formatters;
using Ensco.Irma.Services.Irma;
using Ensco.Irma.Services.Oap;
using Ensco.Irma.Services.Security;
using Ensco.Irma.Services.Workflow;
using MediatR;
using MediatR.Pipeline;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Http;

namespace Ensco.Irma.Oap.Api.Common
{
    public class OapWebApiConfig<T>: IOapWebApiConfig
        where T: IOapWebApiConfig, new()
    {
        private static object lockObject = new object();

        public static Lazy<T> Instance { get; private set; } 

        public Container Container {get; private set;}
        
        public void Register(HttpConfiguration config)
        {
            FrameworkEnvironment.Configure();
            var container = FrameworkEnvironment.Instance.Container;

            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));
           
            var json = config.Formatters.JsonFormatter;
            json.UseDataContractJsonSerializer = false;
           
           if (json != null)
           {
               config.Formatters.Remove(json);
           }

            json = new BrowserJsonFormatter();
            config.Formatters.Insert(0, new JsonNewtonFormatter());
            config.Formatters.Insert(0, json);

            json = config.Formatters.JsonFormatter; 

            // Web API routes
            config.MapHttpAttributeRoutes();

            MapRoutes(config);

            // Web API configuration and services
            RegisterDependencyContainer(config, container);

            config.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);

            //config.Filters.Add(new LoggingFilter(config));
            config.Filters.Add(new GlobalExceptionFilter(config));
            config.Filters.Add(new ValidateModelFilter());

            Container = container;
        }

        public static void Initialize(HttpConfiguration config)
        { 
            if (Instance == null)
            {
                lock(lockObject)
                {
                    if (Instance == null)
                    {
                        Instance = new Lazy<T>(() => new T());
                        Instance.Value.Register(config);
                    }
                }
            }

        }

        public virtual void RegisterDependencyContainer(HttpConfiguration config, Container container)
        {
            if (container.Options.DefaultScopedLifestyle == null)
            {
                container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            }

            var assemblies = GetAssemblies().ToArray();

            container.RegisterInstance<IEnvironment>(FrameworkEnvironment.Instance);
            #region Mediator    
            BuildMediator(container, assemblies);
            #endregion

            container.RegisterInstance<IIrmaOapDbContext>(new IrmaOapDbContext(FrameworkEnvironment.Instance.Configuration.GetConnectionString()));
            container.RegisterInstance<IIrmaDbContext>(new IrmaDbContext(FrameworkEnvironment.Instance.Configuration.GetConnectionString()));
            container.RegisterInstance<ILog>(Log.GetLogger(typeof(T)));

            RegisterApiModules(container);
           

            #region Security    
            container.Register<IPeopleRepository, PeopleRepository>(Lifestyle.Scoped);
            container.Register<IPeopleService, PeopleService>(Lifestyle.Scoped);
            #endregion

            #region Auto Mapper
            var mapper = new MapperConfiguration(cfg => cfg.AddProfiles(assemblies)).CreateMapper();
            container.RegisterInstance<IMapper>(mapper);
            #endregion

            #region Workflow Modules
            
            container.Register<IWorkflowEngineService, WorkflowEngineService>(Lifestyle.Scoped);
            container.Register<IWorkflowService, WorkflowService>(Lifestyle.Scoped);
            container.Register<IWorkflowRepository, WorkflowRepository>(Lifestyle.Scoped);
            #endregion


            container.Register<IAdminCustomRepository, AdminCustomRepository>(Lifestyle.Scoped);

            #region Finding Modules
            container.Register<IRigOapChecklistQuestionRepository, RigOapChecklistQuestionRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistQuestionFindingRepository, RigOapChecklistQuestionFindingRepository>(Lifestyle.Scoped);
            container.Register<IRigOapChecklistQuestionFindingService, RigOapChecklistQuestionFindingService>(Lifestyle.Scoped);
            container.Register<IFindingTypeRepository, FindingTypeRepository>(Lifestyle.Scoped);
            container.Register<IFindingTypeService, FindingTypeService>(Lifestyle.Scoped);
            container.Register<IFindingSubTypeRepository, FindingSubTypeRepository>(Lifestyle.Scoped);
            container.Register<IFindingSubTypeService, FindingSubTypeService>(Lifestyle.Scoped);
            #endregion

            container.Register<IOapChecklistService, OapChecklistService>(Lifestyle.Scoped);
            container.Register<IOapChecklistRepository, OapChecklistRepository>(Lifestyle.Scoped);

            container.Register<IOapFrequencyRepository, OapFrequencyRepository>(Lifestyle.Scoped);
            container.Register<IOapFrequencyService, OapFrequencyService>(Lifestyle.Scoped);

            container.Register<IOapChecklistAssetDataManagementRepository, OapChecklistAssetDataManagementRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistAssetDataManagementService, OapChecklistAssetDataManagementService>(Lifestyle.Scoped);

            container.Register<IIrmaCAPARepository, IrmaCAPARepository>(Lifestyle.Scoped);
            container.Register<IIrmaCAPAService, IrmaCAPAService>(Lifestyle.Scoped);

            container.Register<IOapChecklistReviewerRepository, OapChecklistReviewerRepository>(Lifestyle.Scoped);
            container.Register<IOapChecklistReviewerService, OapChecklistReviewerService>(Lifestyle.Scoped);

            container.Register<IOapAuditProtocolMapRepository, OapAuditProtocolMapRepository>(Lifestyle.Scoped);
            container.Register<IOapAuditProtocolMapService, OapAuditProtocolMapService>(Lifestyle.Scoped);

            #region Lookup

            container.Register<ICriticalityRepository,CriticalityRepository>(Lifestyle.Scoped);
            container.Register<ICriticalityService, CriticalityService>(Lifestyle.Scoped);


            #endregion

            container.RegisterWebApiControllers(config, assemblies);

            container.Verify();
        }

        public virtual void RegisterApiModules(Container container)
        {
        }

        public virtual void MapRoutes(HttpConfiguration config)
        {
          
        }

        private  IEnumerable<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies().Where( (a) => a.FullName.Contains("Ensco"));

        }

        public virtual void BuildMediator(Container container, IEnumerable<Assembly> assemblies)
        {
            container.Register<IMediator, Mediator>(Lifestyle.Singleton);

            container.Register(typeof(IRequestHandler<,>), assemblies, Lifestyle.Scoped);

            container.Collection.Register(typeof(IRequestPreProcessor<>), assemblies);

            container.Collection.Register(typeof(IRequestPostProcessor<,>), assemblies);

            container.Collection.Register(typeof(INotificationHandler<>), assemblies);

            //Pipeline
            container.Collection.Register(typeof(IPipelineBehavior<,>), new[]
            {
                typeof(RequestPreProcessorBehavior<,>),
                typeof(RequestPostProcessorBehavior<,>)
            });

            container.Register(() => new ServiceFactory(container.GetInstance), Lifestyle.Singleton);
        }

    }
 
}
