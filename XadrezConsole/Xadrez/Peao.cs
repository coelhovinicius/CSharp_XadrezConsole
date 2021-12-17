/* >>> CLASSE PEAO - PASTA XADREZ <<< */
using Tabuleiro;

namespace Xadrez
{
    class Peao : Peca
    {
        public Peao(TabuleiroClasse tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString() // override ToString retornando a letra "R"
        {
            return "P";
        }

        private bool ExtisteAdversario(Posicao pos) // Verifica se existe peca adversaria
        {
            Peca p = Tab.Peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.Peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis() // Metodo para controlar os movimentos do Peao
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas]; // Matriz Booleana para controlar as posicoes do tabuleiro

            Posicao pos = new Posicao(0, 0); // Teste para instanciar uma posicao

            if (Cor == Cor.Branca) // Se forem pecas Brancas
            {
                // Movimento dos Peoes Brancos
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna); // Verifica movimento normal
                if (Tab.PosicaoValida(pos) && Livre(pos)) // Se existir posicao e ela estiver livre
                {
                    mat[pos.Linha, pos.Coluna] = true; // Executa o movimento
                }

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna); // Verifica se e o primeiro movimento
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdeMovimentos == 0) // Caso possa mover e seja o primeiro movimento
                {
                    mat[pos.Linha, pos.Coluna] = true; // Executa o movimento
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1); // Captura na Diagonal Esquerda das Brancas
                if (Tab.PosicaoValida(pos) && ExtisteAdversario(pos)) // Se houver adversarios na posicao valida
                {
                    mat[pos.Linha, pos.Coluna] = true; // Executa a captura
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1); // Captura na Diagonal Direita das Brancas
                if (Tab.PosicaoValida(pos) && ExtisteAdversario(pos)) // Se houver adversarios na posicao valida
                {
                    mat[pos.Linha, pos.Coluna] = true; // Executa a captura
                }
            }
            else // Se forem pecas Pretas
            {
                // Movimentos dos Peoes Pretos
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna); // Verifica movimento normal
                if (Tab.PosicaoValida(pos) && Livre(pos)) // Se existir posicao e ela estiver livre
                {
                    mat[pos.Linha, pos.Coluna] = true; // Executa o movimento
                }

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna); // Verifica se e o primeiro movimento
                if (Tab.PosicaoValida(pos) && Livre(pos) && QtdeMovimentos == 0) // Caso possa mover e seja o primeiro movimento
                {
                    mat[pos.Linha, pos.Coluna] = true; // Executa o movimento
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1); // Captura na Diagonal Esquerda das Pretas
                if (Tab.PosicaoValida(pos) && ExtisteAdversario(pos)) // Se houver adversarios na posicao valida
                {
                    mat[pos.Linha, pos.Coluna] = true; // Executa a captura
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1); // Captura na Diagonal Direita das Pretas
                if (Tab.PosicaoValida(pos) && ExtisteAdversario(pos)) // Se houver adversarios na posicao valida
                {
                    mat[pos.Linha, pos.Coluna] = true; // Executa a captura
                }
            }

            return mat;
        }
    }
}
