/* >>> CLASSE TABULEIROCLASSE - PASTA TABULEIRO <<< */
namespace Tabuleiro // Alterado
{
    class TabuleiroClasse
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private readonly Peca[,] Pecas;

        public TabuleiroClasse(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }

        public Peca Peca(int linha, int coluna)
        {
            return Pecas[linha, coluna];
        }

        public Peca Peca(Posicao pos) // Sobrecarga do metodo "Peca"
        {
            return Pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos)
        {
            ValidarPosicao(pos); // Verifica se ha excecoes
            return Peca(pos) != null;

        }

        public void ColocarPeca(Peca p, Posicao pos)
        {
            if (ExistePeca(pos))
            {
                throw new TabuleiroException("Ja existe uma peca na posicao selecionada!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public bool PosicaoValida(Posicao pos)
        {
            if (pos.Linha < 0 || pos.Linha >= Linhas || pos.Coluna < 0 || pos.Coluna >= Colunas)
            {
                return false;
            }
            return true;
        }

        public void ValidarPosicao(Posicao pos)
        {
            if (!PosicaoValida(pos))
            {
                throw new TabuleiroException("Posicao Invalida!");
            }
        }
    }
}
