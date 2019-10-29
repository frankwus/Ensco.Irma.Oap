using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist
{
    public class GetChecklistChecklistByTypeSubTypeHandler : IRequestHandler<GetChecklistByTypeSubTypeRequest, IEnumerable<OapChecklist>>
    {
        private IOapChecklistService Service { get; set; }

        public GetChecklistChecklistByTypeSubTypeHandler(IOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        Task<IEnumerable<OapChecklist>> IRequestHandler<GetChecklistByTypeSubTypeRequest, IEnumerable<OapChecklist>>.Handle(GetChecklistByTypeSubTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetByTypeSubType(request.TypeName, request.SubTypeName);
            return Task.FromResult(cl);
        }
    }
}