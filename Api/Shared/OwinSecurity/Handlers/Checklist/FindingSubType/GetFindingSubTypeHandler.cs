using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.FindingSubType
{
    using Ensco.Irma.Interfaces.Services.Oap;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Oap.Api.Common.Commands.Checklist.FindingSubType;

    public class GetFindingSubTypeHandler : IRequestHandler<GetFindingSubTypeRequest, FindingSubType>
    {
        private IFindingSubTypeService Service { get; set; }

        public GetFindingSubTypeHandler(IFindingSubTypeService findingSubTypeService)
        {
            Service = findingSubTypeService;
        }

        Task<FindingSubType> IRequestHandler<GetFindingSubTypeRequest, FindingSubType>.Handle(GetFindingSubTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.Get(request.FindingSubTypeId);
            return Task.FromResult(cl);
        }
    }
}