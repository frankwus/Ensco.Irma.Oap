using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap
{
    using Ensco.Irma.Oap.Api.Common.Models;
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question;
    using Ensco.Irma.Oap.Common.Api.Controllers;

    [RoutePrefix("oapchecklists/question")] 
    public class OapChecklistQuestionController : OapApiController
    {
        public OapChecklistQuestionController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }
 
        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklistQuestion> Get(int id)
        {
            return TryCatch<GetChecklistQuestionRequest, OapChecklistQuestion>(new GetChecklistQuestionRequest(id));
        }

        [HttpGet]
        [Route("subgroup/{subGroupId}")]
        public WebApiResult<IEnumerable<OapChecklistQuestion>> GetAllSubGroupQuestions(int subGroupId)
        {
            return TryCatch<GetAllSubGroupQuestionRequest, IEnumerable<OapChecklistQuestion>>(new GetAllSubGroupQuestionRequest(subGroupId)); 
        }

        [HttpGet]
        [Route("checklist/{checklistId}")]
        public WebApiResult<IEnumerable<OapChecklistQuestion>> GetAllChecklistQuestions(int checklistId)
        {
            return TryCatch<GetAllChecklistQuestionRequest, IEnumerable<OapChecklistQuestion>>(new GetAllChecklistQuestionRequest(checklistId));
        }

        [HttpGet]
        [Route("topic/{topicId}")]
        public WebApiResult<IEnumerable<OapChecklistQuestion>> GetAllTopicQuestions(int topicId)
        {
            return TryCatch<GetAllTopicQuestionRequest, IEnumerable<OapChecklistQuestion>>(new GetAllTopicQuestionRequest(topicId));
        }

        [HttpPost]
        [Route("protocol/all")]
        public WebApiResult<IEnumerable<OapChecklistQuestion>> GetAllProtocolQuestions([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllProtocolQuestionRequest, IEnumerable<OapChecklistQuestion>>(new GetAllProtocolQuestionRequest(model.StartDate, model.EndDate));
        }


        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistQuestion> AddQuestion([FromBody] OapChecklistQuestion question)
        {
            return TryCatch<AddChecklistQuestionRequest, OapChecklistQuestion>(new AddChecklistQuestionRequest(question));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateQuestion([FromBody] OapChecklistQuestion question)
        { 
            return TryCatch<UpdateChecklistQuestionRequest, bool>(new UpdateChecklistQuestionRequest(question));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteQuestion( int id)
        {
            return TryCatch<DeleteChecklistQuestionRequest, bool>(new DeleteChecklistQuestionRequest(id));
        }
    }
}
