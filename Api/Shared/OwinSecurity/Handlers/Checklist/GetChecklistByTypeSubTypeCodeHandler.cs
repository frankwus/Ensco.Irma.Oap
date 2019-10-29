using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist
{
    public class GetChecklistChecklistByTypeSubTypeCodeHandler : IRequestHandler<GetChecklistByTypeSubTypeCodeRequest, IEnumerable<OapChecklist>>
    {
        private IOapChecklistService Service { get; set; }

        public GetChecklistChecklistByTypeSubTypeCodeHandler(IOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        Task<IEnumerable<OapChecklist>> IRequestHandler<GetChecklistByTypeSubTypeCodeRequest, IEnumerable<OapChecklist>>.Handle(GetChecklistByTypeSubTypeCodeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetByTypeSubTypeCode(request.TypeCode, request.SubTypeCode);
            return Task.FromResult(cl);
        }
    }
}