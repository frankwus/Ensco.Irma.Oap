using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class GetAllRigOapChecklistThirdPartyJobHandler : IRequestHandler<GetAllRigOapChecklistThirdPartyJobRequest, IEnumerable<RigOapChecklistThirdPartyJob>>
    {
        private IRigOapChecklistThirdPartyJobService RigOapChecklistThirdPartyJobService { get; set; }

        public GetAllRigOapChecklistThirdPartyJobHandler(IRigOapChecklistThirdPartyJobService rigOapChecklistThirdPartyJobService)
        {
            RigOapChecklistThirdPartyJobService = rigOapChecklistThirdPartyJobService;
        }

        Task<IEnumerable<RigOapChecklistThirdPartyJob>> IRequestHandler<GetAllRigOapChecklistThirdPartyJobRequest, IEnumerable<RigOapChecklistThirdPartyJob>>.Handle(GetAllRigOapChecklistThirdPartyJobRequest request, CancellationToken cancellationToken)
        {
            var cl =  RigOapChecklistThirdPartyJobService.GetAll();
            return Task.FromResult(cl);
        }
    }
}