using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;


namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question
{
    public class UpdateChecklistQuestionRequest : IRequest<bool>
    {
        public UpdateChecklistQuestionRequest(OapChecklistQuestion question)
        {
            Question = question;
        }

        public OapChecklistQuestion Question { get;  }
    }
}