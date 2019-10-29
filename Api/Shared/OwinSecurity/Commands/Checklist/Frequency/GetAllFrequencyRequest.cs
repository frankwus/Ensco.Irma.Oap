using Ensco.Irma.Models.Domain.Oap.Checklist;
using MediatR;
using System;
using System.Collections.Generic;

namespace Ensco.Irma.Oap.Api.Common.Commands.Checklist.Frequency
{
    public class GetAllFrequencyRequest : IRequest<IEnumerable<OapFrequency>>
    { 
        public GetAllFrequencyRequest(DateTime startDate, DateTime endDate)
        {
            StartDate = startDate;
            EndDate = endDate;
        }

        public DateTime StartDate { get; }
        public DateTime EndDate { get; }
    }
}