using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.System;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.System
{
    public class UpdateSystemHandler : IRequestHandler<UpdateSystemRequest, bool>
    {
        private IOapSystemService SystemService { get; set; }
        private IMapper Mapper { get; set; }
        public UpdateSystemHandler(IOapSystemService systemService, IMapper mapper)
        {
            SystemService = systemService;
            Mapper = mapper;
        }


        Task<bool> IRequestHandler<UpdateSystemRequest, bool>.Handle(UpdateSystemRequest request, CancellationToken cancellationToken)
        {
            var existingSystem = SystemService.Get(request.System.Name);

            if (existingSystem == null)
            {
                throw new ApplicationException($"UpdateSystemHandler: System with Name {request.System.Name} does not exist.");
            }

            var checkDuplicate = SystemService.Get(request.System);
            if (checkDuplicate != null )
            {
                throw new ApplicationException($"UpdateSystemHandler: System with Name {request.System.Name} already exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.System, existingSystem);

            using (var ts = new TransactionScope())
            {
                var updatedSystem = SystemService.Update(existingSystem);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}