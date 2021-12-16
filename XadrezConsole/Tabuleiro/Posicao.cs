/* >>> CLASSE POSICAO - PASTA TABULEIRO <<< */
namespace Tabuleiro // Alterado de "XadrezConsole.Tabuleiro" para "Tabuleiro"
{
    class Posicao
    {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        public Posicao(int linha, int coluna)
        {
            this.Linha = linha; // "this" atribui o valor diretamento ao novo objeto instanciado
            this.Coluna = coluna;
        }

        public void DefinirValores(int linha, int coluna) // Metodo para definir valores da posicao
        {
            this.Linha = linha; // "this" atribui o valor diretamento ao novo objeto instanciado
            this.Coluna = coluna;
        }

        public override string ToString()
        {
            return Linha + ", " + Coluna;
        }
    }
}
