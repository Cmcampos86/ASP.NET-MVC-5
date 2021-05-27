using System.Data.Entity;
using TesteMVC5.Models;

namespace TesteMVC5.Data
{
    public class AppDbContext : DbContext
    {
        //enable-migrations: virifica se a conection string aponta para uma base existente 
        //update-database: atualiza o banco
        // -verbose: mostra mais informações durante o processamento
        public AppDbContext() : base("DefaultConnection")
        { 
        
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}