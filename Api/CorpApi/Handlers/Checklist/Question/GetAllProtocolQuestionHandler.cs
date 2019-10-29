using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Question
{
    public class GetAllProtocolQuestionHandler : IRequestHandler<GetAllProtocolQuestionRequest, IEnumerable<OapChecklistQuestion>>
    {
        private IOapChecklistQuestionService Service { get; set; }

        public GetAllProtocolQuestionHandler(IOapChecklistQuestionService checklistQuestionService)
        {
            Service = checklistQuestionService;
        }

        Task<IEnumerable<OapChecklistQuestion>> IRequestHandler<GetAllProtocolQuestionRequest, IEnumerable<OapChecklistQuestion>>.Handle(GetAllProtocolQuestionRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAllProtocolQuestions(request.StartDate, request.EndDate);
            return Task.FromResult(cl);
        }
    }
}