
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Corp.Api.Handlers.Checklist.FindingType
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType;

    public class GetAllFindingTypeHandler : IRequestHandler<GetAllFindingTypeRequest, IEnumerable<FindingType>>
    {
        private IFindingTypeService Service { get; set; }

        public GetAllFindingTypeHandler(IFindingTypeService findingTypeService)
        {
            Service = findingTypeService;
        }

        Task<IEnumerable<FindingType>> IRequestHandler<GetAllFindingTypeRequest, IEnumerable<FindingType>>.Handle(GetAllFindingTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll();
            return Task.FromResult(cl);
        }
    }
}