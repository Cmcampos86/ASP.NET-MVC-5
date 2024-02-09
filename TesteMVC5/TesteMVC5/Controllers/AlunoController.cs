using System;
using System.Linq;
using System.Web.Mvc;
using TesteMVC5.Data;
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

        private readonly AppDbContext context = new AppDbContext();

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
            //ModelState: verifica se a model está válida mediante ao preenchimento correto das
            //propriedades da classe
            if (!ModelState.IsValid) return View(aluno);

            aluno.DataMatricula = DateTime.Now;

            context.Alunos.Add(aluno); //Adiciona os resultados
            context.SaveChanges(); //Salva no banco

            return View(aluno);
        }

        [HttpGet]
        [Route("obter-aluno")]
        public ActionResult ObterAlunos()
        {
            var alunos = context.Alunos.ToList();

            return View("NovoAluno", alunos.FirstOrDefault());
        }

        [HttpGet]
        [Route("editar-aluno")]
        public ActionResult EditarAlunos()
        {
            //Para a edição, o EF trabalho com o estado do contexto

            var aluno = context.Alunos.FirstOrDefault(a => a.Nome == "CLAUDIO MARCOS DE CAMPOS");

            aluno.Nome = "João";
            var entry = context.Entry(aluno);//Configura o objeto de entrada que pode ou não exisitir
            context.Set<Aluno>().Attach(aluno); //Atacha o objeto no contexto
            entry.State = System.Data.Entity.EntityState.Modified; //Configura a entrada. Como existe, então é um estado modificado

            context.SaveChanges();//Salva

            var alunonovo = context.Alunos.Find(aluno.Id);//O Find nesse contexto busca pela chave primária

            return View("NovoAluno", alunonovo);
        }

        [HttpGet]
        [Route("excluir-aluno")]
        public ActionResult ExluirAlunos()
        {
            //Recupera o objeto
            var aluno = context.Alunos.FirstOrDefault(a => a.Nome == "João");

            context.Alunos.Remove(aluno); //Exclui passando o obejto, pois, ele já identifica os Id dentro do objeto para excluir

            context.SaveChanges(); //Salva

            var alunos = context.Alunos.ToList();

            return View("NovoAluno", alunos.FirstOrDefault());
        }

    }
}