using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionTag
{
    public class GetAllQuestionTagHandler : IRequestHandler<GetAllQuestionTagRequest, IEnumerable<OapChecklistQuestionTag>>
    {

        private IOapChecklistQuestionTagService QuestionTagService { get; set; }

        public GetAllQuestionTagHandler(IOapChecklistQuestionTagService questionTagService)
        {
            QuestionTagService = questionTagService;
        }

        Task<IEnumerable<OapChecklistQuestionTag>> IRequestHandler<GetAllQuestionTagRequest, IEnumerable<OapChecklistQuestionTag>>.Handle(GetAllQuestionTagRequest request, CancellationToken cancellationToken)
        {
            var tags = QuestionTagService.GetAll();
            return Task.FromResult(tags);
        }
    }
}