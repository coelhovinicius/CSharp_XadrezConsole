﻿/* >>> CLASSE PARTIDADEXADREZ - PASTA XADREZ <<<
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
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            Tab = new TabuleiroClasse(8, 8); // Define as dimensoes da matriz para o tabuleiro de xadrez
            Turno = 1; // Inicia com o turno 1
            JogadorAtual = Cor.Branca; // Inicia com o jogador das pecas brancas (regra do xadrez)
            Terminada = false; // Indica que a partida ainda esta em andamento
            Xeque = false;
            Pecas = new HashSet<Peca>(); // Instancia o Conjunto "Pecas"
            Capturadas = new HashSet<Peca>(); // Instancia o Conjunto "Capturadas"
            ColocarPecas(); // Metodo auxiliar para
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino) // Metodo para executar os movimentos
        {
            Peca p = Tab.RetirarPeca(origem); // Retira a peca da posicao de origem (a posicao em que ela esta no momento)
            p.IncrementarQtdeMovimentos(); // Adiciona um movimento ao jogador
            Peca pecaCapturada = Tab.RetirarPeca(destino); // Retira (captura) a peca que esta no destino do movimento, caso haja
            Tab.ColocarPeca(p, destino); // Adiciona a peca a posicao de destino
            if (pecaCapturada != null) // Caso haja peca na posicao
            {
                Capturadas.Add(pecaCapturada); // Adiciona a peca ao Conjunto "Capturadas"
            }
            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = Tab.RetirarPeca(destino);
            p.DecrementarQtdeMovimentos();
            if (pecaCapturada != null)
            {
                Tab.ColocarPeca(pecaCapturada, destino);
                Capturadas.Remove(pecaCapturada);
            }
            Tab.ColocarPeca(p, origem);
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);

            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("O jogador nao pode colocar a si mesmo em xeque!");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (TesteXequeMate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador();
            }
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
            if (!Tab.Peca(origem).MovimentoPossivel(destino))
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

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.Branca)
            {
                return Cor.Preta;
            }
            else
            {
                return Cor.Branca;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("Nao ha Rei da cor " + cor + " no tabuleiro!");
            }
            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }

        public bool TesteXequeMate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }
            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i = 0; i < Tab.Linhas; i++)
                {
                    for (int j = 0; j < Tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            Tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao()); // Utilizacao do metodo ToPosicao
            Pecas.Add(peca); // Guarda as pecas no Conjunto "Pecas"
        }

        private void ColocarPecas() // Coloca as pecas no tabuleiro
        {
            ColocarNovaPeca('a', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('c', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('d', 1, new Dama(Tab, Cor.Branca));
            ColocarNovaPeca('e', 1, new Rei(Tab, Cor.Branca));
            ColocarNovaPeca('f', 1, new Bispo(Tab, Cor.Branca));
            ColocarNovaPeca('g', 1, new Cavalo(Tab, Cor.Branca));
            ColocarNovaPeca('h', 1, new Torre(Tab, Cor.Branca));
            ColocarNovaPeca('a', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('b', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('c', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('d', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('e', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('f', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('g', 2, new Peao(Tab, Cor.Branca));
            ColocarNovaPeca('h', 2, new Peao(Tab, Cor.Branca));

            ColocarNovaPeca('a', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('b', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('c', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('d', 8, new Dama(Tab, Cor.Preta));
            ColocarNovaPeca('e', 8, new Rei(Tab, Cor.Preta));
            ColocarNovaPeca('f', 8, new Bispo(Tab, Cor.Preta));
            ColocarNovaPeca('g', 8, new Cavalo(Tab, Cor.Preta));
            ColocarNovaPeca('h', 8, new Torre(Tab, Cor.Preta));
            ColocarNovaPeca('a', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('b', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('c', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('d', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('e', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('f', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('g', 7, new Peao(Tab, Cor.Preta));
            ColocarNovaPeca('h', 7, new Peao(Tab, Cor.Preta));
        }
    }
}
