using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Handlers.Checklist.Rig
{
    public class AddAssessorChecklistHandler : IRequestHandler<AddAssessorRequest, RigOapChecklist>
    {
        private readonly IRigOapChecklistService service;

        public AddAssessorChecklistHandler(IRigOapChecklistService service)
        {
            this.service = service;
        }
        public Task<RigOapChecklist> Handle(AddAssessorRequest request, CancellationToken cancellationToken)
        {
            request.Assessor.RigOapChecklistId = request.RigOapChecklistId;
            var result = service.AddAssessor(request.Assessor);
            return Task.FromResult(result);
        }
    }
}