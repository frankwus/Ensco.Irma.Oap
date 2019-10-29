using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistSubGroup
{
    public class GetAllChecklistSubGroupHandler : IRequestHandler<GetAllChecklistSubGroupRequest, IEnumerable<OapChecklistSubGroup>>
    {
        private IOapChecklistSubGroupService Service { get; set; }

        public GetAllChecklistSubGroupHandler(IOapChecklistSubGroupService checklistSubGroupService)
        {
            Service = checklistSubGroupService;
        }

        Task<IEnumerable<OapChecklistSubGroup>> IRequestHandler<GetAllChecklistSubGroupRequest, IEnumerable<OapChecklistSubGroup>>.Handle(GetAllChecklistSubGroupRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll(request.StartDate, request.EndDate);
            return Task.FromResult(cl);
        }
    }
}