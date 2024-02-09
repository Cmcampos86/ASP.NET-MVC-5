using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TesteMVC5.Models
{
    public class Aluno
    {
        [Key]
        //O EF entende que o nome Id já é identificado com PK. Se estiver com outro nome,
        //é necessário colocar o datanotation [Key] acima
        public int Id { get; set; }

        //Colocar o {0} pega o valor da propriedade
        [DisplayName("Nome Completo")] //Display Name: Dessa forma que aparece na View
        [Required(ErrorMessage = "O campo {0} é requerido")]
        [MaxLength(100, ErrorMessage ="No máximo 100 caracteres")]
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