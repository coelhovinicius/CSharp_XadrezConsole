/* >>> CLASSE POSICAOXADREZ - PASTA XADREZ <<< */
using Tabuleiro;
namespace Xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; } // No Xadrez, as Colunas sao representadas por Letras
        public int Linha { get; set; } // No Xadrez, as Linhas sao representadas por Numeros

        public PosicaoXadrez(char coluna, int linha)
        {
            this.Coluna = coluna;
            this.Linha = linha;
        }

        public Posicao ToPosicao() // Faz o ajuste da posicao informada com a posicao na matriz
        {
            return new Posicao(8 - Linha, Coluna -'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linha;
        }
    }
}
