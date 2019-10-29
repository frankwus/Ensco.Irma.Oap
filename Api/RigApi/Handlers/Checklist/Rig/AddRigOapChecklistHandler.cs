using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Interfaces.Services.Security;
using Ensco.Irma.Interfaces.Services.Workflow;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Security;
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using Ensco.Irma.Oap.Api.Rig.Extensions;
using Ensco.Irma.Services.Workflow.Designers;
using MediatR;
using System;
using System.Activities;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;
using workflow = Ensco.Irma.Models.Domain.Workflow;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class AddRigOapChecklistHandler : IRequestHandler<AddRigOapChecklistRequest, RigOapChecklist>
    {
        private IRigOapChecklistService RigOapChecklistService { get; set; }


        public AddRigOapChecklistHandler(IRigOapChecklistService rigOapChecklistService)
        {
            RigOapChecklistService = rigOapChecklistService;
        }

        Task<RigOapChecklist> IRequestHandler<AddRigOapChecklistRequest, RigOapChecklist>.Handle(AddRigOapChecklistRequest request, CancellationToken cancellationToken)
        {
            Guid rigChecklistId = Guid.Empty;

            using (var ts = new TransactionScope())
            {
                rigChecklistId = RigOapChecklistService.Add(request.Checklist);

                ts.Complete();
            }

            var rigoapChecklist = RigOapChecklistService.GetCompleteChecklist(rigChecklistId);

            return Task.FromResult(rigoapChecklist);
        }
    }
}