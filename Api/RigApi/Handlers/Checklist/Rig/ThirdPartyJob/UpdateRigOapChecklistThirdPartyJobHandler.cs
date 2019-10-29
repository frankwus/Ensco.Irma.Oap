using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using System.Linq;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class UpdateRigOapChecklistThirdPartyJobHandler : IRequestHandler<UpdateRigOapChecklistThirdPartyJobRequest, RigOapChecklistThirdPartyJob>
    {
        private IRigOapChecklistThirdPartyJobService RigOapChecklistThirdPartyJobService { get; set; }
        public IMapper AutoMapper { get; }

        public UpdateRigOapChecklistThirdPartyJobHandler(IRigOapChecklistThirdPartyJobService rigOapChecklistThirdPartyJobService, IMapper mapper)
        {
            RigOapChecklistThirdPartyJobService = rigOapChecklistThirdPartyJobService;
            AutoMapper = mapper;
        }

        Task<RigOapChecklistThirdPartyJob> IRequestHandler<UpdateRigOapChecklistThirdPartyJobRequest, RigOapChecklistThirdPartyJob>.Handle(UpdateRigOapChecklistThirdPartyJobRequest request, CancellationToken cancellationToken)
        {
            var existingCheckList = RigOapChecklistThirdPartyJobService.Get(request.RigChecklistThirdPartyJob.Id);

            if (existingCheckList == null)
            {
                throw new ApplicationException($"{GetType().Name}: RigChecklist with Id {request.RigChecklistThirdPartyJob.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            AutoMapper.Map(request.RigChecklistThirdPartyJob, existingCheckList);

            using (var ts = new TransactionScope())
            {
                RigOapChecklistThirdPartyJobService.Update(existingCheckList);

                ts.Complete();
            }
             
            return Task.FromResult(existingCheckList);
        } 
    }
}