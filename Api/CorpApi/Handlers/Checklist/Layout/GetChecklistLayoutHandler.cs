using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Layout
{
    using Ensco.Irma.Extensions;

    public class GetChecklistLayoutHandler : IRequestHandler<GetChecklistLayoutRequest, OapChecklistLayout>
    {
        private IOapChecklistLayoutService Service { get; set; }

        public GetChecklistLayoutHandler(IOapChecklistLayoutService ChecklistLayoutService)
        {
            Service = ChecklistLayoutService;
        }

        Task<OapChecklistLayout> IRequestHandler<GetChecklistLayoutRequest, OapChecklistLayout>.Handle(GetChecklistLayoutRequest request, CancellationToken cancellationToken)
        {
            var c = Service.Get(request.ChecklistLayoutId);             

            return Task.FromResult(c);
        }
    }
}