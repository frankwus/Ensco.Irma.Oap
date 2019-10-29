using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionTagMap
{
    public class AddQuestionTagMapHandler : IRequestHandler<AddQuestionTagMapRequest, OapChecklistQuestionTagMap>
    {
        private IOapChecklistQuestionTagMapService QuestionTagMapService { get; set; }

        public AddQuestionTagMapHandler(IOapChecklistQuestionTagMapService questionTagMapService)
        {
            QuestionTagMapService = questionTagMapService;
        }

        Task <OapChecklistQuestionTagMap> IRequestHandler<AddQuestionTagMapRequest, OapChecklistQuestionTagMap>.Handle(AddQuestionTagMapRequest request, CancellationToken cancellationToken)
        {
            var existingQuestionTag = QuestionTagMapService.GetByQuestionTag(request.QuestionTagMap.OapChecklistQuestionId,request.QuestionTagMap.OapChecklistQuestionTagId);
            if (existingQuestionTag != null)
            {
                return Task.FromResult(existingQuestionTag);
            }

            int newQuestionTagMapId = 0;
            using (var ts = new TransactionScope())
            {
                newQuestionTagMapId = QuestionTagMapService.Add(request.QuestionTagMap);

                ts.Complete();
            }
            return Task.FromResult(QuestionTagMapService.Get(newQuestionTagMapId));
        }
    }
}