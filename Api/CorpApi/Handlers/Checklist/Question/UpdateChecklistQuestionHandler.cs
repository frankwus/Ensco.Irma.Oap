using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Mapper;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Question;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Question
{
    public class UpdateChecklistQuestionHandler : IRequestHandler<UpdateChecklistQuestionRequest, bool>
    {
        private IOapChecklistQuestionService QuestionService { get; set; }
         
        private IMapper Mapper { get; set;  }

        public UpdateChecklistQuestionHandler(IOapChecklistQuestionService questionService, IMapper mapper)
        {
            QuestionService = questionService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateChecklistQuestionRequest, bool>.Handle(UpdateChecklistQuestionRequest request, CancellationToken cancellationToken)
        {
            var existingQuestion = QuestionService.Get(request.Question.Id);

            if (existingQuestion == null)
            {
                throw new ApplicationException($"UpdateChecklistQuestionHandler: Question with Id {request.Question.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.Question, existingQuestion);

            Mapper.AddOrUpdate<OapChecklistQuestionTagMap, int>(request.Question.OapChecklistQuestionTagMaps, existingQuestion.OapChecklistQuestionTagMaps, (dl, sq) => dl.SingleOrDefault(i => i.OapChecklistQuestionId == sq.OapChecklistQuestionId));

            using (var ts = new TransactionScope())
            {
                var updatedQuestion = QuestionService.Update(existingQuestion);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}