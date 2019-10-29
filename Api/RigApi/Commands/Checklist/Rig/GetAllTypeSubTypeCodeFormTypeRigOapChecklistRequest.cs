using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetAllTypeSubTypeCodeFormTypeRigOapChecklistRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetAllTypeSubTypeCodeFormTypeRigOapChecklistRequest(string typeCode, string subTypeCode, string formType, string status)
        {
            TypeCode = typeCode;
            SubTypeCode = subTypeCode;
            FormType = formType;
            Status = status;
        }

        public string TypeCode { get; }

        public string SubTypeCode { get; }

        public string FormType { get; }

        public string Status { get; }
    }
}