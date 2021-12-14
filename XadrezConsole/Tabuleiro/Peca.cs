/* >>> CLASSE PECA - PASTA TABULEIRO */
namespace Tabuleiro // Alterado
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; } // "protected set" - So pode ser alterada pela classe e suas subclasses
        public int QtdeMovimentos { get; protected set; }
        public TabuleiroClasse Tab { get; protected set; }

        public Peca(TabuleiroClasse tab, Cor cor)
        {
            this.Posicao = null;
            this.Tab = tab;
            this.Cor = cor;
            QtdeMovimentos = 0;
        }

        public void IncrementarQtdeMovimentos() // Controla a quantidade de movimentos dos jogadores na partida
        {
            QtdeMovimentos++;
        }
    }
}
