using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SubSystem;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.SubSystem
{
    public class DeleteSubSystemHandler : IRequestHandler<DeleteSubSystemRequest, bool>
    {
        private IOapSubSystemService SubSystemService { get; set; }

        public DeleteSubSystemHandler(IOapSubSystemService subSystemService)
        {
            SubSystemService = subSystemService;
        }


        Task<bool> IRequestHandler<DeleteSubSystemRequest, bool>.Handle(DeleteSubSystemRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var SystemId = SubSystemService.Get(request.SubSystemId);

                SubSystemService.Delete(SystemId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}