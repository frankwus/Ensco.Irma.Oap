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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ProtocolQuestionHeader;

    [RoutePrefix("oapchecklists/protocolquestionheader")]
    public class OapProtocolQuestionHeaderController : OapApiController
    {
        public OapProtocolQuestionHeaderController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapProtocolQuestionHeader> Get(int id)
        {
            return TryCatch<GetOapProtocolQuestionHeaderRequest, OapProtocolQuestionHeader>(new GetOapProtocolQuestionHeaderRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapProtocolQuestionHeader>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllOapProtocolQuestionHeaderRequest, IEnumerable<OapProtocolQuestionHeader>>(new GetAllOapProtocolQuestionHeaderRequest(model.StartDate, model.EndDate));
        }

      

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapProtocolQuestionHeader> AddProtocolQuestionHeader([FromBody] OapProtocolQuestionHeader list)
        {
            return TryCatch<AddOapProtocolQuestionHeaderRequest, OapProtocolQuestionHeader>(new AddOapProtocolQuestionHeaderRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateProtocolQuestionHeader([FromBody] OapProtocolQuestionHeader list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateOapProtocolQuestionHeaderRequest, bool>(new UpdateOapProtocolQuestionHeaderRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteProtocolQuestionHeader(int id)
        {
            return TryCatch<DeleteOapProtocolQuestionHeaderRequest, bool>(new DeleteOapProtocolQuestionHeaderRequest(id));
        }
    }
}
