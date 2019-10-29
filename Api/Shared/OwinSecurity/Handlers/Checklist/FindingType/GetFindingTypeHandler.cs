using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Corp.Api.Handlers.FindingType
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingType;

    public class GetFindingTypeHandler : IRequestHandler<GetFindingTypeRequest, FindingType>
    {
        private IFindingTypeService Service { get; set; }

        public GetFindingTypeHandler(IFindingTypeService findingTypeService)
        {
            Service = findingTypeService;
        }

        Task<FindingType> IRequestHandler<GetFindingTypeRequest, FindingType>.Handle(GetFindingTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.FindingTypeId);
            return Task.FromResult(cl);
        }
    }
}