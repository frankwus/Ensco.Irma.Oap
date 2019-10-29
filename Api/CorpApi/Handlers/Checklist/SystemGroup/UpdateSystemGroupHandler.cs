using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SystemGroup;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.SystemGroup
{
    public class UpdateSystemGroupHandler : IRequestHandler<UpdateSystemGroupRequest, bool>
    {
        private IOapSystemGroupService SystemGroupService { get; set; }
        private IMapper Mapper { get; set; }
        public UpdateSystemGroupHandler(IOapSystemGroupService systemGroupService, IMapper mapper)
        {
            SystemGroupService = systemGroupService;
            Mapper = mapper;
        }


        Task<bool> IRequestHandler<UpdateSystemGroupRequest, bool>.Handle(UpdateSystemGroupRequest request, CancellationToken cancellationToken)
        {
            var existingSystemGroup = SystemGroupService.Get(request.SystemGroup.Name);

            if (existingSystemGroup == null)
            {
                throw new ApplicationException($"UpdateSystemGroupHandler: SystemGroup with Name {request.SystemGroup.Name} does not exist.");
            }

            var checkDuplicate = SystemGroupService.Get(request.SystemGroup);
            if (checkDuplicate != null )
            {
                throw new ApplicationException($"UpdateSystemGroupHandler: SystemGroup with Name {request.SystemGroup.Name} already exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.SystemGroup, existingSystemGroup);

            using (var ts = new TransactionScope())
            {
                var updatedSystemGroup = SystemGroupService.Update(existingSystemGroup);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}