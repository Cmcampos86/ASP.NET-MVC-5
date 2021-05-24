using System.Web.Mvc;
using TesteMVC5.Models;

namespace TesteMVC5.Controllers
{
    public class AlunoController : Controller
    {
        //[Route("novo-aluno")]
        //public ActionResult Novo(Aluno aluno)
        //{
        //    aluno = new Aluno
        //    {
        //        Nome = "Claudio",
        //        CPF = "35985422784",
        //        DataMatricula = DateTime.Now,
        //        Email = "cmcampos86@gmail.com",
        //        Ativo = true,
        //        Senha = "123456",
        //        SenhaConfirmacao = "123456"
        //    };

        //    return RedirectToAction("Index", aluno);
        //}

        //public ActionResult Index(Aluno aluno)
        //{
        //    if (!ModelState.IsValid) return View(aluno);

        //    return View(aluno);
        //}

        ////////////////////////////////////////////////////////////

        [HttpGet]
        [Route("novo-aluno")]
        public ActionResult NovoAluno()
        {
            return View();                
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Valida o token recebido da View
        [Route("novo-aluno")]
        public ActionResult NovoAluno(Aluno aluno)
        {
            if (!ModelState.IsValid) return View(aluno);

            //Alguma regra de negócio + salvar no banco

            return View(aluno);
        }
    }
}