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
    using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Question.NoAnswerComment;

    [RoutePrefix("roapchecklists/question/noanswercomment")]
    public class RigOapChecklistQuestionNoAnswerCommentController : OapApiController
    {
        public RigOapChecklistQuestionNoAnswerCommentController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("{id}")]
        public WebApiResult<RigOapChecklistQuestionNoAnswerComment> Get(Guid id)
        {
            return TryCatch<GetRigOapChecklistQuestionNoAnswerCommentRequest, RigOapChecklistQuestionNoAnswerComment>(new GetRigOapChecklistQuestionNoAnswerCommentRequest(id));
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<RigOapChecklistQuestionNoAnswerComment>> GetAll()
        {
            return TryCatch<GetAllRigOapChecklistQuestionNoAnswerCommentRequest, IEnumerable<RigOapChecklistQuestionNoAnswerComment>>(new GetAllRigOapChecklistQuestionNoAnswerCommentRequest());
        }

        [HttpGet]
        [Route("question/{questionid}")]
        public WebApiResult<RigOapChecklistQuestionNoAnswerComment> GetByQuestionId(Guid questionId)
        {
            return TryCatch<GetRigOapChecklistQuestionNoAnswerCommentByQuestionRequest, RigOapChecklistQuestionNoAnswerComment>(new GetRigOapChecklistQuestionNoAnswerCommentByQuestionRequest(questionId));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<RigOapChecklistQuestionNoAnswerComment> AddRigChecklistNoAnswerComment([FromBody] RigOapChecklistQuestionNoAnswerComment comment)
        {
            return TryCatch<AddRigOapChecklistQuestionNoAnswerCommentRequest, RigOapChecklistQuestionNoAnswerComment>(new AddRigOapChecklistQuestionNoAnswerCommentRequest(comment));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<RigOapChecklistQuestionNoAnswerComment> UpdateRigChecklistNoAnswerComment(RigOapChecklistQuestionNoAnswerComment rigOapChecklistQuestionNoAnswerComment)
        {
            return TryCatch<UpdateRigOapChecklistQuestionNoAnswerCommentRequest, RigOapChecklistQuestionNoAnswerComment>(new UpdateRigOapChecklistQuestionNoAnswerCommentRequest(rigOapChecklistQuestionNoAnswerComment));
        }

        [HttpPost]
        [Route("delete")]
        public WebApiResult<bool> DeleteRigChecklistNoAnswerComment(Guid id)
        {
            return TryCatch<DeleteRigOapChecklistQuestionNoAnswerCommentRequest, bool>(new DeleteRigOapChecklistQuestionNoAnswerCommentRequest(id));
        }
    }
}


