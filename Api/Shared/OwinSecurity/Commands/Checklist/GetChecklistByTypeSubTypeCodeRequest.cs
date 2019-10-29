using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class GetChecklistByTypeSubTypeCodeRequest : IRequest<IEnumerable<OapChecklist>>
    { 
        public GetChecklistByTypeSubTypeCodeRequest(string  typeCode, string subTypeCode)
        {
            TypeCode = typeCode;
            SubTypeCode = subTypeCode;
        }
         
        public string TypeCode { get; }

        public string SubTypeCode { get; }
    }
}