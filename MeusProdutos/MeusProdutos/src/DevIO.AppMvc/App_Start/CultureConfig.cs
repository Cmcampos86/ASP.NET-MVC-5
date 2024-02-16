using System.Globalization;

namespace DevIO.AppMvc
{
    public class CultureConfig
    {
        public static void RegisterCulture()
        {
            //Configuração de cultura
            var culture = new CultureInfo("pt-BR"); //Cultura Brasil
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.CurrentCulture = culture; 
            CultureInfo.CurrentUICulture = culture;
        }
    }
}