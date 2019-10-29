using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class GetChecklistByTypeSubTypeCodeFormTypeRequest : IRequest<IEnumerable<OapChecklist>>
    {
        public GetChecklistByTypeSubTypeCodeFormTypeRequest(string typeCode, string subTypeCode, string formType)
        {
            TypeCode = typeCode;
            SubTypeCode = subTypeCode;
            FormType = formType;
        }

        public string TypeCode { get; }

        public string SubTypeCode { get; }

        public string FormType { get; }
    }
}