using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SubSystem;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.SubSystem
{
    public class AddSubSystemHandler : IRequestHandler<AddSubSystemRequest, OapSubSystem>
    {
        private IOapSubSystemService SubSystemService { get; set; }

        public AddSubSystemHandler(IOapSubSystemService subSystemService)
        {
            SubSystemService = subSystemService;
        }

        Task<OapSubSystem> IRequestHandler<AddSubSystemRequest, OapSubSystem>.Handle(AddSubSystemRequest request, CancellationToken cancellationToken)
        {
            var existingSubSystem = SubSystemService.Get(request.SubSystem.Name); 
            if (existingSubSystem != null)
            {     
                return Task.FromResult((OapSubSystem) null);
            }

            int newSubSystemId = 0;
            using (var ts = new TransactionScope())
            {
                newSubSystemId = SubSystemService.Add(request.SubSystem);

                ts.Complete();
            }
            return Task.FromResult(SubSystemService.Get(newSubSystemId));
        }
              
    }
}