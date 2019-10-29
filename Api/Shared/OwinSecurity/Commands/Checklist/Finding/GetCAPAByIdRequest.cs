using Ensco.Irma.Models.Domain.IRMA;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Finding
{
    public class GetCAPAByIdRequest : IRequest<IrmaCapa>
    {
        public int CapaId { get; set; }

        public GetCAPAByIdRequest(int capaId)
        {
            CapaId = capaId;
        }
    }
}
