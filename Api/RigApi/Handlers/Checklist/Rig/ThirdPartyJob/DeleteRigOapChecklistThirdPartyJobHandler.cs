using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class DeleteRigOapChecklistThirdPartyJobHandler : IRequestHandler<DeleteRigOapChecklistThirdPartyJobRequest, bool>
    {
        private IRigOapChecklistThirdPartyJobService RigOapChecklistThirdPartyJobService { get; set; }

        public DeleteRigOapChecklistThirdPartyJobHandler(IRigOapChecklistThirdPartyJobService rigOapChecklistThirdPartyJobService)
        {
            RigOapChecklistThirdPartyJobService = rigOapChecklistThirdPartyJobService;
        }

        Task<bool> IRequestHandler<DeleteRigOapChecklistThirdPartyJobRequest, bool>.Handle(DeleteRigOapChecklistThirdPartyJobRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var rigOapChecklistThirdPartyJob = RigOapChecklistThirdPartyJobService.Get(request.ThirdPartyJobId);

                RigOapChecklistThirdPartyJobService.Delete(rigOapChecklistThirdPartyJob);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}