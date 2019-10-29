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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Comment;

    [RoutePrefix("oapchecklists/comment")]
    public class OapChecklistCommentController : OapApiController
    {
        public OapChecklistCommentController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklistComment> Get(int id)
        {
            return TryCatch<GetChecklistCommentRequest, OapChecklistComment>(new GetChecklistCommentRequest(id));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistComment>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllChecklistCommentRequest, IEnumerable<OapChecklistComment>>(new GetAllChecklistCommentRequest(model.StartDate, model.EndDate));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistComment> AddChecklistComment([FromBody] OapChecklistComment list)
        {
            return TryCatch<AddChecklistCommentRequest, OapChecklistComment>(new AddChecklistCommentRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateChecklistComment([FromBody] OapChecklistComment list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistCommentRequest, bool>(new UpdateChecklistCommentRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteChecklistComment(int id)
        {
            return TryCatch<DeleteChecklistCommentRequest, bool>(new DeleteChecklistCommentRequest(id));
        }
    }
}
