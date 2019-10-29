using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.System;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.System
{
    public class AddSystemHandler : IRequestHandler<AddSystemRequest, OapSystem>
    {
        private IOapSystemService SystemService { get; set; }

        public AddSystemHandler(IOapSystemService systemService)
        {
              SystemService = systemService;
        }

        Task<OapSystem> IRequestHandler<AddSystemRequest, OapSystem>.Handle(AddSystemRequest request, CancellationToken cancellationToken)
        {
            var existingSystem = SystemService.Get(request.System.Name); 
            if (existingSystem != null)
            {     
                return Task.FromResult((OapSystem) null);
            }

            int newSystemId = 0;
            using (var ts = new TransactionScope())
            {
                newSystemId = SystemService.Add(request.System);

                ts.Complete();
            }
            return Task.FromResult(SystemService.Get(newSystemId));
        }
              
    }
}