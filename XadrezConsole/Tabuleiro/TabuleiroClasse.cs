/* >>> CLASSE TABULEIROCLASSE - PASTA TABULEIRO <<< */
namespace Tabuleiro // Alterado
{
    class TabuleiroClasse
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; } 
        private Peca[,] Pecas; // "private" impede acesso por classes externas

        public TabuleiroClasse(int linhas, int colunas) // Define o numero de linhas e colunas do tabuleiro
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
            if (ExistePeca(pos)) // Testa quaisquer excecoes referentes a posicao da peca no tabuleiro
            {
                throw new TabuleiroException("Ja existe uma peca na posicao selecionada!");
            }
            Pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos)
        {
            if (Peca(pos) == null){ // Se nao houver peca na posicao informada
                return null;
            }
            Peca aux = Peca(pos); // Variavel auxiliar recebendo a peca contida na posicao informada
            aux.Posicao = null; // Indica que a peca nao pertence a nenhuma posicao, ao ser retirada
            Pecas[pos.Linha, pos.Coluna] = null; // Indica que a posicao, anteriormente ocupada, agora, esta vazia
            return aux; // Retorna a variavel auxiliar, onde esta armazenada a peca selecionada
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
                throw new TabuleiroException("Posicao Invalida!"); // Lanca excecao
            }
        }
    }
}
