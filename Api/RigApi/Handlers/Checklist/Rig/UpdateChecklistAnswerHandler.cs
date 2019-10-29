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
    public class UpdateChecklistAnswerHandler : IRequestHandler<UpdateChecklistAnswerRequest, bool>
    {
        private readonly IRigOapChecklistService service;

        public UpdateChecklistAnswerHandler(IRigOapChecklistService service)
        {
            this.service = service;
        }

        public Task<bool> Handle(UpdateChecklistAnswerRequest request, CancellationToken cancellationToken)
        {
            var result = service.UpdateRigChecklistAnswers(request.Answers);
            return Task.FromResult(result);
        }
    }
}