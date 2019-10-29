using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.Checklist.LayoutColumn
{
    using Ensco.Irma.Extensions;

    public class GetAllChecklistLayoutColumnHandler : IRequestHandler<GetAllChecklistLayoutColumnRequest, IEnumerable<OapChecklistLayoutColumn>>
    {
        private IOapChecklistLayoutColumnService Service { get; set; }

        public GetAllChecklistLayoutColumnHandler(IOapChecklistLayoutColumnService ChecklistLayoutColumnService)
        {
            Service = ChecklistLayoutColumnService;
        }

        Task<IEnumerable<OapChecklistLayoutColumn>> IRequestHandler<GetAllChecklistLayoutColumnRequest, IEnumerable<OapChecklistLayoutColumn>>.Handle(GetAllChecklistLayoutColumnRequest request, CancellationToken cancellationToken)
        {
            var list = Service.GetAll(request.ChecklistLayoutId);            

            return Task.FromResult(list);
        }
    }
}