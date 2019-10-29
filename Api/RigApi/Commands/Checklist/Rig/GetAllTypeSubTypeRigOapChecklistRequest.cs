using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetAllTypeSubTypeRigOapChecklistRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetAllTypeSubTypeRigOapChecklistRequest(string typeName, string subTypeName,string status)
        {
            TypeName = typeName;
            SubTypeName = subTypeName;
            Status = status;
        }

        public string TypeName { get; }

        public string SubTypeName { get; }
        public string Status { get; }
    }
}