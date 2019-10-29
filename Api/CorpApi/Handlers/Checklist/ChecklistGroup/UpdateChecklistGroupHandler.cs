using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistGroup;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistGroup
{
    public class UpdateChecklistGroupHandler : IRequestHandler<UpdateChecklistGroupRequest, bool>
    {
        private IOapChecklistGroupService ChecklistGroupService { get; set; }
         

        private IMapper Mapper { get; set;  }

        public UpdateChecklistGroupHandler(IOapChecklistGroupService checklistGroupService, IMapper mapper)
        {
            ChecklistGroupService = checklistGroupService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistGroupRequest, bool>.Handle(UpdateChecklistGroupRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistGroup = ChecklistGroupService.Get(request.ChecklistGroup.Id);

            if (existingChecklistGroup == null)
            {
                throw new ApplicationException($"UpdateChecklistGroupHandler: ChecklistGroup with Id {request.ChecklistGroup.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.ChecklistGroup, existingChecklistGroup);

            using (var ts = new TransactionScope())
            {
                var updatedChecklistGroup = ChecklistGroupService.Update(existingChecklistGroup);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}