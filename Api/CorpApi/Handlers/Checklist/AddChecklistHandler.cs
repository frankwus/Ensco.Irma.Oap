using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist
{
    public class AddChecklistHandler : IRequestHandler<AddChecklistRequest, OapChecklist>
    {
        private IOapChecklistService ChecklistService { get; set; }

        private IOapChecklistTopicService TopiclistService { get; set; }
        private IOapHierarchyService HierarchyService { get; set; }

        public AddChecklistHandler(IOapChecklistService checklistService, IOapChecklistTopicService topiclistService, IOapHierarchyService hierarchyService)
        {
            ChecklistService = checklistService;
            TopiclistService = topiclistService;
#pragma warning disable CS1717 // Assignment made to same variable
            HierarchyService = hierarchyService;
#pragma warning restore CS1717 // Assignment made to same variable
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