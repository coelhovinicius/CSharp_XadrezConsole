/* >>> CLASSE PARTIDADEXADREZ - PASTA XADREZ <<<
        - Classe contendo a Mecanica de uma Partida de Xadrez
*/
using System;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public TabuleiroClasse tab { get; private set; } // Cria uma variavel para as definicoes do tabuleiro de xadrez
        private int turno; // Variavel para controlar os turnos jogados
        private Cor JogadorAtual; // Variavel para controlar a vez de quem joga
        public bool Terminada { get; private set; } // Indica se a partida terminou ou nao

        public PartidaDeXadrez()
        {
            tab = new TabuleiroClasse(8, 8); // Define as dimensoes da matriz para o tabuleiro de xadrez
            turno = 1; // Inicia com o turno 1
            JogadorAtual = Cor.Branca; // Inicia com o jogador das pecas brancas (regra do xadrez)
            Terminada = false; // Indica que a partida ainda esta em andamento
            ColocarPecas(); // Metodo auxiliar para
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) // Metodo para executar os movimentos
        {
            Peca p = tab.RetirarPeca(origem); // Retira a peca da posicao de origem (a posicao em que ela esta no momento)
            p.IncrementarQtdeMovimentos(); // Adiciona um movimento ao jogador
            Peca pecaCapturada = tab.RetirarPeca(destino); // Retira (captura) a peca que esta no destino do movimento, caso haja
            tab.ColocarPeca(p, destino); // Adiciona a peca a posicao de destino
        }

        private void ColocarPecas()
        {
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao()); // Utilizacao do metodo ToPosicao
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            tab.ColocarPeca(new Rei(tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}
