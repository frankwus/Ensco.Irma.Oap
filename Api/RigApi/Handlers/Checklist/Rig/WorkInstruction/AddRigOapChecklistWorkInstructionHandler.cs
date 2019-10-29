using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.WorkInstruction;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class AddRigOapChecklistWorkInstructionHandler : IRequestHandler<AddRigOapChecklistWorkInstructionRequest, RigOapChecklistWorkInstruction>
    {
        private IRigOapChecklistWorkInstructionService RigOapChecklistWorkInstructionService { get; set; }


        public AddRigOapChecklistWorkInstructionHandler(IRigOapChecklistWorkInstructionService rigOapChecklistQuestionCommentService)
        {
            RigOapChecklistWorkInstructionService = rigOapChecklistQuestionCommentService;
        }

        Task<RigOapChecklistWorkInstruction> IRequestHandler<AddRigOapChecklistWorkInstructionRequest, RigOapChecklistWorkInstruction>.Handle(AddRigOapChecklistWorkInstructionRequest request, CancellationToken cancellationToken)
        {
            Guid rigChecklistWorkInstructionId = Guid.Empty;

            using (var ts = new TransactionScope())
            {
                rigChecklistWorkInstructionId = RigOapChecklistWorkInstructionService.Add(request.WorkInstruction);

                ts.Complete();
            }

            var rigoapChecklistWorkInstruction = RigOapChecklistWorkInstructionService.Get(rigChecklistWorkInstructionId);

            return Task.FromResult(rigoapChecklistWorkInstruction);
        }


        
    }
}