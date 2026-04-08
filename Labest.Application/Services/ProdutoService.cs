using Labest.Application.DTOs;
using Labest.Domain.Entities;
using Labest.Domain.Interfaces;
using Labest.Infra.Repositories;

namespace Labest.Application.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;
        private readonly IMovimentacaoRepository _movimentacaoRepository;


        public ProdutoService(IProdutoRepository repository, IMovimentacaoRepository movimentacaoRepository)
        {
            _repository = repository;
            _movimentacaoRepository = movimentacaoRepository;
        }

        public async Task<IEnumerable<ProdutoResponseDto>> ObterTodos()
        {
            var produtos = await _repository.ObterTodos();

            return produtos.Select(p => new ProdutoResponseDto
            {
                Id = p.Id,
                Nome = p.Nome,
                Preco = p.Preco,
                Quantidade = p.Quantidade
            });
        }

        public async Task<ProdutoResponseDto> Adicionar(ProdutoCreateDto dto)
        {
            var produto = new Produto(dto.Nome, dto.Preco, dto.Quantidade);

            await _repository.Adicionar(produto);

            // 🔥 REGRA DE NEGÓCIO
            if (dto.Quantidade > 0)
            {
                var movimentacao = new MovimentacaoEstoque(
                    produto.Id,
                    TipoMovimentacao.Entrada,
                    dto.Quantidade
                );

                await _movimentacaoRepository.Adicionar(movimentacao);
            }


            return new ProdutoResponseDto
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade
            };
        }

        public async Task<ProdutoSaldoDto> ObterSaldo(Guid id)
        {
            var produto = await _repository.ObterPorId(id);

            if (produto == null)
                throw new Exception("Produto não encontrado");

            return new ProdutoSaldoDto
            {
                ProdutoId = produto.Id,
                Nome = produto.Nome,
                QuantidadeEstoque = produto.Quantidade
            };
        }

        public async Task Atualizar(Guid id, ProdutoUpdateDto dto)
        {
            var produto = await _repository.ObterPorId(id);

            if (produto == null)
                throw new Exception("Produto não encontrado");

            produto.Atualizar(dto.Nome,dto.Preco,dto.Quantidade);

            await _repository.Atualizar(produto);
        }

        public async Task Remover(Guid id)
        {
            var produto = await _repository.ObterPorId(id);

            if (produto == null)
                throw new Exception("Produto não encontrado");

            await _repository.Excluir(produto);
        }
    }
}
