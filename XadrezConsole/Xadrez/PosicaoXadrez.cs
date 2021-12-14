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

        public Posicao ToPosicao() // Faz o ajuste da posicao do xadrez com a posicao da matriz
        {
            return new Posicao(8 - Linha, Coluna -'a'); /* A letra 'a' entre aspas simples indica ao programa compilar a logica
                                                         * utilizando a representacao Binaria dessa letra ("a" minusculo); */
        }

        public override string ToString()
        {
            return "" + Coluna + Linha; // As Aspas Vazias forcam a conversao para string, evitando erros
        }
    }
}
