using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistSubGroup
{
    public class AddChecklistSubGroupHandler : IRequestHandler<AddChecklistSubGroupRequest, OapChecklistSubGroup>
    {
        private IOapChecklistSubGroupService ChecklistSubGroupService { get; set; }

        public AddChecklistSubGroupHandler(IOapChecklistSubGroupService checklistSubGroupService)
        {
            ChecklistSubGroupService = checklistSubGroupService;
        }

        Task<OapChecklistSubGroup> IRequestHandler<AddChecklistSubGroupRequest, OapChecklistSubGroup>.Handle(AddChecklistSubGroupRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistSubGroup = ChecklistSubGroupService.GetBySubGroupName(request.ChecklistSubGroup.OapChecklistGroupId, request.ChecklistSubGroup.Name);
            if (existingChecklistSubGroup  != null)
            {
                return Task.FromResult(existingChecklistSubGroup);
            }

            int newChecklistSubGroupId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.ChecklistSubGroup.StartDateTime.IsDefaultMin() || request.ChecklistSubGroup.StartDateTime.IsDefaultMax())
                {
                    request.ChecklistSubGroup.StartDateTime = DateTime.Now;
                }

                if (request.ChecklistSubGroup.EndDateTime.IsDefaultMin())
                {
                    request.ChecklistSubGroup.EndDateTime = DateTime.MaxValue;
                }

                newChecklistSubGroupId = ChecklistSubGroupService.Add(request.ChecklistSubGroup); 
                
                ts.Complete();
            }
            return Task.FromResult(ChecklistSubGroupService.Get(newChecklistSubGroupId));
        }

         
    }
}