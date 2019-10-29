using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionDataType;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Transactions;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionDataType
{
    public class DeleteQuestionDataTypeHandler : IRequestHandler<DeleteQuestionDataTypeRequest, bool>
    {
        private IOapChecklistQuestionDataTypeService QuestionDataTypeService { get; set; }

        public DeleteQuestionDataTypeHandler(IOapChecklistQuestionDataTypeService questionDataTypeService)
        {
            QuestionDataTypeService = questionDataTypeService;
        }

        Task<bool> IRequestHandler<DeleteQuestionDataTypeRequest, bool>.Handle(DeleteQuestionDataTypeRequest request, CancellationToken cancellationToken)
        {
            using (var ts = new TransactionScope())
            {
                var QuestionDataType = QuestionDataTypeService.Get(request.QuestionDataTypeId);
                 
                QuestionDataTypeService.Delete(QuestionDataType);

                ts.Complete();
            }
            return Task.FromResult(true);
        }
    }
}