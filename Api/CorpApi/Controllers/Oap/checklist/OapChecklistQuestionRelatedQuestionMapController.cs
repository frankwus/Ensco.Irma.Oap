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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionRelatedQuestionMap;

    [RoutePrefix("oapchecklists/questionRelatedQuestionMap")] 
    public class OapChecklistQuestionRelatedQuestionMapController : OapApiController
    {
        public OapChecklistQuestionRelatedQuestionMapController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all/{id}")]
        public WebApiResult<IEnumerable<OapChecklistQuestion>> GetAll(int id)
        {
            return TryCatch<GetAllQuestionRelatedQuestionMapRequest, IEnumerable<OapChecklistQuestion>>(new GetAllQuestionRelatedQuestionMapRequest(id));
        }


        [HttpPut]
        [Route("add")]
        public WebApiResult<OapCheckListQuestionRelatedQuestionMap> AddQuestionRelatedQuestionMap([FromBody] OapCheckListQuestionRelatedQuestionMap questionRelatedQuestionMap)
        {
            return TryCatch<AddQuestionRelatedQuestionMapRequest, OapCheckListQuestionRelatedQuestionMap>(new AddQuestionRelatedQuestionMapRequest(questionRelatedQuestionMap));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateQuestionRelatedQuestionMap([FromBody] OapCheckListQuestionRelatedQuestionMap questionRelatedQuestionMap)
        {
            return TryCatch<UpdateQuestionRelatedQuestionMapRequest, bool>(new UpdateQuestionRelatedQuestionMapRequest(questionRelatedQuestionMap));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteQuestionRelatedQuestionMap(int id)
        {
            return TryCatch<DeleteQuestionRelatedQuestionMapRequest, bool>(new DeleteQuestionRelatedQuestionMapRequest(id));
        }
    }
}
