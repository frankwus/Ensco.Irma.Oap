using Ensco.Irma.Interfaces.Services.Oap;
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
    public class DeleteAssessorHandler : IRequestHandler<DeleteAssessorRequest, bool>
    {
        private readonly IRigOapChecklistService service;

        public DeleteAssessorHandler(IRigOapChecklistService service)
        {
            this.service = service;
        }
        public Task<bool> Handle(DeleteAssessorRequest request, CancellationToken cancellationToken)
        {
            var result = service.DeleteAssessor(request.Id);
            return Task.FromResult(result);
        }
    }
}