using DevIO.Business.Model.Fornecedores;
using DevIO.Business.Model.Produtos;
using DevIO.Infra.Data.Mappings;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DevIO.Infra.Data.Context
{
    public class MeuDbContext : DbContext
    {
        //Instalar o EF
        public MeuDbContext() : base("DefaultConnection")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();//Remove a pluralidade da tabela porque o plural é utilizado nesse contexto em inglês
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();//Remove o cascade delete nos relacionamentos 1 X N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();//Remove o cascade delete nos relacionamentos N X N

            modelBuilder.Properties<string>()
                .Configure(p => p
                                .HasColumnType("varchar")
                                .HasMaxLength(100)); //Configura todas as propriedades string como varchar no banco e coloca um tamanho caso não tenha.

            //Inclui os mappings
            modelBuilder.Configurations.Add(new FornecedorConfig());
            modelBuilder.Configurations.Add(new EnderecoConfig());
            modelBuilder.Configurations.Add(new ProdutoConfig());

            base.OnModelCreating(modelBuilder);
        }

        //Método para apontar um Getdate se for uma inserção
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
