using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionDataType;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.QuestionDataType
{
    public class GetQuestionDataTypeHandler : IRequestHandler<GetQuestionDataTypeRequest, OapChecklistQuestionDataType>
    {
        private IOapChecklistQuestionDataTypeService Service { get; set; }

        public GetQuestionDataTypeHandler(IOapChecklistQuestionDataTypeService questionDataTypeService)
        {
            Service = questionDataTypeService;
        }

        Task<OapChecklistQuestionDataType> IRequestHandler<GetQuestionDataTypeRequest, OapChecklistQuestionDataType>.Handle(GetQuestionDataTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.QuestionDataTypeId);
            return Task.FromResult(cl);
        }
    }
}