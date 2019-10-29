using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist
{
    public class GetChecklistByTypeSubTypeCodeFormTypeHandler : IRequestHandler<GetChecklistByTypeSubTypeCodeFormTypeRequest, IEnumerable<OapChecklist>>
    {
        private IOapChecklistService Service { get; set; }

        public GetChecklistByTypeSubTypeCodeFormTypeHandler(IOapChecklistService checklistService)
        {
            Service = checklistService;
        }

        Task<IEnumerable<OapChecklist>> IRequestHandler<GetChecklistByTypeSubTypeCodeFormTypeRequest, IEnumerable<OapChecklist>>.Handle(GetChecklistByTypeSubTypeCodeFormTypeRequest request, CancellationToken cancellationToken)
        {
            var cl = Service.GetByTypeSubTypeCodeFormType(request.TypeCode, request.SubTypeCode, request.FormType);
            return Task.FromResult(cl);
        }
    }
}