
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist.FindingSubType
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType;

    public class GetAllFindingSubTypeHandler : IRequestHandler<GetAllFindingSubTypeRequest, IEnumerable<FindingSubType>>
    {
        private IFindingSubTypeService Service { get; set; }

        public GetAllFindingSubTypeHandler(IFindingSubTypeService findingTypeService)
        {
            Service = findingTypeService;
        }

        Task<IEnumerable<FindingSubType>> IRequestHandler<GetAllFindingSubTypeRequest, IEnumerable<FindingSubType>>.Handle(GetAllFindingSubTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetAll();
            return Task.FromResult(cl);
        }
    }
}