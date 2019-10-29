using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.FrequencyType;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.FrequencyType
{
    public class GetAllFrequencyTypeHandler : IRequestHandler<GetAllFrequencyTypeRequest, IEnumerable<OapFrequencyType>>
    {
        private IOapFrequencyTypeService Service { get; set; }

        public GetAllFrequencyTypeHandler(IOapFrequencyTypeService frequencyTypeService)
        {
            Service = frequencyTypeService;
        }

        Task<IEnumerable<OapFrequencyType>> IRequestHandler<GetAllFrequencyTypeRequest, IEnumerable<OapFrequencyType>>.Handle(GetAllFrequencyTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll(request.StartDate, request.EndDate);
            return Task.FromResult(cl);
        }
    }
}