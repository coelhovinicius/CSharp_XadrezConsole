/* >>> CLASSE CAVALO - PASTA XADREZ <<< */
using Tabuleiro;

namespace Xadrez
{
    class Cavalo : Peca
    {
        public Cavalo(TabuleiroClasse tab, Cor cor) : base(tab, cor)
        {
        }

        public override string ToString() // override ToString retornando a letra "R"
        {
            return "C";
        }

        private bool PodeMover(Posicao pos)
        {
            Peca p = Tab.Peca(pos);
            return p == null || p.Cor != Cor; // Caso a posicao esteja vazia, movimenta a peca (captura a peca adversaria)
        }

        public override bool[,] MovimentosPossiveis() // Metodo para controlar os movimentos do Cavalo
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas]; // Matriz Booleana para controlar as posicoes do tabuleiro

            Posicao pos = new Posicao(0, 0); // Teste para instanciar uma posicao

            // Verificacao das casas para movimentacao
            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna - 1); // Verificacao Dois Acima a Um a Esquerda
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna + 1); // Verificacao Dois a Acima e Um a Direita
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 2); // Verificacao Dois a Esquerda e Um Acima
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna -2); // Verificacao Dois a Esquerda e Em Abaixo
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna - 1); // Verificacao Dois a Abaixo e Um a Esquerda
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna + 1); // Verificacao Dois Abaixo e Um a Direita
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 2); // Verificacao Dois a Direita e um Abaixo
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 2); // Verificacao Dois a Direita e um Acima
            if (Tab.PosicaoValida(pos) && PodeMover(pos)) // Valida a posicao e verifica se pode mover
            {
                mat[pos.Linha, pos.Coluna] = true; // Determina que o movimento pode ser executado
            }

            return mat;
        }
    }
}
