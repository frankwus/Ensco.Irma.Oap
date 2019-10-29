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
    using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Equipment;

    [RoutePrefix("equipment")]
    public class OapEquipmentController : OapApiController
    {
        public OapEquipmentController(IMediator mediator, ILog logger) : base(mediator, logger)
        {
        }

        [HttpGet]
        [Route("all")]
        public WebApiResult<IEnumerable<OapEquipment>> GetAll()
        {
            return TryCatch<GetAllEquipmentRequest, IEnumerable<OapEquipment>>(new GetAllEquipmentRequest());

        }

        [HttpPut]
        [Route("add")]
        public WebApiResult<OapEquipment> AddEquipment([FromBody] OapEquipment list)
        {
            return TryCatch<AddEquipmentRequest, OapEquipment>(new AddEquipmentRequest(list));
        }

        [HttpPost]
        [Route("update")]
        public WebApiResult<bool> UpdateEquipment([FromBody] OapEquipment list)
        {
            if (list == null)
            {
                throw new System.Exception("Argument is null");
            }

            return TryCatch<UpdateEquipmentRequest, bool>(new UpdateEquipmentRequest(list));
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public WebApiResult<bool> DeleteEquipment(int id)
        {
            return TryCatch<DeleteEquipmentRequest, bool>(new DeleteEquipmentRequest(id));
        }
    }
}
