using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AppMvc.Startup))]
namespace AppMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ASP.Net Identity: Controle de gestão de usuários(cadastro, permissões e etc)
            //Criar o projeto já com Identity (mais fácil)
            //Quando se cria uma aplicação com Identity, trocar o nome do banco e mdf no arquivo config, porque por padrão fica com um nome muito grande
            ConfigureAuth(app);
        }
    }
}
