namespace TesteMVC5.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TesteMVC5.Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //Atualiza o banco de dado (faz a migration)
        }

        protected override void Seed(TesteMVC5.Data.AppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
