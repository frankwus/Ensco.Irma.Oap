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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolFormType;

    [RoutePrefix("oapprotocolformtype")]
    public class OapProtocolFormTypeController : OapApiController
    {
        public OapProtocolFormTypeController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapProtocolFormType> Get(int id)
        {
            return TryCatch<GetProtocolFormTypeRequest, OapProtocolFormType>(new GetProtocolFormTypeRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapProtocolFormType>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllProtocolFormTypeRequest, IEnumerable<OapProtocolFormType>>(new GetAllProtocolFormTypeRequest(model.StartDate, model.EndDate));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapProtocolFormType> AddProtocolFormType([FromBody] OapProtocolFormType list)
        {
            return TryCatch<AddProtocolFormTypeRequest, OapProtocolFormType>(new AddProtocolFormTypeRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateProtocolFormType([FromBody] OapProtocolFormType list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateProtocolFormTypeRequest, bool>(new UpdateProtocolFormTypeRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteProtocolFormType(int id)
        {
            return TryCatch<DeleteProtocolFormTypeRequest, bool>(new DeleteProtocolFormTypeRequest(id));
        }
    }
}
