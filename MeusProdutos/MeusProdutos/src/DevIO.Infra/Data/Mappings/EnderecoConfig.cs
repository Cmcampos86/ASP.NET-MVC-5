using DevIO.Business.Model.Fornecedores;
using System.Data.Entity.ModelConfiguration;

namespace DevIO.Infra.Data.Mappings
{
    public class EnderecoConfig : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfig()
        {
            HasKey(p => p.Id);

            Property(c => c.Logradouro)
                //.HasColumnName("Rua") //Se o banco já existir e o nome da coluna for outro, para o banco vai "Rua" e para usar a propriedade vai "Logradouro"
                .IsRequired()
                .HasMaxLength(200);

            Property(c => c.Numero)
                .IsRequired()
                .HasMaxLength(50);

            Property(c => c.Cep)
                .IsRequired()
                .HasMaxLength(8)
                .IsFixedLength();//Campo fixo

            Property(c => c.Complemento)
                .HasMaxLength(250);

            Property(c => c.Bairro)
                .IsRequired();

            Property(c => c.Cidade)
                .IsRequired();

            Property(c => c.Estado)
                .IsRequired();

            ToTable("Enderecos");
        }
    }
}
