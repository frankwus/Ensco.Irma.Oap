using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetAllByTypeStatusRigOapChecklistRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetAllByTypeStatusRigOapChecklistRequest(string typeName, string status)
        {
            TypeName = typeName;
            Status = status;
        }

        public string TypeName { get; }
        public string Status { get; }
    }
}