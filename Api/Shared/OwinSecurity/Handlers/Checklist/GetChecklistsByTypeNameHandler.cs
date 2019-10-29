using Ensco.Irma.Interfaces.Services.Oap;
using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Oap.Api.Common.Commands.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Handlers.Checklist
{
    public class GetChecklistsByTypeNameHandler : IRequestHandler<GetChecklistsByTypeNameRequest, IEnumerable<OapChecklist>>
    {
        private readonly IOapChecklistService service;

        public GetChecklistsByTypeNameHandler(IOapChecklistService service)
        {
            this.service = service;
        }

        public Task<IEnumerable<OapChecklist>> Handle(GetChecklistsByTypeNameRequest request, CancellationToken cancellationToken)
        {
            var result = service.GetByTypeName(request.TypeName);
            return Task.FromResult(result);
        }
    }
}
