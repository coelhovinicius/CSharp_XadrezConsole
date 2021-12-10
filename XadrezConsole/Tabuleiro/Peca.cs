/* >>> CLASSE PECA - PASTA TABULEIRO */
namespace Tabuleiro // Alterado
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public TabuleiroClasse Tabuleiro { get; protected set; }

        public Peca(TabuleiroClasse tab, Cor cor)
        {
            this.Posicao = null;
            this.Tabuleiro = tab;
            this.Cor = cor;
            QtdeMovimentos = 0;
        }
    }
}
