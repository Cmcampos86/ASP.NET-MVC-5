using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using TesteMVC5.Models;

namespace TesteMVC5.Data
{
    public class AppDbContext : DbContext
    {
        //Instalar o EF 6
        //enable-migrations: verifica se a conection string aponta para uma base existente 
        //update-database: atualiza o banco
        //-Force: força uma atualização, mas dados podem ser perdidos
        //-verbose: mostra mais informações durante o processamento
        //-Script: ele cria o script e voce aplica no banco
        //O EF salva a migration (Histórico)
        //Cria uma hash para comprarar com as migrations anteriores

        public AppDbContext() : base("DefaultConnection")
        { 
        
        }

        public DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Remove a convenção do plural que está configurado para o inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Inclui a tabela de acordo com o que eu quiser
            modelBuilder.Entity<Aluno>().ToTable("Alunos");

            base.OnModelCreating(modelBuilder);
        }
    }
}