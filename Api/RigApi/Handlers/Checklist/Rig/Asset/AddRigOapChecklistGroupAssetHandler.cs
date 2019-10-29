using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Asset;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class AddRigOapChecklistGroupAssetHandler : IRequestHandler<AddRigOapChecklistGroupAssetRequest, RigOapChecklistGroupAsset>
    {
        private IRigOapChecklistGroupAssetService RigOapChecklistGroupAssetService { get; set; }


        public AddRigOapChecklistGroupAssetHandler(IRigOapChecklistGroupAssetService rigOapChecklistQuestionCommentService)
        {
            RigOapChecklistGroupAssetService = rigOapChecklistQuestionCommentService;
        }

        Task<RigOapChecklistGroupAsset> IRequestHandler<AddRigOapChecklistGroupAssetRequest, RigOapChecklistGroupAsset>.Handle(AddRigOapChecklistGroupAssetRequest request, CancellationToken cancellationToken)
        {
            Guid rigChecklistGroupAssetId = Guid.Empty;

            using (var ts = new TransactionScope())
            {
                rigChecklistGroupAssetId = RigOapChecklistGroupAssetService.Add(request.Asset);

                ts.Complete();
            }

            var rigoapChecklistGroupAsset = RigOapChecklistGroupAssetService.Get(rigChecklistGroupAssetId);

            return Task.FromResult(rigoapChecklistGroupAsset);
        }


        
    }
}