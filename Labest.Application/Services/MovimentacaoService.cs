using Labest.Application.DTOs;
using Labest.Domain.Entities;
using Labest.Domain.Interfaces;

namespace Labest.Application.Services
{
    public class MovimentacaoService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;

        public MovimentacaoService(
            IProdutoRepository produtoRepository,
            IMovimentacaoRepository movimentacaoRepository)
        {
            _produtoRepository = produtoRepository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<MovimentacaoResponseDto> Movimentar(Guid produtoId, TipoMovimentacao tipo, int quantidade)
        {
            var produto = await _produtoRepository.ObterPorId(produtoId);

            if (produto == null)
                throw new Exception("Produto não encontrado");

            produto.Movimentar(tipo, quantidade);

            await _produtoRepository.Atualizar(produto);

            var movimentacao = new MovimentacaoEstoque(produtoId, tipo, quantidade);

            await _movimentacaoRepository.Adicionar(movimentacao);

            return new MovimentacaoResponseDto
            {
                Id = movimentacao.Id,
                ProdutoId = movimentacao.ProdutoId,
                ProdutoNome = movimentacao.Produto.Nome,
                Tipo = movimentacao.Tipo.ToString(),
                Quantidade = movimentacao.Quantidade,
                Data = movimentacao.DataMovimentacao
            };
        }

        public async Task<IEnumerable<MovimentacaoEstoque>> ObterPorProduto(Guid produtoId)
        {
            return await _movimentacaoRepository.ObterPorProdutoId(produtoId);
        }

        public async Task<IEnumerable<MovimentacaoResponseDto>> ObterTodos()
        {
            var movimentacoes = await _movimentacaoRepository.ObterTodos();

            return movimentacoes.Select(m => new MovimentacaoResponseDto
            {
                Id = m.Id,
                ProdutoId = m.ProdutoId,
                ProdutoNome = m.Produto.Nome,
                Tipo = m.Tipo.ToString(),
                Quantidade = m.Quantidade,
                Data = m.DataMovimentacao,
            });
        }
    }
}
