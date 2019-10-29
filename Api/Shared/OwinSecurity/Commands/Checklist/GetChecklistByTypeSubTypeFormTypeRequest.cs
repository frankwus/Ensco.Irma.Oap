using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class GetChecklistByTypeSubTypeFormTypeRequest : IRequest<IEnumerable<OapChecklist>>
    {
        public GetChecklistByTypeSubTypeFormTypeRequest(string typeName, string subTypeName, string formType)
        {
            TypeName = typeName;
            SubTypeName = subTypeName;
            FormType = formType;
        }

        public string TypeName { get; }

        public string SubTypeName { get; }

        public string FormType { get; }
    }
}