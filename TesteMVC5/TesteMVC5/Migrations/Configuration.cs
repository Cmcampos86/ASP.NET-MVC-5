namespace TesteMVC5.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Data.AppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true; //Deixando como true ele habilita para inlcuir as migrations
        }

        protected override void Seed(TesteMVC5.Data.AppDbContext context)
        {
            //Incluir alguma coisa nas tabelas quando ocorrer a criação do banco


            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
