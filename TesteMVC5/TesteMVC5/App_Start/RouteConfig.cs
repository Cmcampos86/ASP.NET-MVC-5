using System.Web.Mvc;
using System.Web.Routing;

namespace TesteMVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //Testa as rotas na ordem
            //A rota mais complexa deve ficar acima e a padrão fica por último
            //As precisam ser diferentes

            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //routes.MapRoute(
            //    name: "Institucional",
            //    url: "institucional/{controller}/{action}",
            //    defaults: new { controller = "Teste", action = "IndexTeste", id = UrlParameter.Optional }
            //);

            //routes.MapRoute(
            //    name: "Teste",
            //    url: "sistema/{controller}/{action}/{id}",
            //    defaults: new { controller = "Teste", action = "IndexTeste", id = UrlParameter.Optional }
            //);

            //Habilita as rotas por atributos
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
