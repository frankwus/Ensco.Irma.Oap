using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.LayoutColumn
{
    using Ensco.Irma.Extensions;

    public class UpdateChecklistLayoutColumnHandler : IRequestHandler<UpdateChecklistLayoutColumnRequest, bool>
    {
        private IOapChecklistLayoutColumnService ChecklistLayoutColumnService { get; set; }

        private IMapper Mapper { get; set;  }

        public UpdateChecklistLayoutColumnHandler(IOapChecklistLayoutColumnService checklistLayoutColumnService, IMapper mapper)
        {
            ChecklistLayoutColumnService = checklistLayoutColumnService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistLayoutColumnRequest, bool>.Handle(UpdateChecklistLayoutColumnRequest request, CancellationToken cancellationToken)
        {
            var existingChecklistLayoutColumn = ChecklistLayoutColumnService.Get(request.ChecklistLayoutColumn.Id);

            if (existingChecklistLayoutColumn == null)
            {
                throw new ApplicationException($"UpdateChecklistLayoutColumnHandler: ChecklistLayoutColumn with Id {request.ChecklistLayoutColumn.Id} does not exist.");
            }
             
            //AutoMapper to Map the fields 
            Mapper.Map(request.ChecklistLayoutColumn, existingChecklistLayoutColumn);
             
            using (var ts = new TransactionScope())
            {
                var updatedChecklistLayoutColumn = ChecklistLayoutColumnService.Update(existingChecklistLayoutColumn);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}