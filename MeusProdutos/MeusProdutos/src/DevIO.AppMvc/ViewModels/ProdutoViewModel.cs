using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace DevIO.AppMvc.ViewModels
{
    public class ProdutoViewModel
    {
        //ViewModel é uma representação das características de uma Entidade
        //Não usar as Entidades para fazer isso, uma vez que voce pode utilizar o Fluent Validation para isso
        //Data anotations são usado para entrada de formulário
        //Recebe dados de uma view e leva para a Controller
        //Contém Validações
        //Para utilizar a ViewModel com Scaffold, verificar o que realmente vai ser mostrado na tela
        // Botão direito na controller > Add > New Scaffold Item

        public ProdutoViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key] //Esse campo representa uma chave
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Fornecedor")]
        public Guid FornecedorId { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(200, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(1000, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Descricao { get; set; }

        [DisplayName("Imagem do Produto")]
        public HttpPostedFileBase ImagemUpload { get; set; }

        public string Imagem { get; set; }

        //[Moeda]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public decimal Valor { get; set; }

        [ScaffoldColumn(false)]//Não inserre esse campo no momento de criar um form com Scaffold
        public DateTime DataCadastro { get; set; }

        [DisplayName("Ativo?")]
        public bool Ativo { get; set; }

        public FornecedorViewModel Fornecedor { get; set; }

        public IEnumerable<FornecedorViewModel> Fornecedores { get; set; }
    }
}