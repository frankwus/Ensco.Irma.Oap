using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.System;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.System
{
    public class DeleteSystemHandler : IRequestHandler<DeleteSystemRequest, bool>
    {
        private IOapSystemService SystemService { get; set; }

        public DeleteSystemHandler(IOapSystemService systemService)
        {
            SystemService = systemService;
        }


        Task<bool> IRequestHandler<DeleteSystemRequest, bool>.Handle(DeleteSystemRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var SystemId = SystemService.Get(request.SystemId);

                SystemService.Delete(SystemId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}