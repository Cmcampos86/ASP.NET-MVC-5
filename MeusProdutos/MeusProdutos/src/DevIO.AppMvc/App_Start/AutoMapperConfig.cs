using AutoMapper;
using DevIO.AppMvc.ViewModels;
using DevIO.Business.Model.Fornecedores;
using DevIO.Business.Model.Produtos;
using System;
using System.Linq;
using System.Reflection;

namespace DevIO.AppMvc.App_Start
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            var profiles = Assembly.GetExecutingAssembly() //Todos os Assembly executados
                .GetTypes() //Todos os tipos
                .Where(x => typeof(Profile).IsAssignableFrom(x)); //Tipo Profile

            return new MapperConfiguration(cfg =>
            {
                foreach (var profile in profiles)
                {
                    cfg.AddProfile(Activator.CreateInstance(profile) as Profile);//Cria a instância do tipo Profile
                }
            });
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //ReverseMap() mapeamento vice-versa

            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, FornecedorViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();

        }
    }
}