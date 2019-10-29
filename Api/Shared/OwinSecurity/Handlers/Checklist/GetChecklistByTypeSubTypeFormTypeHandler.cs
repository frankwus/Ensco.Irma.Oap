using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist
{
    public class GetChecklistByTypeSubTypeFormTypeHandler : IRequestHandler<GetChecklistByTypeSubTypeFormTypeRequest, IEnumerable<OapChecklist>>
    {
        private IOapChecklistService Service { get; set; }

        public GetChecklistByTypeSubTypeFormTypeHandler(IOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        Task<IEnumerable<OapChecklist>> IRequestHandler<GetChecklistByTypeSubTypeFormTypeRequest, IEnumerable<OapChecklist>>.Handle(GetChecklistByTypeSubTypeFormTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetByTypeSubTypeFormType(request.TypeName, request.SubTypeName, request.FormType);
            return Task.FromResult(cl);
        }
    }
}