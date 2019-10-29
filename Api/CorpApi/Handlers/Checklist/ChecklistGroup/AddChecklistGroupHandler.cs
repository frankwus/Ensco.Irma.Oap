using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistGroup
{
    public class AddChecklistGroupHandler : IRequestHandler<AddChecklistGroupRequest, OapChecklistGroup>
    {
        private IOapChecklistGroupService ChecklistGroupService { get; set; }

        public AddChecklistGroupHandler(IOapChecklistGroupService checklistGroupService)
        {
            ChecklistGroupService = checklistGroupService;
        }

        Task<OapChecklistGroup> IRequestHandler<AddChecklistGroupRequest, OapChecklistGroup>.Handle(AddChecklistGroupRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistGroup = ChecklistGroupService.GetByName(request.ChecklistGroup.Name);
            if (existingChecklistGroup  != null)
            {
                return Task.FromResult(existingChecklistGroup);
            }

            int newChecklistGroupId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.ChecklistGroup.StartDateTime.IsDefaultMin() || request.ChecklistGroup.StartDateTime.IsDefaultMax())
                {
                    request.ChecklistGroup.StartDateTime = DateTime.Now;
                }

                if (request.ChecklistGroup.EndDateTime.IsDefaultMin())
                {
                    request.ChecklistGroup.EndDateTime = DateTime.MaxValue;
                }

                newChecklistGroupId = ChecklistGroupService.Add(request.ChecklistGroup); 
                
                ts.Complete();
            }
            return Task.FromResult(ChecklistGroupService.Get(newChecklistGroupId));
        }

         
    }
}