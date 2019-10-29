using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Layout;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.Layout
{
    using Ensco.Irma.Extensions;

    public class GetAllChecklistLayoutHandler : IRequestHandler<GetAllChecklistLayoutRequest, IEnumerable<OapChecklistLayout>>
    {
        private IOapChecklistLayoutService Service { get; set; }

        public GetAllChecklistLayoutHandler(IOapChecklistLayoutService ChecklistLayoutService)
        {
            Service = ChecklistLayoutService;
        }

        Task<IEnumerable<OapChecklistLayout>> IRequestHandler<GetAllChecklistLayoutRequest, IEnumerable<OapChecklistLayout>>.Handle(GetAllChecklistLayoutRequest request, CancellationToken cancellationToken)
        {
            var list = Service.GetAll();            

            return Task.FromResult(list);
        }
    }
}