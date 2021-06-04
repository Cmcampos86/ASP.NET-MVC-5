using System.Data.Entity.Migrations;

namespace DevIO.Infra.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Data.Context.MeuDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }
    }
}
