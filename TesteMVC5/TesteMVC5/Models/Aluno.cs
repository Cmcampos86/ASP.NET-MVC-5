using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TesteMVC5.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        //Colocar o {0} pega o valor da propriedade
        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo {0} é requerido")] 
        public string Nome { get; set; }

        [DisplayName("E-mail")]
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        public string CPF { get; set; }
        
        public DateTime DataMatricula { get; set; }
        
        public bool Ativo { get; set; }

        //[Required(ErrorMessage = "O campo {0} é requerido")]
        //public string Senha { get; set; }

        //[Compare("Senha", ErrorMessage = "As senhas informadas não conferem")]
        //[Required(ErrorMessage = "O campo {0} é requerido")]
        //public string SenhaConfirmacao { get; set; }
    }
}