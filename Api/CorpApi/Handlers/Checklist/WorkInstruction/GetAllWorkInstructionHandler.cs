using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.WorkInstruction;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.WorkInstruction
{
    public class GetAllWorkInstructionHandler : IRequestHandler<GetAllWorkInstructionRequest, IEnumerable<OapWorkInstruction>>
    {
        private IOapWorkInstructionService WorkInstructionService { get; set; }

        public GetAllWorkInstructionHandler(IOapWorkInstructionService workInstructionService)
        {
            WorkInstructionService = workInstructionService;
        }


        Task<IEnumerable<OapWorkInstruction>> IRequestHandler<GetAllWorkInstructionRequest, IEnumerable<OapWorkInstruction>>.Handle(GetAllWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            var list = WorkInstructionService.GetAll();
            return Task.FromResult(list);
        }

    }
}