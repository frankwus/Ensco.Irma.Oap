using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Equipment
{
    public class GetAllEquipmentRequest : IRequest<IEnumerable<OapEquipment>>
    { 
        public GetAllEquipmentRequest()
        {
           
        }         
    }
}