using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SystemGroup;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.SystemGroup
{
    public class DeleteSystemGroupHandler : IRequestHandler<DeleteSystemGroupRequest, bool>
    {
        private IOapSystemGroupService SystemGroupService { get; set; }

        public DeleteSystemGroupHandler(IOapSystemGroupService systemGroupService)
        {
            SystemGroupService = systemGroupService;
        }


        Task<bool> IRequestHandler<DeleteSystemGroupRequest, bool>.Handle(DeleteSystemGroupRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var systemGroupId = SystemGroupService.Get(request.SystemGroupId);

                SystemGroupService.Delete(systemGroupId);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}