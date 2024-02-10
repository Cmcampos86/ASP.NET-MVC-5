using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;
using AppMvc.Models;
using System;

namespace AppMvc.Controllers
{
    //Filters:
    //OutputCache: Faz o cahce de um output da Controller
    //ValidateInPut: Desliga a validação dos requests e permite input de dados perigosos
    //Authorize: Restring uma Action a apenas usuários autorizados ou roles
    //ValidateAntiForgeryToken: Previne ataques de Cross-Site Request Forgery
    //HandleError: Caputura todos os erros e possibilita a escolha de uma View para exibição de erros

    //Só vai permitir acesso quando for fazer o login
    //O Authorize pode ser usado em um método específico
    [Authorize]
    public class AlunosController : Controller
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        [HttpGet]
        //[AllowAnonymous]//AllowAnonymous trata a excessão do Autorize. Somente o index pode ser acessado.
        //[OutputCache(Duration = 60)] //Utilizado para persistir em cache a informação de acordo com o tempo (Duration). Essa funcionalidade é interessante para dados imutáveis.
        [Route("listar-alunos")]
        public async Task<ActionResult> Index()
        {
            return View(await db.Alunos.ToListAsync());
        }

        [HttpGet]
        [Route("aluno-detalhe/{id:int}")]
        public async Task<ActionResult> Details(int id)
        {
            var aluno = await db.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        [HttpGet]
        [Route("novo-aluno")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("novo-aluno")]
        [HandleError(ExceptionType = typeof(NullReferenceException), View = "Erro")]//Se ocorrer algum erro específico(NullReferenceException como no exemplo), vai redirecionar para a view Erro (específica)
        [ValidateInput(false)]//Se injetar um javascript perigoso, ele vai aceitar. Por padrão o asp.net proteje os scripts perigosos
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Nome,Email,CPF,Descricao,Ativo")] Aluno aluno)
        {
            //O Bind acima permite configurar as propriedades que você quer que apareça. Se voce quer que outros campos apareçam, precisa adicionar no Bind
            //Não é muito aconselhável usar Bind porque é muito verboso
            if (ModelState.IsValid)
            {
                aluno.DataMatricula = DateTime.Now;
                db.Alunos.Add(aluno);
                await db.SaveChangesAsync();

                //TempData: persiste a informação quando ocorre um redirect ou request. Ela finaliza quando é lida
                //Exemplo da mensagem cadastrada com sucesso. Ela some depois de lida.

                TempData["Mensagem"] = "Aluno cadastrado com sucesso";

                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        [HttpGet]
        [Route("editar-aluno/{id:int}")] //A ída e a volta da rota deve ser configurada igual
        public async Task<ActionResult> Edit(int id)
        {
            var aluno = await db.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            //ViewBag: Passa uma informação de uma controller para uma View
            ViewBag.Mensagem = "Não esqueça de esta ação é irreversível";

            return View(aluno);
        }

        [HttpPost]
        [Route("editar-aluno/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Nome,Email,CPF,Descricao,Ativo")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.Entry(aluno).Property(a => a.DataMatricula).IsModified = false; //Eu ignoro a propriedade para ser salva
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(aluno);
        }

        [HttpGet]
        [Route("excluir-aluno/{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var aluno = await db.Alunos.FindAsync(id);

            if (aluno == null)
            {
                return HttpNotFound();
            }

            return View(aluno);
        }

        //[HttpPost, ActionName("Delete")] //O ActionName dá um apelido para a rota
        [HttpPost]
        [Route("excluir-aluno/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Aluno aluno = await db.Alunos.FindAsync(id);
            db.Alunos.Remove(aluno);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
