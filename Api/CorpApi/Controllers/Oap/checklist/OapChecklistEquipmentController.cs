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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistEquipment;

    [RoutePrefix("oapchecklists/equipment")]
    public class OapChecklistEquipmentController : OapApiController
    {
        public OapChecklistEquipmentController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapChecklistEquipment>> GetAll()
        {
            return TryCatch<GetAllChecklistEquipmentRequest, IEnumerable<OapChecklistEquipment>>(new GetAllChecklistEquipmentRequest());

        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapChecklistEquipment> AddChecklistEquipment([FromBody] OapChecklistEquipment list)
        {
            return TryCatch<AddChecklistEquipmentRequest, OapChecklistEquipment>(new AddChecklistEquipmentRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateChecklistEquipment([FromBody] OapChecklistEquipment list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateChecklistEquipmentRequest, bool>(new UpdateChecklistEquipmentRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteChecklistEquipment(int id)
        {
            return TryCatch<DeleteChecklistEquipmentRequest, bool>(new DeleteChecklistEquipmentRequest(id));
        }
    }
}
