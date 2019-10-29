using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class DeleteRigOapChecklistHandler : IRequestHandler<DeleteRigOapChecklistRequest, bool>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }

        public DeleteRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        Task<bool> IRequestHandler<DeleteRigOapChecklistRequest, bool>.Handle(DeleteRigOapChecklistRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var rigOapChecklist = RigOapChecklistService.Get(request.RigChecklistId);
                 
                RigOapChecklistService.Delete(rigOapChecklist);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}