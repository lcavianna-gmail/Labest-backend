using Labest.Domain.Entities;
using Labest.Domain.Interfaces;
using Labest.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Labest.Infra.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly ApplicationDbContext _context;

        public MovimentacaoRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Adicionar(MovimentacaoEstoque movimentacao)
        {
            await _context.Movimentacoes.AddAsync(movimentacao);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MovimentacaoEstoque>> ObterPorProdutoId(Guid produtoId)
        {
            return await _context.Movimentacoes
                .Where(m => m.ProdutoId == produtoId)
                .ToListAsync();
        }
    }
}
