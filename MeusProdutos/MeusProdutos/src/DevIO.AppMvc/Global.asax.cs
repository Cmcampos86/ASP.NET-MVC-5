using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace DevIO.AppMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        //protected void Application_Start()
        //{
        //    AreaRegistration.RegisterAllAreas();
        //    FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        //    RouteConfig.RegisterRoutes(RouteTable.Routes);
        //    BundleConfig.RegisterBundles(BundleTable.Bundles);
        //}

        protected void Application_Start()
        {
            //Eu posso retirar tudo o que esta no Global.asax e passar para o arquivo Startup.cs
        }
    }
}
