using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistEquipment
{
    public class GetAllChecklistEquipmentRequest : IRequest<IEnumerable<OapChecklistEquipment>>
    { 
        public GetAllChecklistEquipmentRequest()
        {
           
        }

        //public int ChecklistId { get; set; }
    }
}