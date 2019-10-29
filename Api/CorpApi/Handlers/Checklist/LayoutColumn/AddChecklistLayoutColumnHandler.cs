using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.LayoutColumn
{
    using Ensco.Irma.Extensions;

    public class AddChecklistLayoutColumnHandler : IRequestHandler<AddChecklistLayoutColumnRequest, OapChecklistLayoutColumn>
    {
        private IOapChecklistLayoutColumnService ChecklistLayoutColumnService { get; set; }

        public AddChecklistLayoutColumnHandler(IOapChecklistLayoutColumnService checklistLayoutColumnService)
        {
            ChecklistLayoutColumnService = checklistLayoutColumnService;
        }

        Task<OapChecklistLayoutColumn> IRequestHandler<AddChecklistLayoutColumnRequest, OapChecklistLayoutColumn>.Handle(AddChecklistLayoutColumnRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistLayoutColumn = ChecklistLayoutColumnService.Get(request.ChecklistLayoutColumn.Id);
            if (existingChecklistLayoutColumn  != null)
            {
                return Task.FromResult(existingChecklistLayoutColumn);
            }

            int newChecklistLayoutColumnId = 0;
            using (var ts = new TransactionScope())
            {
                newChecklistLayoutColumnId = ChecklistLayoutColumnService.Add(request.ChecklistLayoutColumn); 
                
                ts.Complete();
            }
            return Task.FromResult(ChecklistLayoutColumnService.Get(newChecklistLayoutColumnId));
        }

         
    }
}