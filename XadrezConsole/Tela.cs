/* >>> CLASSE TELA  - CRIADA DIRETO DO PROJETO XADREZCONSOLE <<< */
using System;
using Tabuleiro;

namespace XadrezConsole
{
    class Tela
    {
        public static void ImprimirTabuleiro(TabuleiroClasse tab)
        {
            for (int i = 0; i < tab.Linhas; i++) // Percorre as linhas
            {
                Console.Write(8 - i + " "); // Ao inicio de cada linha, imprime os numeros de 8 a 1 do tabuleiro de xadrez
                for (int j = 0; j < tab.Colunas; j++) // Percorre as colunas
                {
                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write(tab.Peca(i, j) + "- ");
                    }
                    else
                    {
                        ImprimirPeca(tab.Peca(i, j));
                        Console.Write(" ");
                    }
                }

                Console.WriteLine();

            }
            Console.WriteLine("  a b c d e f g h"); // Ao fim de cada coluna, imprime as letras de a a h do tabuleiro de xadrez 
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.Branca)
            {
                // Console.Write(peca); // Imprime a peca na cor padrao (cinza claro)
                ConsoleColor aux = Console.ForegroundColor; // Variavel auxiliar para atribuir a cor
                Console.ForegroundColor = ConsoleColor.White; // Selecao da cor desejada
                Console.Write(peca); // Imprime "peca" na cor selecionada
                Console.ForegroundColor = aux; // Volta a exibir caracteres na cor padrao 
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor; // Variavel auxiliar para atribuir a cor
                Console.ForegroundColor = ConsoleColor.DarkBlue; // Selecao da cor desejada
                Console.Write(peca); // Imprime "peca" na cor selecionada
                Console.ForegroundColor = aux; // Volta a exibir caracteres na cor padrao 
            }
        }
    }
}
