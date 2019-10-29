using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist.NoAnswer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.NoAnswer
{
    public class GetFirstQuestionOpenNoAnswersHandler : IRequestHandler<GetFirstQuestionOpenNoAnswersRequest, RigOapChecklistQuestionNoAnswerComment>
    {
        private readonly IRigOapChecklistQuestionNoAnswerCommentService service;

        public GetFirstQuestionOpenNoAnswersHandler(IRigOapChecklistQuestionNoAnswerCommentService service)
        {
            this.service = service;
        }
        public Task<RigOapChecklistQuestionNoAnswerComment> Handle(GetFirstQuestionOpenNoAnswersRequest request, CancellationToken cancellationToken)
        {
            var result = service.GetOpenNoAnswers(request.OapChecklistId, request.OapChecklistQuestionId).FirstOrDefault();
            return Task.FromResult(result);
        }
    }
}
