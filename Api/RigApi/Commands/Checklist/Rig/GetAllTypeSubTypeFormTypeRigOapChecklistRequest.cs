using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetAllTypeSubTypeFormTypeRigOapChecklistRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetAllTypeSubTypeFormTypeRigOapChecklistRequest(string typeName, string subTypeName, string formType, string status)
        {
            TypeName = typeName;
            SubTypeName = subTypeName;
            FormType = formType;
            Status = status;
        }

        public string TypeName { get; }

        public string SubTypeName { get; }
        public string FormType { get; }
        public string Status { get; }
    }
}