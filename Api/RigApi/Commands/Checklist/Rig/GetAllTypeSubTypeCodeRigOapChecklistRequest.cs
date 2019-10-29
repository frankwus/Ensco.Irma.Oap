using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetAllTypeSubTypeCodeRigOapChecklistRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetAllTypeSubTypeCodeRigOapChecklistRequest(string typeCode, string subTypeCode, string status)
        {
            TypeCode = typeCode;
            SubTypeCode = subTypeCode;
            Status = status;
        }

        public string TypeCode { get; }

        public string SubTypeCode { get; }
        public string Status { get; }
    }
}