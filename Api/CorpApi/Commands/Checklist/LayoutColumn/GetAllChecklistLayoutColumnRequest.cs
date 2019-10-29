using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.LayoutColumn
{
    public class GetAllChecklistLayoutColumnRequest : IRequest<IEnumerable<OapChecklistLayoutColumn>>
    { 
        public GetAllChecklistLayoutColumnRequest(int layoutId)
        {
            ChecklistLayoutId = layoutId;
        }

        public int ChecklistLayoutId { get; }
    }
}