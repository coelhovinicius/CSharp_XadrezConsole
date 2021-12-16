/* >>> CLASSE PARTIDADEXADREZ - PASTA XADREZ <<<
        - Classe contendo a Mecanica de uma Partida de Xadrez
*/
using System.Collections.Generic;
using Tabuleiro;

namespace Xadrez
{
    class PartidaDeXadrez
    {
        public TabuleiroClasse Tab { get; private set; } // Cria uma variavel para as definicoes do tabuleiro de xadrez
        public int Turno { get; private set; } // Variavel para controlar os turnos jogados
        public Cor JogadorAtual { get; private set; }// Variavel para controlar a vez de quem joga
        public bool Terminada { get; private set; } // Indica se a partida terminou ou nao
        // Colecao de dados que obedecem as regras de Conjuntos
        private HashSet<Peca> Pecas; // Colecao de todas as pecas do jogo
        private HashSet<Peca> Capturadas; // Colecao das pecas capturadas

        public PartidaDeXadrez()
        {
            Tab = new TabuleiroClasse(8, 8); // Define as dimensoes da matriz para o tabuleiro de xadrez
            Turno = 1; // Inicia com o turno 1
            JogadorAtual = Cor.Branca; // Inicia com o jogador das pecas brancas (regra do xadrez)
            Terminada = false; // Indica que a partida ainda esta em andamento
            Pecas = new HashSet<Peca>(); // Instancia o Conjunto "Pecas"
            Capturadas = new HashSet<Peca>(); // Instancia o Conjunto "Capturadas"
            ColocarPecas(); // Metodo auxiliar para
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) // Metodo para executar os movimentos
        {
            Peca p = Tab.RetirarPeca(origem); // Retira a peca da posicao de origem (a posicao em que ela esta no momento)
            p.IncrementarQtdeMovimentos(); // Adiciona um movimento ao jogador
            Peca pecaCapturada = Tab.RetirarPeca(destino); // Retira (captura) a peca que esta no destino do movimento, caso haja
            Tab.ColocarPeca(p, destino); // Adiciona a peca a posicao de destino
            if (pecaCapturada != null) // Caso haja peca na posicao
            {
                Capturadas.Add(pecaCapturada); // Adiciona a peca ao Conjunto "Capturadas"
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoDeOrigem(Posicao pos)
        {
            if (Tab.Peca(pos) == null)
            {
                throw new TabuleiroException("Nao existe peca na posicao de origem escolhida.");
            }
            if (JogadorAtual != Tab.Peca(pos).Cor)
            {
                throw new TabuleiroException("Peca adversaria!");
            }
            if (!Tab.Peca(pos).ExisteMovimentosPossiveis())
            {
                throw new TabuleiroException("Nao ha movimentos possiveis para a peca selecionada.");
            }
        }

        public void ValidarPosicaoDeDestino(Posicao origem, Posicao destino)
        {
            if (!Tab.Peca(origem).PodeMoverPara(destino))
            {
                throw new TabuleiroException("Posicao de destino invalida.");
            }
        }

        private void MudaJogador() // Passagem de turno
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>(); // Conjunto auxiliar temporario do tipo "Peca"
            foreach (Peca x in Capturadas) // Variavel auxiliar para percorrer todas as pecas no Conjunto "Capturadas"
            {
                if (x.Cor == cor) // Se for da mesma cor
                {
                    aux.Add(x); // Adiciona a peca da cor correspondente ao conjunto auxiliar "x"
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>(); // Conjunto auxiliar temporario do tipo "Peca"
            foreach (Peca x in Pecas) // Variavel auxiliar para percorrer todas as pecas no Conjunto "Capturadas"
            {
                if (x.Cor == cor) // Se for da mesma cor
                {
                    aux.Add(x); // Adiciona a peca da cor correspondente ao conjunto auxiliar "x"
                }
            }
            aux.ExceptWith(PecasCapturadas(cor)); // Retira as pecas capturadas da cor correspondente
            return aux;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao()); // Utilizacao do metodo ToPosicao
            Pecas.Add(peca); // Guarda as pecas no Conjunto "Pecas"
        }

        private void ColocarPecas()
        {
            ColocarNovaPeca('c', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tab, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tab, Cor.Preta));

            /* Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            Tab.ColocarPeca(new Torre(Tab, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            Tab.ColocarPeca(new Rei(Tab, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao()); */
        }
    }
}
