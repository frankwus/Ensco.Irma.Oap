using Ensco.Irma.Models.Domain.Oap.Checklist;
using Ensco.Irma.Models.Domain.Security;
using Ensco.Irma.Models.Domain.Workflow;
using Ensco.Irma.Models.Domain.Oap;

using System.Data.Entity;
using Ensco.Irma.Models.Domain.IRMA;

namespace Ensco.Irma.Data.Context
{
    public interface IIrmaDbContext: IExecuteSql
    {         
        DbSet<Rig> Rigs { get; set; }

        DbSet<AdminCustom> AdminCustoms { get; set; }

        DbSet<Person> People { get; set; }

        DbSet<IrmaTask> Tasks { get; set; }

        DbSet<IrmaCapa> CAPAs { get; set; }

        DbSet<Criticality> Criticalities { get; set; }

        DbSet<PobPersonnel> PobPeople{ get; set; }

        DbSet<PobTour> PobTours { get; set; }


    }
}