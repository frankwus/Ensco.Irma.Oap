using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist
{
    public class AddChecklistHandler : IRequestHandler<AddChecklistRequest, OapChecklist>
    {
        private IOapChecklistService ChecklistService { get; set; }

        public AddChecklistHandler(IOapChecklistService checklistService)
        {
            ChecklistService = checklistService; 
        }

        Task<OapChecklist> IRequestHandler<AddChecklistRequest, OapChecklist>.Handle(AddChecklistRequest request, CancellationToken cancellationToken)
        {

            var existingChecklist = ChecklistService.GetByName(request.Checklist.Name);
            if (existingChecklist != null)
            {
                return Task.FromResult(existingChecklist);
            }


            int newChecklistId = 0;
            using (var ts = new TransactionScope())
            {
                newChecklistId = ChecklistService.Add(request.Checklist); 
                
                ts.Complete();
            }
            return Task.FromResult(ChecklistService.Get(newChecklistId));
        }
    }
}