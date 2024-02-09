using System.Web.Mvc;

namespace TesteMVC5.Controllers
{
    //RoutePrefix: mantémm o nome para todas as rotas e também pode acrescenter com o Route
    [RoutePrefix("testes")]
    public class TesteController : Controller
    {
        //[Route]
        //public ActionResult IndexTeste()
        //{
        //    return View();
        //}

        //Passagem de parâmetro
        //O parâmetro não tem a ver com a variável da configuração da rota
        //Posso tipar a variável
        //Se a variável estiver tipada e não for do tipo que estou passando, dá o erro 404
        //Pode usar a rota definida com querystring, desde que o parâmetro da querystring não esteja na rota

        //[Route("{id:int}")]
        //public ActionResult IndexTeste(int id)
        //{
        //    return View();
        //}

        [Route("{id2:int}/{texto:maxlength(50)}")]
        public ActionResult IndexTeste(int id2, string texto)
        {
            return View();
        }

        [Route("{texto:maxlength(50)}/um-outro-teste/{id2:int}")]
        public ActionResult IndexTeste2(int id2, string texto)
        {
            return View("IndexTeste");
        }
    }
}