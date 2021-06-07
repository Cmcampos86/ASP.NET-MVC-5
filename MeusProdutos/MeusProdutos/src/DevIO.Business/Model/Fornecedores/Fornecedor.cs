using DevIO.Business.Core.Models;
using DevIO.Business.Model.Fornecedores.Validations;
using DevIO.Business.Model.Produtos;
using System.Collections.Generic;

namespace DevIO.Business.Model.Fornecedores
{
    public class Fornecedor : Entity
    {
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoFornecedor TipoFornecedor { get; set; }
        public Endereco Endereco { get; set; }
        public bool Ativo { get; set; }

        /* EF Relations */
        public ICollection<Produto> Produtos { get; set; }
    }
}