using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistWorkInstruction;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.ChecklistWorkInstruction
{
    public class GetAllChecklistWorkInstructionHandler : IRequestHandler<GetAllChecklistWorkInstructionRequest, IEnumerable<OapChecklistWorkInstruction>>
    {

        private IOapChecklistWorkInstructionService WorkInstructionService { get; set; }

        public GetAllChecklistWorkInstructionHandler(IOapChecklistWorkInstructionService workInstructionService)
        {
            WorkInstructionService = workInstructionService;
        }
        Task<IEnumerable<OapChecklistWorkInstruction>> IRequestHandler<GetAllChecklistWorkInstructionRequest, IEnumerable<OapChecklistWorkInstruction>>.Handle(GetAllChecklistWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            var checklistWorkInstruction = WorkInstructionService.GetAll();  
            return Task.FromResult(checklistWorkInstruction);
        }
    }
}