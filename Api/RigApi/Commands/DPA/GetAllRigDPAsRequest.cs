using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Commands.DPA
{
    public class GetAllRigDPAsRequest : IRequest<IEnumerable<Irma.Models.Domain.Oap.DPA>>
    {
        public GetAllRigDPAsRequest(int rigId)
        {
            RigId = rigId;
        }

        public int RigId { get; }
    }
}