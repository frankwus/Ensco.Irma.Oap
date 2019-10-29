using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Asset;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class DeleteRigOapChecklistGroupAssetHandler : IRequestHandler<DeleteRigOapChecklistGroupAssetRequest, bool>
    {
        private IRigOapChecklistGroupAssetService RigOapChecklistGroupAssetService { get; set; }

        public DeleteRigOapChecklistGroupAssetHandler(IRigOapChecklistGroupAssetService rigOapChecklistGroupAssetService)
        {
            RigOapChecklistGroupAssetService = rigOapChecklistGroupAssetService;
        }

        Task<bool> IRequestHandler<DeleteRigOapChecklistGroupAssetRequest, bool>.Handle(DeleteRigOapChecklistGroupAssetRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var rigOapChecklistGroupAsset = RigOapChecklistGroupAssetService.Get(request.AssetId);

                RigOapChecklistGroupAssetService.Delete(rigOapChecklistGroupAsset);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}