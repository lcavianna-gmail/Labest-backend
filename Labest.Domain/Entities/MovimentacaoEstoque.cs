namespace Labest.Domain.Entities
{
    public enum TipoMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }

    public class MovimentacaoEstoque
    {
        public Guid Id { get; set; }
        public Guid ProdutoId { get; set; }
        public Produto Produto { get; set; }
        public TipoMovimentacao Tipo { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataMovimentacao { get; set; }
    }
}
