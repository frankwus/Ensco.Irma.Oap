using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist
{
    public class UpdateChecklistHandler : IRequestHandler<UpdateChecklistRequest, bool>
    {
        private IOapChecklistService ChecklistService { get; set; }

        private IOapChecklistTopicService TopiclistService { get; set; }

        private IMapper Mapper { get; set;  }

        public UpdateChecklistHandler(IOapChecklistService checklistService, IOapChecklistTopicService topiclistService, IMapper mapper)
        {
            ChecklistService = checklistService;
            TopiclistService = topiclistService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistRequest, bool>.Handle(UpdateChecklistRequest request, CancellationToken cancellationToken)
        {
            var existingCheckList = ChecklistService.Get(request.Checklist.Id);

            if (existingCheckList == null)
            {
                throw new ApplicationException($"UpdateChecklistHandler: Checklist with Id {request.Checklist.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.Checklist, existingCheckList);

            using (var ts = new TransactionScope())
            {
                var updatedChecklist = ChecklistService.Update(existingCheckList);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}