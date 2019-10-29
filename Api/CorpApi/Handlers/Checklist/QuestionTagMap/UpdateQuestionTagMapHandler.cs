using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionTagMap;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionTagMap
{
    public class UpdateQuestionTagMapHandler : IRequestHandler<UpdateQuestionTagMapRequest, bool>
    {
        private IOapChecklistQuestionTagMapService QuestionTagMapService { get; set; }


        private IMapper Mapper { get; set; }

        public UpdateQuestionTagMapHandler(IOapChecklistQuestionTagMapService questionTagMapService, IMapper mapper)
        {
            QuestionTagMapService = questionTagMapService;
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateQuestionTagMapRequest, bool>.Handle(UpdateQuestionTagMapRequest request, CancellationToken cancellationToken)
        {
            var existingQuestionTagMap = QuestionTagMapService.Get(request.QuestionTagMap.Id);

            if (existingQuestionTagMap == null)
            {
                throw new ApplicationException($"UpdateQuestionTagMapHandler: QuestionTagMap with Id {request.QuestionTagMap.Id} does not exist.");
            }

            var checkDuplicate = QuestionTagMapService.GetByQuestionTag(request.QuestionTagMap.OapChecklistQuestionId , request.QuestionTagMap.OapChecklistQuestionTagId);
            if (checkDuplicate != null )
            {
                throw new ApplicationException($"UpdateQuestionTagMapHandler: QuestionTagMap with QuestionId {request.QuestionTagMap.OapChecklistQuestionId} and QuestionTagId {request.QuestionTagMap.OapChecklistQuestionTagId}  already exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.QuestionTagMap, existingQuestionTagMap);

            using (var ts = new TransactionScope())
            {
                var updatedQuestionTagMap = QuestionTagMapService.Update(existingQuestionTagMap);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}