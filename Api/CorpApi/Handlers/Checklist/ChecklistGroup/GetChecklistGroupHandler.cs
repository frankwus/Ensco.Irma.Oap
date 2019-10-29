using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.ChecklistGroup
{
    public class GetChecklistGroupHandler : IRequestHandler<GetChecklistGroupRequest, OapChecklistGroup>
    {
        private IOapChecklistGroupService Service { get; set; }

        public GetChecklistGroupHandler(IOapChecklistGroupService checklistGroupService)
        {
            Service = checklistGroupService;
        }

        Task<OapChecklistGroup> IRequestHandler<GetChecklistGroupRequest, OapChecklistGroup>.Handle(GetChecklistGroupRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.ChecklistGroupId);
            return Task.FromResult(cl);
        }
    }
}