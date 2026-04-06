namespace Labest.Domain.Entities
{
    public class Produto
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public decimal Preco { get; private set; }
        public int Quantidade { get; private set; }

        public Produto(string nome, decimal preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public void Atualizar(string nome, decimal preco, int quantidade)
        {
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public void Movimentar(TipoMovimentacao tipo, int quantidade)
        {
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade inválida.");

            if (tipo == TipoMovimentacao.Saida)
            {
                if (Quantidade < quantidade)
                    throw new InvalidOperationException("Estoque insuficiente.");

                Quantidade -= quantidade;
            }
            else
            {
                Quantidade += quantidade;
            }
        }
    }
}
