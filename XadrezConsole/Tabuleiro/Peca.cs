/* >>> CLASSE PECA - PASTA TABULEIRO */
namespace Tabuleiro // Alterado
{
    class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdeMovimentos { get; protected set; }
        public TabuleiroClasse Tabuleiro { get; protected set; }

        public Peca(Posicao posicao, TabuleiroClasse tab, Cor cor)
        {
            this.Posicao = posicao;
            this.Tabuleiro = tab;
            this.Cor = cor;
            QtdeMovimentos = 0;
        }
    }
}
