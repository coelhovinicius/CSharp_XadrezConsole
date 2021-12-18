/* >>> CLASSE REI - PASTA XADREZ <<< */
using Tabuleiro;

namespace Xadrez // Alterado
{
    class Rei : Peca
    {
        private PartidaDeXadrez Partida; // Acessa a partida para que o Rei possa utilizar a jogada Roque sem se colocar em Xeque

        // Construtor passando os argumentos para a Superclasse
        public Rei(TabuleiroClasse tab, Cor cor, PartidaDeXadrez partida) : base(tab, cor)
        {
            this.Partida = partida;
        }
        public Rei(TabuleiroClasse tab, Cor cor) : base(tab, cor) // Repassa a instrucao para a Superclasse
        {
        }

        public override string ToString() // override ToString retornando a letra "R"
        {
            return "R";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor; // Caso a posicao esteja vazia, movimenta a peca (captura a peca adversaria)
        }

        private bool TesteTorreParaRoque(Posicao pos) // Teste para verificar se a Torre pode participar do Roque
        {
            Peca p = Tab.Peca(pos);
            return p != null && p is Torre && p.Cor == Cor && p.QtdeMovimentos == 0;

        }

        public override bool[,] MovimentosPossiveis() // Metodo para controlar os movimentos do Rei
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas]; // Matriz Booleana para controlar as posicoes do tabuleiro

            Posicao pos = new Posicao(0, 0); // Teste para instanciar uma posicao

            // Verificacao das casas para movimentacao
            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna); // Verificacao Acima
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1); // Verificacao Acima a Esquerda
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha, Posicao.Coluna - 1); // Verificacao a Esquerda
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1); // Verificacao Abaixo a Esquerda
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna); // Verificacao Abaixo
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1); // Verificacao Abaixo a Direita
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha, Posicao.Coluna + 1); // Verificacao a Direita 
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1); // Verificacao Acima a Direita
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            // #jogadaespecial - Roque
            if (QtdeMovimentos == 0 && !Partida.Xeque) // Verifica se esta em Xeque
            {
                // #jogadaespecial - Roque Pequeno
                Posicao posT1 = new Posicao(Posicao.Linha, Posicao.Coluna + 3); // Faz se a Torre esta no lugar certo para Roque
                if (TesteTorreParaRoque(posT1)) // Se a Torre puder participar do Roque Pequeno
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna + 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna + 2);
                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null) // Verifica se as posicoes do Roque estao livres
                    {
                        mat[Posicao.Linha, Posicao.Coluna + 2] = true;
                    }
                }

                // #jogadaespecial - Roque Grande
                Posicao posT2 = new Posicao(Posicao.Linha, Posicao.Coluna - 4); // Faz se a Torre esta no lugar certo para Roque
                if (TesteTorreParaRoque(posT2)) // Se a Torre puder participar do Roque Grande
                {
                    Posicao p1 = new Posicao(Posicao.Linha, Posicao.Coluna - 1);
                    Posicao p2 = new Posicao(Posicao.Linha, Posicao.Coluna - 2);
                    Posicao p3 = new Posicao(Posicao.Linha, Posicao.Coluna - 3);

                    if (Tab.Peca(p1) == null && Tab.Peca(p2) == null && Tab.Peca(p3) == null)
                    {
                        mat[Posicao.Linha, Posicao.Coluna - 2] = true;
                    }
                }
            }

            return mat;
        }
    }
}
