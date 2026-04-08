using Labest.Domain.Entities;

namespace Labest.Application.DTOs
{
    public class MovimentacaoResponseDto
    {
        public Guid Id { get; set; }

        public Guid ProdutoId { get; set; }

        public string ProdutoNome { get; set; } = string.Empty;

        public string Tipo { get; set; } = string.Empty;

        public int Quantidade { get; set; }

        public DateTime Data { get; set; }
    }
}
