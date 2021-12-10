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

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            TabuleiroClasse tab = new TabuleiroClasse(8, 8);

            Console.ReadLine();

        }
    }
}
