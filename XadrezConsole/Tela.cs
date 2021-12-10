/* >>> CLASSE TELA <<< */
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
                Console.Write(8 - i + " ");
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
            Console.WriteLine("  a b c d e f g h");
        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca.Cor == Cor.Branca)
            {
                // Console.Write(peca);
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
            else
            {
                ConsoleColor aux = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.Write(peca);
                Console.ForegroundColor = aux;
            }
        }
    }
}
