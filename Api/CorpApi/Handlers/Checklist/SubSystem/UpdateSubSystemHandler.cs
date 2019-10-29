using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.SubSystem;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.SubSystem
{
    public class UpdateSubSystemHandler : IRequestHandler<UpdateSubSystemRequest, bool>
    {
        private IOapSubSystemService SubSystemService { get; set; }
        private IMapper Mapper { get; set; }
        public UpdateSubSystemHandler(IOapSubSystemService subSystemService,IMapper mapper)
        {
            SubSystemService = subSystemService;
            Mapper = mapper;
        }



        Task<bool> IRequestHandler<UpdateSubSystemRequest, bool>.Handle(UpdateSubSystemRequest request, CancellationToken cancellationToken)
        {
            var existingSubSystem = SubSystemService.Get(request.SubSystem.Name);

            if (existingSubSystem == null)
            {
                throw new ApplicationException($"UpdateSystemHandler: System with Name {request.SubSystem.Name} does not exist.");
            }

            var checkDuplicate = SubSystemService.Get(request.SubSystem);
            if (checkDuplicate != null )
            {
                throw new ApplicationException($"UpdateSystemHandler: System with Name {request.SubSystem.Name} already exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.SubSystem, existingSubSystem);

            using (var ts = new TransactionScope())
            {
                var updatedSubSystem = SubSystemService.Update(existingSubSystem);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}