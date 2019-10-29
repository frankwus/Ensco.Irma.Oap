using System;
using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Controllers.Oap
{
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.Comment;

    [RoutePrefix("roapchecklists/question/comment")]
    public class RigOapChecklistQuestionCommentController : OapApiController
    {
        public RigOapChecklistQuestionCommentController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<RigOapChecklistQuestionComment> Get(Guid id)
        {
            return TryCatch<GetRigOapChecklistQuestionCommentRequest, RigOapChecklistQuestionComment>(new GetRigOapChecklistQuestionCommentRequest(id));
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestionComment>> GetAll()
        {
            return TryCatch<GetAllRigOapChecklistQuestionCommentRequest, IEnumerable<RigOapChecklistQuestionComment>>(new GetAllRigOapChecklistQuestionCommentRequest());
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<RigOapChecklistQuestionComment> UpdateRigChecklistComment(RigOapChecklistQuestionComment rigOapChecklistQuestionComment)
        {
            return TryCatch<UpdateRigOapChecklistQuestionCommentRequest, RigOapChecklistQuestionComment>(new UpdateRigOapChecklistQuestionCommentRequest(rigOapChecklistQuestionComment));
        }

        [HttpPost]
        [Route("delete")]
        public WebApiResult<bool> DeleteRigChecklistComment(Guid id)
        {
            return TryCatch<DeleteRigOapChecklistQuestionCommentRequest, bool>(new DeleteRigOapChecklistQuestionCommentRequest(id));
        }
    }
}


