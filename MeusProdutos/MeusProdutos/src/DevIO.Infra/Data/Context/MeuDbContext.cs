using DevIO.Business.Model.Fornecedores;
using DevIO.Business.Model.Produtos;
using DevIO.Infra.Data.Mappings;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

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
    }
}
