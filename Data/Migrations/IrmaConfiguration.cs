namespace Ensco.Irma.Data.Migrations
{
    using Ensco.Irma.Data.Context;
    using Ensco.Irma.Models.Domain.Oap;
    using Ensco.Irma.Models.Domain.Oap.Checklist;
    using Ensco.Irma.Models.Domain.Workflow;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Text;

    internal sealed class IrmaConfiguration : DbMigrationsConfiguration<IrmaDbContext>
    {
        public IrmaConfiguration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(IrmaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            AddPeople(context); 
           
        }

        
        private void AddPeople(IrmaDbContext context)
        {
            context.People.AddOrUpdate((o) => o.Name, new Models.Domain.Security.Person() { Name = "Shashi Hosur", FirstName = "Shashi", LastName = "Hosur", Login = "shosur@enscoplc.com", Password = "123456", CreatedDateTime = DateTime.UtcNow, UpdatedDateTime = DateTime.UtcNow, CreatedBy = "Migration", UpdatedBy = "Migration" });
        }


    }
}
