/* >>> CLASSE REI - PASTA XADREZ <<< */
using Tabuleiro;

namespace Xadrez // Alterado
{
    class Rei : Peca
    {
        public Rei(TabuleiroClasse tab, Cor cor) : base(tab, cor) // Repassa a instrucao para a Superclasse
        {
        }

        public override string ToString() // override ToString retornando a letra "R"
        {
            return "R";
        }
    }
}
