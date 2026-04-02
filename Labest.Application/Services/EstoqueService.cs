using Labest.Domain.Entities;
using Labest.Domain.Interfaces;
using Labest.Infra.Context;

namespace Labest.Application.Services
{
    public class EstoqueService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly ApplicationDbContext _context;

        public EstoqueService(IProdutoRepository produtoRepository,
                              ApplicationDbContext context)
        {
            _produtoRepository = produtoRepository;
            _context = context;
        }

        public async Task Movimentar(Guid produtoId, TipoMovimentacao tipo, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null)
                throw new Exception("Produto não encontrado");

            if (tipo == TipoMovimentacao.Saida && produto.QuantidadeEstoque < quantidade)
                throw new Exception("Estoque insuficiente");

            if (tipo == TipoMovimentacao.Entrada)
                produto.QuantidadeEstoque += quantidade;
            else
                produto.QuantidadeEstoque -= quantidade;

            await _produtoRepository.Atualizar(produto);

            var movimentacao = new MovimentacaoEstoque
            {
                Id = Guid.NewGuid(),
                ProdutoId = produtoId,
                Tipo = tipo,
                Quantidade = quantidade,
                DataMovimentacao = DateTime.UtcNow
            };

            await _context.Movimentacoes.AddAsync(movimentacao);
            await _context.SaveChangesAsync();
        }
    }
}
