using System;

namespace Ensco.Irma.Interfaces.Domain
{
    public interface IEntityDates
    {

        DateTime StartDateTime { get; set; }

        DateTime EndDateTime { get; set; }
    }
}
