using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionRelatedQuestionMap;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionRelatedQuestionMap
{
    public class AddQuestionRelatedQuestionMapHandler : IRequestHandler<AddQuestionRelatedQuestionMapRequest, OapCheckListQuestionRelatedQuestionMap>
    {
        private IOapChecklistQuestionRelatedQuestionMapService QuestionRelatedQuestionMapService { get; set; }

        public AddQuestionRelatedQuestionMapHandler(IOapChecklistQuestionRelatedQuestionMapService questionRelatedQuestionMapService)
        {
            QuestionRelatedQuestionMapService = questionRelatedQuestionMapService;
        }

        Task<OapCheckListQuestionRelatedQuestionMap> IRequestHandler<AddQuestionRelatedQuestionMapRequest, OapCheckListQuestionRelatedQuestionMap>.Handle(AddQuestionRelatedQuestionMapRequest request, CancellationToken cancellationToken)
        {
            var existingQuestionRelatedQuestion = QuestionRelatedQuestionMapService.GetRelatedQuestions(request.QuestionRelatedQuestionMap.OapChecklistQuestionId)?.ToList().FirstOrDefault(q => q.Id == request.QuestionRelatedQuestionMap.OapChecklistRelatedQuestionId)  ;
            if (existingQuestionRelatedQuestion != null)
            {
                //return Task.FromResult(request.QuestionRelatedQuestionMap);
                return Task.FromResult((OapCheckListQuestionRelatedQuestionMap) null);
            }

            int newRelatedQuestionMapId = 0;
            using (var ts = new TransactionScope())
            {
                if (request.QuestionRelatedQuestionMap.OapChecklistQuestionId != request.QuestionRelatedQuestionMap.OapChecklistRelatedQuestionId)
                {
                    newRelatedQuestionMapId = QuestionRelatedQuestionMapService.Add(request.QuestionRelatedQuestionMap);

                    ts.Complete();
                }              
            }
            return Task.FromResult(QuestionRelatedQuestionMapService.Get(newRelatedQuestionMapId));
        }
    }
}