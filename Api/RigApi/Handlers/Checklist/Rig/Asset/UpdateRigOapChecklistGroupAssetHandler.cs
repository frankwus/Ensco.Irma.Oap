using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.Asset;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class UpdateRigOapChecklistGroupAssetHandler : IRequestHandler<UpdateRigOapChecklistGroupAssetRequest, RigOapChecklistGroupAsset>
    {
        private IRigOapChecklistGroupAssetService RigOapChecklistGroupAssetService { get; set; }
        public IMapper AutoMapper { get; }

        public UpdateRigOapChecklistGroupAssetHandler(IRigOapChecklistGroupAssetService rigOapChecklistGroupAssetService, IMapper mapper)
        {
            RigOapChecklistGroupAssetService = rigOapChecklistGroupAssetService;
            AutoMapper = mapper;
        }

        Task<RigOapChecklistGroupAsset> IRequestHandler<UpdateRigOapChecklistGroupAssetRequest, RigOapChecklistGroupAsset>.Handle(UpdateRigOapChecklistGroupAssetRequest request, CancellationToken cancellationToken)
        {
            var existingCheckList = RigOapChecklistGroupAssetService.Get(request.RigChecklistGroupAsset.Id);

            if (existingCheckList == null)
            {
                throw new ApplicationException($"UpdateRigOapChecklistHandler: RigChecklist with Id {request.RigChecklistGroupAsset.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            AutoMapper.Map(request.RigChecklistGroupAsset, existingCheckList);

            using (var ts = new TransactionScope())
            {
                RigOapChecklistGroupAssetService.Update(existingCheckList);

                ts.Complete();
            }
             
            return Task.FromResult(existingCheckList);
        } 
    }
}