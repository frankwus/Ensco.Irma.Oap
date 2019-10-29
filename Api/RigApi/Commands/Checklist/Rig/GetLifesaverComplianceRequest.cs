using Ensco.Irma.Models.Domain.Oap.Checklist.Lifesaver;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class GetLifesaverComplianceRequest : IRequest<LifesaverCompliance>
    {
    }
}