using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class UpdateChecklistAnswerRequest : IRequest<bool>
    {
        public UpdateChecklistAnswerRequest(IEnumerable<RigOapChecklistQuestionAnswer> answers)
        {            
            Answers = answers;
        }        
        public IEnumerable<RigOapChecklistQuestionAnswer> Answers { get; }
    }
}