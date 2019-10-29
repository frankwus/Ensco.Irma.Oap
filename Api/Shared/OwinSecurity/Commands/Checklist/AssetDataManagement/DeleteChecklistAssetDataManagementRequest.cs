using MediatR;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.AssetDataManagement
{
    public class DeleteChecklistAssetDataManagementRequest : IRequest<bool>
    {
        public DeleteChecklistAssetDataManagementRequest(int admChecklistId)
        {
            AdmChecklistId = admChecklistId;
        }

        public int AdmChecklistId { get; set; }
    }
}