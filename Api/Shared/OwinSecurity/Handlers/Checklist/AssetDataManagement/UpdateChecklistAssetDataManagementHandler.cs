using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.AssetDataManagement
{
    public class UpdateChecklistAssetDataManagementHandler : IRequestHandler<UpdateChecklistAssetDataManagementRequest, bool>
    {
        private IOapChecklistAssetDataManagementService AssetDataManagementService { get; set; }


        private IMapper Mapper { get; set; }

        public UpdateChecklistAssetDataManagementHandler(IOapChecklistAssetDataManagementService assetDataManagementService, IMapper mapper)
        {
            AssetDataManagementService = assetDataManagementService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistAssetDataManagementRequest, bool>.Handle(UpdateChecklistAssetDataManagementRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistAssetDataManagement = AssetDataManagementService.Get(request.AssetDataManagementChecklist.Id);

            if (existingChecklistAssetDataManagement == null)
            {
                throw new ApplicationException($"UpdateChecklistAssetDataManagementHandler: ChecklistAssetDataManagement with Id {request.AssetDataManagementChecklist.Id} does not exist.");
            }            

            //AutoMapper to Map the fields 
            Mapper.Map(request.AssetDataManagementChecklist, existingChecklistAssetDataManagement);

            using (var ts = new TransactionScope())
            {
                var updatedQuestionTagMap = AssetDataManagementService.Update(existingChecklistAssetDataManagement);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}