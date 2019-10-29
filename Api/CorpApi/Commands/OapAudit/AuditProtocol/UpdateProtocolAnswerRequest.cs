using System.Collections.Generic;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.OapAudits.AuditProtocol
{
    public class UpdateProtocolAnswerRequest : IRequest<bool>
    {
        public UpdateProtocolAnswerRequest(IEnumerable<RigOapChecklistQuestionAnswer> answers)
        {            
            Answers = answers;
        }        
        public IEnumerable<RigOapChecklistQuestionAnswer> Answers { get; }
    }
}