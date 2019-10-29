using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig.ThirdPartyJob;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class AddRigOapChecklistThirdPartyJobHandler : IRequestHandler<AddRigOapChecklistThirdPartyJobRequest, RigOapChecklistThirdPartyJob>
    {
        private IRigOapChecklistThirdPartyJobService RigOapChecklistThirdPartyJobService { get; set; }


        public AddRigOapChecklistThirdPartyJobHandler(IRigOapChecklistThirdPartyJobService rigOapChecklistQuestionCommentService)
        {
            RigOapChecklistThirdPartyJobService = rigOapChecklistQuestionCommentService;
        }

        Task<RigOapChecklistThirdPartyJob> IRequestHandler<AddRigOapChecklistThirdPartyJobRequest, RigOapChecklistThirdPartyJob>.Handle(AddRigOapChecklistThirdPartyJobRequest request, CancellationToken cancellationToken)
        {
            Guid rigChecklistThirdPartyJobId = Guid.Empty;

            using (var ts = new TransactionScope())
            {
                rigChecklistThirdPartyJobId = RigOapChecklistThirdPartyJobService.Add(request.ThirdPartyJob);

                ts.Complete();
            }

            var rigoapChecklistThirdPartyJob = RigOapChecklistThirdPartyJobService.Get(rigChecklistThirdPartyJobId);

            return Task.FromResult(rigoapChecklistThirdPartyJob);
        }


        
    }
}