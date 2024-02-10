using System.Web;
using System.Web.Optimization;

namespace TesteMVC5
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles: pasta virtual
            //O bundle faz a minificação
            //Include: inclui todos os scripts em um só
            //Pode ser usado máscara (asterísco)
            //O bundles serve para minificar também
            //Pasta Content é tudo em um só e os bundles são os separados minificados desde que esteja ativado esse recurso

            //Quando for fazer o bundles, deve-se ter certeza que se pode misturar os arquivos, pois, pode acontecer de ter no javascript dois métodos com o mesmo nome e ao aplicar
            //o bundles e o minification, voce não saberá qual deles está sendo chamado por questão com o mesmo nome

            //BundleTable.EnableOptimizations = true: habilita a otimização no localhost
            //Com a minificação ativada, o nome de algumas variáveis podem ser alteradas para que o arquivo fique ainda menor
            //Comentários são retirados
            //Espaços retirados
            //A desvantagem se dá ao fato de se depurar um código que está na mesma linha

            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/testes").Include(
                        "~/Scripts/teste1.js",
                        "~/Scripts/teste2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
