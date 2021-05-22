using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteMVC5.Controllers
{
    public class HomeController : Controller
    {
        //ViewResult só pode retornar uma View
        //Action Result pode retornar qualquer coisa(Genérico)

        //Tudo o que for sem URL, vai cair nessa controller
        [Route("")]
        public ActionResult Index()
        {
            return View();
        }

        //Renomeia a rota
        [Route("sobre-nos")]
        public ActionResult About()
        {
            return View();
        }

        [Route("institucional/entre-em-contato")]
        public ActionResult Contact()
        {
            return View();
        }

        [Route("content-result")]
        public ContentResult ContentResult()
        {
            return Content("Olá!");
        }

        [Route("downloads/meu-arquivo")]
        public FileContentResult FileContentResult()
        {
            var foto = System.IO.File.ReadAllBytes(Server.MapPath("/content/images/Foto1.jpg"));

            return File(foto, "image/jpg", "Foto1.jpg");
        }

        public HttpUnauthorizedResult HttpUnauthorizedResult()
        {
            return new HttpUnauthorizedResult();
        }

        //JsonRequestBehavior.AllowGet: permite que o asp.net retorne um json, pq no padr~~ao não é permitido
        public JsonResult JsonResult()
        {
            return Json("teste:'Teste'", JsonRequestBehavior.AllowGet);
        }

        public RedirectResult RedirectResult()
        {
            //Redirecionamento externo
            return new RedirectResult("https://www.google.com.br/webhp?hl=pt-BR");
        }

        public RedirectToRouteResult RedirectToRouteResult()
        {
            //Redirecionamento interno
            //return RedirectToRoute(new
            //{
            //    controller = "Teste",
            //    action = "IndexTeste"
            //});

            return RedirectToAction("IndexTeste", "Teste");
        }
    }
}