using Ensco.Irma.Models.Domain.Oap;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Accountable
{
    public class GetAccountablesByPositionIdsRequest : IRequest<IEnumerable<OapAccountable>>
    {        
        public GetAccountablesByPositionIdsRequest(int[] ids)
        {
            Ids = ids;
        }

        public int[] Ids { get; }
    }
}