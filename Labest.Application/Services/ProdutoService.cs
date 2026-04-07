using Labest.Application.DTOs;
using Labest.Domain.Entities;
using Labest.Domain.Interfaces;

namespace Labest.Application.Services
{
    public class ProdutoService
    {
        private readonly IProdutoRepository _repository;

        public ProdutoService(IProdutoRepository repository)
        {
            _repository = repository;
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
    }
}
