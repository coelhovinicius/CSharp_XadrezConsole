/* >>> CLASSE REI - PASTA XADREZ <<< */
using Tabuleiro;

namespace Xadrez // Alterado
{
    class Rei : Peca
    {
        public Rei(TabuleiroClasse tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "R";
        }
    }
}
