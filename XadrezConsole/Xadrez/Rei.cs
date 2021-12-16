/* >>> CLASSE REI - PASTA XADREZ <<< */
using Tabuleiro;

namespace Xadrez // Alterado
{
    class Rei : Peca
    {
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

            return mat;
        }
    }
}
