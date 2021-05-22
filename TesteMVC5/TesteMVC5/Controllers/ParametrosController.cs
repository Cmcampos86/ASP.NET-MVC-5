using System.Web.Mvc;

namespace TesteMVC5.Controllers
{
    public class ParametrosController : Controller
    {
        //O nome da variável (esta na rota) deve seguir o padrão da rota estruturada
        //Se não for o mesmo nome da variável, deve segui o padrão de querystring. Ex: controlle/Action?teste=1
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}