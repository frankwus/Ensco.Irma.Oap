using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistSubGroup
{
    public class UpdateChecklistSubGroupHandler : IRequestHandler<UpdateChecklistSubGroupRequest, bool>
    {
        private IOapChecklistSubGroupService ChecklistSubGroupService { get; set; }
         

        private IMapper Mapper { get; set;  }

        public UpdateChecklistSubGroupHandler(IOapChecklistSubGroupService checklistSubGroupService, IMapper mapper)
        {
            ChecklistSubGroupService = checklistSubGroupService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistSubGroupRequest, bool>.Handle(UpdateChecklistSubGroupRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistSubGroup = ChecklistSubGroupService.Get(request.ChecklistSubGroup.Id);

            if (existingChecklistSubGroup == null)
            {
                throw new ApplicationException($"UpdateChecklistSubGroupHandler: ChecklistSubGroup with Id {request.ChecklistSubGroup.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.ChecklistSubGroup, existingChecklistSubGroup);

            using (var ts = new TransactionScope())
            {
                var updatedChecklistSubGroup = ChecklistSubGroupService.Update(existingChecklistSubGroup);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}