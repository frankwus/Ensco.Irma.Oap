using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap
{
    using Ensco.Irma.Oap.Api.Common.Models;
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;

    using Ensco.Irma.Oap.Common.Api.Controllers;
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag;

    [RoutePrefix("oapchecklists/questionTag")]
    public class OapChecklistQuestionTagController : OapApiController
    {
        public OapChecklistQuestionTagController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistQuestionTag>> GetAll()
        {
            return TryCatch<GetAllQuestionTagRequest, IEnumerable<OapChecklistQuestionTag>>(new GetAllQuestionTagRequest());
        }

        [HttpGet]
        [Route("{questionTagId}")]
        public WebApiResult<OapChecklistQuestionTag> GetById(int questionTagId)
        {
            return TryCatch<GetQuestionTagRequest, OapChecklistQuestionTag>(new GetQuestionTagRequest(questionTagId));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistQuestionTag> AddQuestionTag([FromBody] OapChecklistQuestionTag questionTag)
        {
            return TryCatch<AddQuestionTagRequest, OapChecklistQuestionTag>(new AddQuestionTagRequest(questionTag));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateQuestionTag([FromBody] OapChecklistQuestionTag questionTag)
        {
            return TryCatch<UpdateQuestionTagRequest, bool>(new UpdateQuestionTagRequest(questionTag));
        }

        [HttpDelete]
        [Route("delete/{questionTagId}")]
        public WebApiResult<bool> DeleteQuestionTag(int questionTagId)
        {
            return TryCatch<DeleteQuestionTagRequest, bool>(new DeleteQuestionTagRequest(questionTagId));
        }
    }
}
