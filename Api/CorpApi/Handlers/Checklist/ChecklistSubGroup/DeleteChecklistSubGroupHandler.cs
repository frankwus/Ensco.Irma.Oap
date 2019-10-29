using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistSubGroup
{
    public class DeleteChecklistSubGroupHandler : IRequestHandler<DeleteChecklistSubGroupRequest, bool>
    {
        private IOapChecklistSubGroupService ChecklistSubGroupService { get; set; }

        public DeleteChecklistSubGroupHandler(IOapChecklistSubGroupService checklistSubGroupService)
        {
            ChecklistSubGroupService = checklistSubGroupService;
        }

        Task<bool> IRequestHandler<DeleteChecklistSubGroupRequest, bool>.Handle(DeleteChecklistSubGroupRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ChecklistSubGroup = ChecklistSubGroupService.Get(request.ChecklistSubGroupId);
                 
                ChecklistSubGroupService.Delete(ChecklistSubGroup);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}