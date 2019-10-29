using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionRelatedQuestionMap;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionRelatedQuestionMap
{
    public class UpdateQuestionRelatedQuestionMapHandler : IRequestHandler<UpdateQuestionRelatedQuestionMapRequest, bool>
    {
        private IOapChecklistQuestionRelatedQuestionMapService QuestionRelatedQuestionMapService { get; set; }


        private IMapper Mapper { get; set; }

        public UpdateQuestionRelatedQuestionMapHandler(IOapChecklistQuestionRelatedQuestionMapService questionRelatedQuestionMapService, IMapper mapper)
        {
            QuestionRelatedQuestionMapService = questionRelatedQuestionMapService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateQuestionRelatedQuestionMapRequest, bool>.Handle(UpdateQuestionRelatedQuestionMapRequest request, CancellationToken cancellationToken)
        {
            var existingQuestionRelatedQuestionMap = QuestionRelatedQuestionMapService.Get(request.QuestionRelatedQuestionMap.Id);

            if (existingQuestionRelatedQuestionMap == null)
            {
                throw new ApplicationException($"UpdateQuestionRelatedQuestionMapHandler: QuestionRelatedQuestionMap with Id {request.QuestionRelatedQuestionMap.Id} does not exist.");
            }            

            //AutoMapper to Map the fields 
            Mapper.Map(request.QuestionRelatedQuestionMap, existingQuestionRelatedQuestionMap);

            using (var ts = new TransactionScope())
            {
                var updatedQuestionTagMap = QuestionRelatedQuestionMapService.Update(existingQuestionRelatedQuestionMap);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}