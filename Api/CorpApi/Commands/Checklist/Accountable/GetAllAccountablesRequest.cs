using Ensco.Irma.Models.Domain.Oap;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.Accountable
{
    public class GetAllAccountablesRequest : IRequest<IEnumerable<OapAccountable>>
    {        
    }
}