using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.NoAnswer
{
    public class UpdateQuestionNoAnswerRequest : IRequest<RigOapChecklistQuestionNoAnswerComment>
    {
        public UpdateQuestionNoAnswerRequest(RigOapChecklistQuestionNoAnswerComment model)
        {
            Model = model;
        }

        public RigOapChecklistQuestionNoAnswerComment Model { get; }
    }
}
