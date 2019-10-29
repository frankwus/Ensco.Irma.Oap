using AutoMapper;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionDataType;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionDataType
{
    public class UpdateQuestionDataTypeHandler : IRequestHandler<UpdateQuestionDataTypeRequest, bool>
    {
        private IOapChecklistQuestionDataTypeService QuestionDataTypeService { get; set; }
         

        private IMapper Mapper { get; set;  }

        public UpdateQuestionDataTypeHandler(IOapChecklistQuestionDataTypeService frequencyTypeService, IMapper mapper)
        {
            QuestionDataTypeService = frequencyTypeService; 
            Mapper = mapper;
        }

        Task<bool> IRequestHandler<UpdateQuestionDataTypeRequest, bool>.Handle(UpdateQuestionDataTypeRequest request, CancellationToken cancellationToken)
        {
            var existingQuestionDataType = QuestionDataTypeService.Get(request.QuestionDataType.Id);

            if (existingQuestionDataType == null)
            {
                throw new ApplicationException($"UpdateQuestionDataTypeHandler: QuestionDataType with Id {request.QuestionDataType.Id} does not exist.");
            }

            //AutoMapper to Map the fields 
            Mapper.Map(request.QuestionDataType, existingQuestionDataType);

            using (var ts = new TransactionScope())
            {
                var updatedQuestionDataType = QuestionDataTypeService.Update(existingQuestionDataType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}