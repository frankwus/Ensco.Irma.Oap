using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Layout
{
    using Ensco.Irma.Extensions;

    public class UpdateChecklistLayoutHandler : IRequestHandler<UpdateChecklistLayoutRequest, bool>
    {
        private IOapChecklistLayoutService ChecklistLayoutService { get; set; }

        private IMapper Mapper { get; set;  }

        public UpdateChecklistLayoutHandler(IOapChecklistLayoutService checklistLayoutService, IMapper mapper)
        {
            ChecklistLayoutService = checklistLayoutService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistLayoutRequest, bool>.Handle(UpdateChecklistLayoutRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistLayout = ChecklistLayoutService.Get(request.ChecklistLayout.Id);

            if (existingChecklistLayout == null)
            {
                throw new ApplicationException($"UpdateChecklistLayoutHandler: ChecklistLayout with Id {request.ChecklistLayout.Id} does not exist.");
            }
             
            //AutoMapper to Map the fields 
            Mapper.Map(request.ChecklistLayout, existingChecklistLayout);
             
            using (var ts = new TransactionScope())
            {
                var updatedChecklistLayout = ChecklistLayoutService.Update(existingChecklistLayout);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}