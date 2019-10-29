using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistGroup
{
    public class DeleteChecklistGroupHandler : IRequestHandler<DeleteChecklistGroupRequest, bool>
    {
        private IOapChecklistGroupService ChecklistGroupService { get; set; }

        public DeleteChecklistGroupHandler(IOapChecklistGroupService checklistGroupService)
        {
            ChecklistGroupService = checklistGroupService;
        }

        Task<bool> IRequestHandler<DeleteChecklistGroupRequest, bool>.Handle(DeleteChecklistGroupRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var ChecklistGroup = ChecklistGroupService.Get(request.ChecklistGroupId);
                 
                ChecklistGroupService.Delete(ChecklistGroup);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}