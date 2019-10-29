using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Ensco.Irma.Oap.Api.Rig.Commands.Checklist.Rig
{
    public class DeleteAssessorRequest : IRequest<bool>
    {
        public DeleteAssessorRequest(Guid Id)
        {
            this.Id = Id;
        }

        public Guid Id { get; }
    }
}