using DevIO.Business.Model.Fornecedores;
using System;
using System.Threading.Tasks;
using System.Data.Entity;
using DevIO.Infra.Data.Context;

namespace DevIO.Infra.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)//Join
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id)
        {
            return await Db.Fornecedores.AsNoTracking()
                .Include(f => f.Endereco)//Join
                .Include(f => f.Produtos)//Join
                .FirstOrDefaultAsync(f => f.Id == id);
        }

        //public override async Task Remover(Guid id)
        //{
        //    //O Remover do genérico exclui um fornecedor, mas eu posso sobrescrever o Remover (está como virtual no genérico)
        //    //com o override e atualizar alguma propriedade que indique que o fornecedor está inativo, por exemplo.

        //    var fornecedor = await ObterPorId(id);
        //    fornecedor.Ativo = false;

        //    await Atualizar(fornecedor);
        //}
    }
}
