using System.Threading;
using System.Threading.Tasks;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class UpdateProtocolAnswerHandler : IRequest<bool>
    {
        private readonly IRigOapChecklistService service;

        public UpdateProtocolAnswerHandler(IRigOapChecklistService service)
        {
            this.service = service;
        }

        public Task<bool> Handle(UpdateProtocolAnswerRequest request, CancellationToken cancellationToken)
        {
            var result = service.UpdateRigChecklistAnswers(request.Answers);
            return Task.FromResult(result);
        }
    }
}