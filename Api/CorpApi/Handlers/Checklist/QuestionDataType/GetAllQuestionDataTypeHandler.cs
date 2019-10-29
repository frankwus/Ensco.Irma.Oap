using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.QuestionDataType;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.QuestionDataType
{
    public class GetAllQuestionDataTypeHandler : IRequestHandler<GetAllQuestionDataTypeRequest, IEnumerable<OapChecklistQuestionDataType>>
    {
        private IOapChecklistQuestionDataTypeService Service { get; set; }

        public GetAllQuestionDataTypeHandler(IOapChecklistQuestionDataTypeService frequencyTypeService)
        {
            Service = frequencyTypeService;
        }

        Task<IEnumerable<OapChecklistQuestionDataType>> IRequestHandler<GetAllQuestionDataTypeRequest, IEnumerable<OapChecklistQuestionDataType>>.Handle(GetAllQuestionDataTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll();
            return Task.FromResult(cl);
        }
    }
}