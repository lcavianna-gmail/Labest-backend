using Labest.Domain.Entities;
using Labest.Domain.Interfaces;
using Labest.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Labest.Infra.Repositories
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly ApplicationDbContext _context;

        public ProdutoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
            => await _context.Produtos.ToListAsync();

        public async Task<Produto> ObterPorId(Guid id)
            => await _context.Produtos.FindAsync(id);

        public async Task Adicionar(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(Produto produto)
        {
            _context.Produtos.Update(produto);
            await _context.SaveChangesAsync();
        }
    }
}
