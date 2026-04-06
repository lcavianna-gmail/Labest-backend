using Labest.Domain.Entities;

namespace Labest.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
        Task Adicionar(Produto produto);
        Task Atualizar(Produto produto);
        Task Excluir(Produto produto);
    }
}
