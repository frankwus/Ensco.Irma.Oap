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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Topic;

    [RoutePrefix("oapchecklists/topic")] 
    public class OapChecklistTopicController : OapApiController
    {
        public OapChecklistTopicController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }
 
        [HttpGet]
        [Route("{id}")]
        public WebApiResult<OapChecklistTopic> Get(int id)
        {
            return TryCatch<GetChecklistTopicRequest, OapChecklistTopic>(new GetChecklistTopicRequest(id));
        }

        [HttpGet]
        [Route("group/{groupId}")]
        public WebApiResult<IEnumerable<OapChecklistTopic>> GetAllGroupTopics(int groupId)
        {
            return TryCatch<GetAllGroupTopicRequest,IEnumerable<OapChecklistTopic>>(new GetAllGroupTopicRequest(groupId)); 
        }

        [HttpGet]
        [Route("checklist/{checklistId}")]
        public WebApiResult<IEnumerable<OapChecklistTopic>> GetAllChecklistTopics(int checklistId)
        {
            return TryCatch<GetAllChecklistTopicRequest, IEnumerable<OapChecklistTopic>>(new GetAllChecklistTopicRequest(checklistId));
        }

        [HttpPost]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistTopic>> GetAll([FromBody] GetAllModel model)
        {
            return TryCatch<GetAllTopicRequest, IEnumerable<OapChecklistTopic>>(new GetAllTopicRequest(model.StartDate, model.EndDate));
        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistTopic> AddTopic([FromBody] OapChecklistTopic Topic)
        {
            return TryCatch<AddChecklistTopicRequest, OapChecklistTopic>(new AddChecklistTopicRequest(Topic));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateTopic([FromBody] OapChecklistTopic Topic)
        { 
            return TryCatch<UpdateChecklistTopicRequest, bool>(new UpdateChecklistTopicRequest(Topic));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteTopic( int id)
        {
            return TryCatch<DeleteChecklistTopicRequest, bool>(new DeleteChecklistTopicRequest(id));
        }
    }
}
