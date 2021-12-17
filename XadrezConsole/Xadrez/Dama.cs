/* >>> CLASSE DAMA - PASTA XADREZ <<< */
using Tabuleiro;

namespace Xadrez
{
    class Dama : Peca
    {
        public Dama(TabuleiroClasse tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString()
        {
            return "D";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor; // Caso a posicao esteja vazia, movimenta a peca (captura a peca adversaria)
        }

        public override bool[,] MovimentosPossiveis() // Metodo para controlar os movimentos da Dama
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas]; // Matriz Booleana para controlar as posicoes do tabuleiro

            Posicao pos = new Posicao(0, 0); // Teste para instanciar uma posicao

            // Verificacao das casas para movimentacao
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna); // Verifica Acima
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) // Caso haja uma peca na posicao e ela seja do adversario
                {
                    break; // Encerra a movimentacao
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna);
                // pos.Linha = pos.Linha - 1; // Se nao, movimenta a peca
            }

            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1); // Verifica a Esquerda
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) // Caso haja uma peca na posicao e ela seja do adversario
                {
                    break; // Encerra a movimentacao
                }
                pos.DefinirValores(pos.Linha, pos.Coluna - 1);
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna); // Verifica Abaixo
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) // Caso haja uma peca na posicao e ela seja do adversario
                {
                    break; // Encerra a movimentacao
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna);
            }

            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1); // Verifica a Direita
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) // Caso haja uma peca na posicao e ela seja do adversario
                {
                    break; // Encerra a movimentacao
                }
                pos.DefinirValores(pos.Linha, pos.Coluna + 1);
            }

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1); // Verificacao Acima a Esquerda
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) // Caso haja uma peca na posicao e ela seja do adversario
                {
                    break; // Encerra a movimentacao
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna - 1);
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1); // Verificacao Abaixo a Esquerda
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) // Caso haja uma peca na posicao e ela seja do adversario
                {
                    break; // Encerra a movimentacao
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna - 1);
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1); // Verificacao Abaixo a Direita
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) // Caso haja uma peca na posicao e ela seja do adversario
                {
                    break; // Encerra a movimentacao
                }
                pos.DefinirValores(pos.Linha + 1, pos.Coluna + 1);
            }

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1); // Verificacao Acima a Direita
            while (Tab.PosicaoValida(pos) && PodeMover(pos))
            {
                mat[pos.Linha, pos.Coluna] = true;
                if (Tab.Peca(pos) != null && Tab.Peca(pos).Cor != Cor) // Caso haja uma peca na posicao e ela seja do adversario
                {
                    break; // Encerra a movimentacao
                }
                pos.DefinirValores(pos.Linha - 1, pos.Coluna + 1);
            }

            return mat;
        }
    }
}
