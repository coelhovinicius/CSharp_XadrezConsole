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
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);

            Console.WriteLine(pos);

            Console.WriteLine(pos.ToPosicao());

            Console.ReadLine();

            /* try
            {
                TabuleiroClasse tab = new TabuleiroClasse(8, 8);

                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(1, 3));
                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 9));

                Tela.ImprimirTabuleiro(tab);

            }

            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            } 

            Console.ReadLine(); */
        }
    }
}
