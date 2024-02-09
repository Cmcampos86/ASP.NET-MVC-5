using System.Web.Mvc;
using System.Web.Routing;

namespace TesteMVC5
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            //As rotas são chamadas dentro do Global.asax
            //Testa as rotas na ordem
            //A rota mais complexa deve ficar acima e a padrão fica por último
            //Elas precisam ser diferentes

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

            //Habilita as rotas por atributos (rotas em cima das controllers)
            routes.MapMvcAttributeRoutes();

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
