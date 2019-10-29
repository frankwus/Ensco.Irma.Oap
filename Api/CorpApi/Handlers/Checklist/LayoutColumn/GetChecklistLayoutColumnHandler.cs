using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Corp.Handlers.LayoutColumn
{
    using Ensco.Irma.Extensions;

    public class GetChecklistLayoutColumnHandler : IRequestHandler<GetChecklistLayoutColumnRequest, OapChecklistLayoutColumn>
    {
        private IOapChecklistLayoutColumnService Service { get; set; }

        public GetChecklistLayoutColumnHandler(IOapChecklistLayoutColumnService ChecklistLayoutColumnService)
        {
            Service = ChecklistLayoutColumnService;
        }

        Task<OapChecklistLayoutColumn> IRequestHandler<GetChecklistLayoutColumnRequest, OapChecklistLayoutColumn>.Handle(GetChecklistLayoutColumnRequest request, CancellationToken cancellationToken)
        {
            var c = Service.Get(request.ChecklistLayoutColumnId);             

            return Task.FromResult(c);
        }
    }
}