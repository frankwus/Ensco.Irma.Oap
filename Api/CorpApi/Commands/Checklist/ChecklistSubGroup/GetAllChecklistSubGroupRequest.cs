﻿using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Corp.Commands.Checklist.ChecklistSubGroup
{
    public class GetAllChecklistSubGroupRequest : IRequest<IEnumerable<OapChecklistSubGroup>>
    { 
        public GetAllChecklistSubGroupRequest(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}