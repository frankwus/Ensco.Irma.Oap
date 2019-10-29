using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTag;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionTag
{
    public class UpdateQuestionTagHandler : IRequestHandler<UpdateQuestionTagRequest, bool>
    {
        private IOapChecklistQuestionTagService QuestionTagService { get; set; }


        private IMapper Mapper { get; set; }

        public UpdateQuestionTagHandler(IOapChecklistQuestionTagService questionTagService, IMapper mapper)
        {
            QuestionTagService = questionTagService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateQuestionTagRequest, bool>.Handle(UpdateQuestionTagRequest request, CancellationToken cancellationToken)
        {
            var existingQuestionTag = QuestionTagService.Get(request.QuestionTag.Id);

            if (existingQuestionTag == null)
            {
                throw new ApplicationException($"UpdateQuestionTagHandler: QuestionTag with Id {request.QuestionTag.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.QuestionTag, existingQuestionTag);

            using (var ts = new TransactionScope())
            {
                var updatedQuestionTag = QuestionTagService.Update(existingQuestionTag);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}