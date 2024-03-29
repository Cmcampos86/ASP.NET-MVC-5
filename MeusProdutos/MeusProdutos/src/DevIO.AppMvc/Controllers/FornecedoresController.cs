﻿using AutoMapper;
using DevIO.AppMvc.Extensions;
using DevIO.AppMvc.ViewModels;
using DevIO.Business.Core.Notificacoes;
using DevIO.Business.Model.Fornecedores;
using DevIO.Business.Model.Fornecedores.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DevIO.AppMvc.Controllers
{
    //Tem que estar logado para acessar todos os métodos da controller
    [Authorize]
    public class FornecedoresController : BaseController
    {
        #region Teste

        //private readonly IFornecedorService _fornecedorService;

        //public FornecedoresController()
        //{
        //    _fornecedorService = new FornecedorService(new FornecedorRepository(), new EnderecoRepository());
        //}

        //// GET: Fornecedores
        //public async Task<ActionResult> Index()
        //{
        //    var fornecedor = new Fornecedor()
        //    {
        //        Nome = "Claudio",
        //        Documento = "35654022881",
        //        Endereco = new Endereco()
        //        {
        //            Logradouro = "Rua Teste",
        //            Numero = "123",
        //            Complemento = "Teste",
        //            Bairro = "Teste",
        //            Cep = "12345678",
        //            Cidade = "Teste",
        //            Estado = "Teste"
        //        },
        //        TipoFornecedor = TipoFornecedor.PessoaFisica,
        //        Ativo = true
        //    };

        //    await _fornecedorService.Adicionar(fornecedor);

        //    return new EmptyResult();
        //}

        #endregion

        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IMapper mapper,
                                      IFornecedorService fornecedorService,
                                      INotificador notificador) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
        }

        [AllowAnonymous] //Permite que o usuário acesse esse método
        [Route("lista-de-fornecedores")]
        public async Task<ActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos()));
        }

        [AllowAnonymous] //Permite que o usuário acesse esse método
        [Route("dados-do-fornecedor/{id:guid}")]
        public async Task<ActionResult> Details(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(fornecedorViewModel);
        }

        //Cadastrar a claim na tabela AspNetUserClaims passando o idUser, a claimName e a claimValue
        //Na claimValue eu posso passar mais de valor separado por vírgula
        //Cuidado para não exagerar no ClaimValue, pois, ele é registrado no Cookie que pode estourar
        [ClaimsAuthorize("Fornecedor", "Adicionar")]
        [Route("novo-fornecedor")]
        public ActionResult Create()
        {
            return View();
        }

        [ClaimsAuthorize("Fornecedor", "Adicionar")]
        [Route("novo-fornecedor")]
        [HttpPost]
        public async Task<ActionResult> Create(FornecedorViewModel fornecedorViewModel)
        {
            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorService.Adicionar(fornecedor);

            if (!OperacaoValida()) return View(fornecedorViewModel);

            return RedirectToAction("Index");
        }

        [Route("editar-fornecedor/{id:guid}")]
        public async Task<ActionResult> Edit(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorProdutosEndereco(id);

            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(fornecedorViewModel);
        }

        [Route("editar-fornecedor/{id:guid}")]
        [HttpPost]
        public async Task<ActionResult> Edit(Guid id, FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return HttpNotFound();

            if (!ModelState.IsValid) return View(fornecedorViewModel);

            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            await _fornecedorService.Atualizar(fornecedor);

            return RedirectToAction("Index");
        }

        //Acesso por perfis. Se for mais de um, pode separar por vírgula
        //Usar a tabela AspNetRoles para criar o perfil e vincular a tabela AspNetUserRoles
        //As roles são para cenários de permissão simples
        //[Authorize(Roles = "Admin")]
        [ClaimsAuthorize("Fornecedor", "Excluir")]
        [Route("excluir-fornecedor/{id:guid}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null)
            {
                return HttpNotFound();
            }

            return View(fornecedorViewModel);
        }

        //[Authorize(Roles = "Admin")] //Acesso por perfis. Se for mais de um, pode separar por vírgula
        [ClaimsAuthorize("Fornecedor", "Excluir")]
        [Route("excluir-fornecedor/{id:guid}")]
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> DeleteConfirmed(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null) return HttpNotFound();

            await _fornecedorService.Remover(id);

            return RedirectToAction("Index");
        }

        //Método que vai fazer a atualização do grid de endereços na tela quando atualizar pelo modal
        [Route("obter-endereco-fornecedor/{id:guid}")]
        public async Task<ActionResult> ObterEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DetalhesEndereco", fornecedor);
        }

        [Route("atualizar-endereco-fornecedor/{id:guid}")]
        [HttpGet]
        public async Task<ActionResult> AtualizarEndereco(Guid id)
        {
            var fornecedor = await ObterFornecedorEndereco(id);

            if (fornecedor == null)
            {
                return HttpNotFound();
            }

            //Retorna a partial view _AtualizarEndereco onde eu vou passar as informações do Endereco do Fornecedor (fornecedor.Endereco)
            return PartialView("_AtualizarEndereco", new FornecedorViewModel { Endereco = fornecedor.Endereco });
        }

        [Route("atualizar-endereco-fornecedor/{id:guid}")]
        [HttpPost]
        public async Task<ActionResult> AtualizarEndereco(FornecedorViewModel fornecedorViewModel)
        {
            //Remove a propiedade afim de não validar no ModelState
            ModelState.Remove("Nome");
            ModelState.Remove("Documento");

            if (!ModelState.IsValid) return PartialView("_AtualizarEndereco", fornecedorViewModel);

            await _fornecedorService.AtualizarEndereco(_mapper.Map<Endereco>(fornecedorViewModel.Endereco));

            //A chamada da url dentro do json quem vai fazer é o javascript para renderizar apenas o grid de endereço
            var url = Url.Action("ObterEndereco", "Fornecedores", new { id = fornecedorViewModel.Endereco.FornecedorId });
            return Json(new { success = true, url });
        }

        private async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }

        private async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }
    }
}