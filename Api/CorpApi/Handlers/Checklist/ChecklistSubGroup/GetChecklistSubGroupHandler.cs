using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.ChecklistSubGroup
{
    public class GetChecklistSubGroupHandler : IRequestHandler<GetChecklistSubGroupRequest, OapChecklistSubGroup>
    {
        private IOapChecklistSubGroupService Service { get; set; }

        public GetChecklistSubGroupHandler(IOapChecklistSubGroupService checklistSubGroupService)
        {
            Service = checklistSubGroupService;
        }

        Task<OapChecklistSubGroup> IRequestHandler<GetChecklistSubGroupRequest, OapChecklistSubGroup>.Handle(GetChecklistSubGroupRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.ChecklistSubGroupId);
            return Task.FromResult(cl);
        }
    }
}