using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup
{
    public class UpdateChecklistGroupRequest : IRequest<bool>
    {
        public UpdateChecklistGroupRequest(OapChecklistGroup checklistGroup)
        {
            ChecklistGroup = checklistGroup;
        }

        public OapChecklistGroup ChecklistGroup { get;  }
    }
}