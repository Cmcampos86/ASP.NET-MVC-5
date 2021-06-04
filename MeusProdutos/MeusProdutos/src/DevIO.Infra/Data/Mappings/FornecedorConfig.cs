using DevIO.Business.Model.Fornecedores;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace DevIO.Infra.Data.Mappings
{
    public class FornecedorConfig : EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorConfig()
        {
            //Mapeamento
            HasKey(f => f.Id); //Chave Primária. É sempro bom informar, mas se não informar, o EF reconheceria pelas convenções
            
            Property(f => f.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(f => f.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation("IX_Documento", 
                    new IndexAnnotation(new IndexAttribute { IsUnique = true })); //Cria um índice

            HasRequired(f => f.Endereco)
                .WithRequiredPrincipal(e => e.Fornecedor); //Cria o relacionamento da tabela 1 X 1

            ToTable("Fornecedores");
        }
    }
}
