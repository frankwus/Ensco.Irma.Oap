using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionTag
{
    public class AddQuestionTagHandler : IRequestHandler<AddQuestionTagRequest, OapChecklistQuestionTag>
    {
        private IOapChecklistQuestionTagService QuestionTagService { get; set; }

        public AddQuestionTagHandler(IOapChecklistQuestionTagService questionTagService)
        {
            QuestionTagService = questionTagService;
        }

        Task<OapChecklistQuestionTag> IRequestHandler<AddQuestionTagRequest, OapChecklistQuestionTag>.Handle(AddQuestionTagRequest request, CancellationToken cancellationToken)
        {
            var existingQuestionTag = QuestionTagService.GetByTag(request.QuestionTag.Tag);
            if (existingQuestionTag != null)
            {
                return Task.FromResult(existingQuestionTag);
            }

            int newQuestionTagId = 0;
            using (var ts = new TransactionScope())
            {
                newQuestionTagId = QuestionTagService.Add(request.QuestionTag);

                ts.Complete();
            }
            return Task.FromResult(QuestionTagService.Get(newQuestionTagId));
        }
    }
}