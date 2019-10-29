using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.QuestionTag
{
    public class GetQuestionTagHandler : IRequestHandler<GetQuestionTagRequest, OapChecklistQuestionTag>
    {
        private IOapChecklistQuestionTagService QuestionTagService { get; set; }

        public GetQuestionTagHandler(IOapChecklistQuestionTagService questionTagService)
        {
            QuestionTagService = questionTagService;
        }    

        Task<OapChecklistQuestionTag> IRequestHandler<GetQuestionTagRequest, OapChecklistQuestionTag>.Handle(GetQuestionTagRequest request, CancellationToken cancellationToken)
        {
            var tag = QuestionTagService.Get(request.QuestionTagId);
            return Task.FromResult(tag);
        }
    }
}