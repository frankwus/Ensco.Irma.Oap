using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetAllInWorkflowByTypeSubTypeCodeVerifierRoleRigOapChecklistRequest : IRequest<IEnumerable<RigOapChecklist>>
    {
        public GetAllInWorkflowByTypeSubTypeCodeVerifierRoleRigOapChecklistRequest(string typeCode, string subTypeCode, string status, string verifierRole)
        {
            TypeCode = typeCode;
            SubTypeCode = subTypeCode;
            Status = status;
            VerifierRole = verifierRole;
        }
        public string TypeCode { get; }
        public string SubTypeCode { get; }
        public string Status { get; }
        public string VerifierRole { get; }
    }
}