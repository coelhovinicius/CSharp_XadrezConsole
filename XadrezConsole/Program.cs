/* XADREZ CONSOLE - IMPLEMENTACAO EM CAMADAS
    
    O sistema sera desenvolvido em camadas especificas:
        - Camada Tabuleiro - Camada mais basica, com os elementos basicos de um tabuleiro de xadrez: tabuleiro, pecas,
          posicao, cores, etc. Nao ha inteligencia de jogo, apenas a representacao do tabuleiro, pecas e operacoes basicas;
        - Camada Jogo de Xadrez - Implementacao da inteligencia com as regras e mecanicas do jogo de xadrez;
        - Camada de Aplicacao - Aplicativo em si, no modo console - Interacao com o usuario.
 */

/* >>> PROGRAMA PRINCIPAL <<< */
using System;
using Tabuleiro;
using Xadrez;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            /* PosicaoXadrez pos = new PosicaoXadrez('c', 7);    A letra 'c' entre aspas simples indica ao programa compilar a 
                                                               * logica utilizando a representacao Binaria dessa letra
                                                               * ("c" minusculo). ; 

            Console.WriteLine(pos);

             Console.WriteLine(pos.ToPosicao());

             Console.ReadLine(); */

            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez(); // Instancia a partida de xadrez

                while (!partida.Terminada) // Enquanto a partida nao estiver terminada
                {
                    Console.Clear(); // Limpa a tela
                    Tela.ImprimirTabuleiro(partida.tab); // Imprime o tabuleiro

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().ToPosicao(); // Le a posicao de origem informada pelo usuario
                    Console.Write("Destino: ");
                    Posicao destino = Tela.LerPosicaoXadrez().ToPosicao(); // Le a posicao de destino informada pelo usuario

                    partida.ExecutaMovimento(origem, destino); // Executa o metodo para fazer o movimento da peca
                }

                /*  tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                  tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                  tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 2));
                  tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 5)); */

                // Tela.ImprimirTabuleiro(partida.tab);
            }

            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
