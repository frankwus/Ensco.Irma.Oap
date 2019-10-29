using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Layout
{
    using Ensco.Irma.Extensions;

    public class AddChecklistLayoutHandler : IRequestHandler<AddChecklistLayoutRequest, OapChecklistLayout>
    {
        private IOapChecklistLayoutService ChecklistLayoutService { get; set; }

        public AddChecklistLayoutHandler(IOapChecklistLayoutService checklistLayoutService)
        {
            ChecklistLayoutService = checklistLayoutService;
        }

        Task<OapChecklistLayout> IRequestHandler<AddChecklistLayoutRequest, OapChecklistLayout>.Handle(AddChecklistLayoutRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistLayout = ChecklistLayoutService.Get(request.ChecklistLayout.Id);
            if (existingChecklistLayout  != null)
            {
                return Task.FromResult(existingChecklistLayout);
            }

            int newChecklistLayoutId = 0;
            using (var ts = new TransactionScope())
            {
                newChecklistLayoutId = ChecklistLayoutService.Add(request.ChecklistLayout); 
                
                ts.Complete();
            }
            return Task.FromResult(ChecklistLayoutService.Get(newChecklistLayoutId));
        }

         
    }
}