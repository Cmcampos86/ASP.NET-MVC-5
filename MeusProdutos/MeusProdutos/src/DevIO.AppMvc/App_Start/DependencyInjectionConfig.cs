using System.Reflection;
using System.Web.Mvc;
using DevIO.AppMvc.App_Start;
using DevIO.Business.Core.Notificacoes;
using DevIO.Business.Model.Fornecedores;
using DevIO.Business.Model.Fornecedores.Services;
using DevIO.Business.Model.Produtos;
using DevIO.Business.Model.Produtos.Services;
using DevIO.Infra.Data.Context;
using DevIO.Infra.Data.Repository;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace DevIO.AppMvc
{
    public class DependencyInjectionConfig
    {
        //Adiciona o RegisterDIContainerno Startup.cs
        public static void RegisterDIContainer()
        {
            //É um container que cria a instancia do objeto e atua junto com a sua Controller Factory

            //Definie o Container
            var container = new Container();

            //Qual o life style. Escopo de uma aplicação Web (WebRequestLifestyle)
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            //Criação dos objetos
            InitializeContainer(container);

            //Regista as controllers
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            //Verificação se esta correta
            container.Verify();

            //SetResolver já é uma classe do MVC (suporte a injeção de dependencia) que vai passar a instancia do injetor de dependencia (Simple Injector) junto do container
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void InitializeContainer(Container container)
        {
            // Lifestyle.Singleton
            // Uma única instância por aplicação (pega a instancia que já esta em memória)
            // Não utilizar em objetos que trabalha com Banco de Dados

            // Lifestyle.Transient
            // Cria uma nova instância para cada injeção

            //Lifestyle.Scoped
            // Uma única instância por request (somente para aplicação Web)
            //É um Singleton mas para request

            //Alteração na classe do Repository do Context
            container.Register<MeuDbContext>(Lifestyle.Scoped);

            //Eu passo a interface e depois a classe que indica que será criada a instancia dela
            //Se atentar a dependencia da instancia dos objetos dependentes
            container.Register<IProdutoRepository, ProdutoRepository>(Lifestyle.Scoped);
            container.Register<IProdutoService, ProdutoService>(Lifestyle.Scoped);
            container.Register<IFornecedorRepository, FornecedorRepository>(Lifestyle.Scoped);
            container.Register<IEnderecoRepository, EnderecoRepository>(Lifestyle.Scoped);
            container.Register<IFornecedorService, FornecedorService>(Lifestyle.Scoped);
            container.Register<INotificador, Notificador>(Lifestyle.Scoped);

            //Funciona com o Singleton
            container.RegisterSingleton(() => AutoMapperConfig.GetMapperConfiguration().CreateMapper(container.GetInstance));
        }
    }
}