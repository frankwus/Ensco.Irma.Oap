using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistGroup
{
    public class GetAllChecklistGroupHandler : IRequestHandler<GetAllChecklistGroupRequest, IEnumerable<OapChecklistGroup>>
    {
        private IOapChecklistGroupService Service { get; set; }

        public GetAllChecklistGroupHandler(IOapChecklistGroupService checklistGroupService)
        {
            Service = checklistGroupService;
        }

        Task<IEnumerable<OapChecklistGroup>> IRequestHandler<GetAllChecklistGroupRequest, IEnumerable<OapChecklistGroup>>.Handle(GetAllChecklistGroupRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll(request.StartDate, request.EndDate);
            return Task.FromResult(cl);
        }
    }
}