using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SystemGroup;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.SystemGroup
{
    public class AddSystemGroupHandler : IRequestHandler<AddSystemGroupRequest, OapSystemGroup>
    {
        private IOapSystemGroupService SystemGroupService { get; set; }

        public AddSystemGroupHandler(IOapSystemGroupService systemGroupService)
        {
            SystemGroupService = systemGroupService;
        }

        Task<OapSystemGroup> IRequestHandler<AddSystemGroupRequest, OapSystemGroup>.Handle(AddSystemGroupRequest request, CancellationToken cancellationToken)
        {
            var existingSystemGroup = SystemGroupService.Get(request.SystemGroup.Name); 
            if (existingSystemGroup != null)
            {     
                return Task.FromResult((OapSystemGroup) null);
            }

            int newSystemGroupId = 0;
            using (var ts = new TransactionScope())
            {
                newSystemGroupId = SystemGroupService.Add(request.SystemGroup);

                ts.Complete();
            }
            return Task.FromResult(SystemGroupService.Get(newSystemGroupId));
        }
              
    }
}