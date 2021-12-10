using Tabuleiro;

namespace Xadrez // Alterado
{
    class Torre : Peca
    {
        public Torre(TabuleiroClasse tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "T";
        }
    }
}
