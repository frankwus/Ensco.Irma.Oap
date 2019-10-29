using System;

namespace Ensco.Irma.Oap.Api.Common.Models
{
    public class GetAllModel
    {
        public DateTime StartDate { get; set; } = DateTime.MinValue;

        public DateTime EndDate { get; set; } = DateTime.MaxValue;
    }
}