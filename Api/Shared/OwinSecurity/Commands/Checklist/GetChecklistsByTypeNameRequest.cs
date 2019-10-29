using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist
{
    public class GetChecklistsByTypeNameRequest : IRequest<IEnumerable<OapChecklist>>
    {
        public GetChecklistsByTypeNameRequest(string typeName)
        {
            TypeName = typeName;
        }

        public string TypeName { get; }
    }
}
