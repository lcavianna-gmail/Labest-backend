using Labest.Domain.Entities;

namespace Labest.Domain.Interfaces
{
    public interface IMovimentacaoRepository
    {
        Task Adicionar(MovimentacaoEstoque movimentacao);
        Task<IEnumerable<MovimentacaoEstoque>> ObterPorProdutoId(Guid produtoId);
        Task<IEnumerable<MovimentacaoEstoque>> ObterTodos();
    }
}
