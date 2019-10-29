using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question
{
    public class AddChecklistQuestionRequest : IRequest<OapChecklistQuestion>
    {
        public AddChecklistQuestionRequest(OapChecklistQuestion question)
        {
            Question = question;
        }

        public OapChecklistQuestion Question { get;  }
    }
}