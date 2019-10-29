using Ensco.Irma.Data.Context;
using Ensco.Irma.Framework.Configuration;
using System.Data.Entity.Infrastructure;

namespace Ensco.Irma.Data.Migrations
{
    public class MigrationsIrmaOapDbContextFactory : IDbContextFactory<IrmaOapDbContext>
    {
        public IrmaOapDbContext Create()
        {
            FrameworkEnvironment.Configure();
            return new IrmaOapDbContext(FrameworkEnvironment.Instance.Configuration.GetConnectionString());
        }
    }
}
