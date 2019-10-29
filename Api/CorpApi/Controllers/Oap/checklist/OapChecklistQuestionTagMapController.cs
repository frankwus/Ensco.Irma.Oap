using System.Collections.Generic;
using System.Web.Http;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Controllers.Oap
{
    using Ensco.Irma.Oap.Api.Common.Models;
    using Ensco.Irma.Interfaces.Services.Logging;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Oap.Api.Common.ActionResults;
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap;
    using Ensco.Irma.Oap.Common.Api.Controllers;

    [RoutePrefix("oapchecklists/questionTagMap")] 
    public class OapChecklistQuestionTagMapController : OapApiController
    {
        public OapChecklistQuestionTagMapController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistQuestionTagMap>> GetAll()
        {
            return TryCatch<GetAllQuestionTagMapRequest, IEnumerable<OapChecklistQuestionTagMap>>(new GetAllQuestionTagMapRequest());
        }

        [HttpGet]
        [Route("tags/{questionId}")]
        public WebApiResult<IEnumerable<OapChecklistQuestionTagMap>> GetAllTags(int questionId)
        {
            return TryCatch<GetAllTagMapsForQuestionRequest, IEnumerable<OapChecklistQuestionTagMap>>(new GetAllTagMapsForQuestionRequest(questionId));
        }

        [HttpGet]
        [Route("{questionTagMapId}")]
        public WebApiResult<OapChecklistQuestionTagMap> Get(int questionTagMapId)
        {
            return TryCatch<GetQuestionTagMapRequest, OapChecklistQuestionTagMap>(new GetQuestionTagMapRequest(questionTagMapId));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistQuestionTagMap> AddQuestionTagMap([FromBody] OapChecklistQuestionTagMap questionTagMap)
        {
            return TryCatch<AddQuestionTagMapRequest, OapChecklistQuestionTagMap>(new AddQuestionTagMapRequest(questionTagMap));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateQuestionTagMap([FromBody] OapChecklistQuestionTagMap questionTagMap)
        {
            return TryCatch<UpdateQuestionTagMapRequest, bool>(new UpdateQuestionTagMapRequest(questionTagMap));
        }

        [HttpDelete]
        [Route("delete/{questionTagMapId}")]
        public WebApiResult<bool> DeleteQuestionTagMap(int questionTagMapId)
        {
            return TryCatch<DeleteQuestionTagMapRequest, bool>(new DeleteQuestionTagMapRequest(questionTagMapId));
        }
    }
}
