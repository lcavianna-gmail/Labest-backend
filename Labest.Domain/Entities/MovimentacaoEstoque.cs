using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Labest.Domain.Entities
{
    public enum TipoMovimentacao
    {
        Entrada = 1,
        Saida = 2
    }

    public class MovimentacaoEstoque
    {
        public Guid Id { get; private set; }
        public Guid ProdutoId { get;  set; }
        public Produto Produto { get;  set; }
        public TipoMovimentacao Tipo { get;  set; }
        public int Quantidade { get;  set; }
        public DateTime DataMovimentacao { get;  set; }


        public MovimentacaoEstoque(Guid produtoId, TipoMovimentacao tipo, int quantidade)
        {
            Id = Guid.NewGuid();
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade inválida.");

            ProdutoId = produtoId;
            Tipo = tipo;
            Quantidade = quantidade;
            DataMovimentacao = DateTime.Now;
        }
    }
}
