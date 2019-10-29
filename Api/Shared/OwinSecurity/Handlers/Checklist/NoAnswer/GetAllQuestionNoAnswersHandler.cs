using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist
{
    public class GetAllQuestionNoAnswersHandler : IRequestHandler<GetAllQuestionNoAnswersRequest, IEnumerable<RigOapChecklistQuestionNoAnswerComment>>
    {
        private readonly IRigOapChecklistQuestionNoAnswerCommentService service;

        public GetAllQuestionNoAnswersHandler(IRigOapChecklistQuestionNoAnswerCommentService service)
        {
            this.service = service;
        }
        public Task<IEnumerable<RigOapChecklistQuestionNoAnswerComment>> Handle(GetAllQuestionNoAnswersRequest request, CancellationToken cancellationToken)
        {
            var result = service.GetByOapQuestionId(request.OapChecklistQuestionId);
            return Task.FromResult(result);
        }
    }
}
