using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class GetChecklistByTypeSubTypeRequest : IRequest<IEnumerable<OapChecklist>>
    { 
        public GetChecklistByTypeSubTypeRequest(string  typeName, string subTypeName)
        {
            TypeName = typeName;
            SubTypeName = subTypeName; 
        }
         
        public string TypeName { get; }

        public string SubTypeName { get; } 
    }
}