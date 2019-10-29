using System;
using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Api.Common.Models;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Hierarchy;

    [RoutePrefix("oaphierarchy")]
    public class OapHierarchyController : OapApiController
    {
        public OapHierarchyController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapHierarchy> Get(int id)
        {
            return TryCatch<GetHierarchyRequest, OapHierarchy>(new GetHierarchyRequest(id));
        }

        [HttpPost]
        [Route("all/parents")]
        public WebApiResult<IEnumerable<OapHierarchy>> GetAllParents([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllParentHierarchyRequest, IEnumerable<OapHierarchy>>(new GetAllParentHierarchyRequest(model.StartDate, model.EndDate));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapHierarchy>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllHierarchyRequest, IEnumerable<OapHierarchy>>(new GetAllHierarchyRequest(model.StartDate, model.EndDate));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapHierarchy> AddHierarchy([FromBody] OapHierarchy list)
        {
            return TryCatch<AddHierarchyRequest, OapHierarchy>(new AddHierarchyRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateHierarchy([FromBody] OapHierarchy list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateHierarchyRequest, bool>(new UpdateHierarchyRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteHierarchy(int id)
        {
            return TryCatch<DeleteHierarchyRequest, bool>(new DeleteHierarchyRequest(id));
        }
    }
}
