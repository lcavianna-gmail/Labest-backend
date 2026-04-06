using Labest.Domain.Entities;

namespace Labest.Application.DTOs
{
    public class MovimentacaoRequestDto
    {
        public Guid ProdutoId { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
    }
}
