using Ensco.Irma.Extensions;
using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionDataType;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionDataType
{
    public class AddQuestionDataTypeHandler : IRequestHandler<AddQuestionDataTypeRequest, OapChecklistQuestionDataType>
    {
        private IOapChecklistQuestionDataTypeService QuestionDataTypeService { get; set; }

        public AddQuestionDataTypeHandler(IOapChecklistQuestionDataTypeService questionDataTypeService)
        {
            QuestionDataTypeService = questionDataTypeService;
        }

        Task<OapChecklistQuestionDataType> IRequestHandler<AddQuestionDataTypeRequest, OapChecklistQuestionDataType>.Handle(AddQuestionDataTypeRequest request, CancellationToken cancellationToken)
        {
            var existingQuestionDataType = QuestionDataTypeService.GetByName(request.QuestionDataType.Name);
            if (existingQuestionDataType  != null)
            {
                return Task.FromResult(existingQuestionDataType);
            }

            int newQuestionDataTypeId = 0;
            using (var ts = new TransactionScope())
            {
                newQuestionDataTypeId = QuestionDataTypeService.Add(request.QuestionDataType); 
                
                ts.Complete();
            }
            return Task.FromResult(QuestionDataTypeService.Get(newQuestionDataTypeId));
        }

         
    }
}