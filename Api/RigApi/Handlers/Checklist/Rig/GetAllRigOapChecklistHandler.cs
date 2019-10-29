using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetAllRigOapChecklistHandler : IRequestHandler<GetAllRigOapChecklistRequest, IEnumerable<RigOapChecklist>>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public GetAllRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        Task<IEnumerable<RigOapChecklist>> IRequestHandler<GetAllRigOapChecklistRequest, IEnumerable<RigOapChecklist>>.Handle(GetAllRigOapChecklistRequest request, CancellationToken cancellationToken)
        {
            var cl = (request.Start == null) ? RigOapChecklistService.GetAll(request.Status) : RigOapChecklistService.GetAll(request.Status, request.Start.Value);
            return Task.FromResult(cl);
        }
    }
}