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
                for (int j = 0; j < tab.Colunas; j++) // Percorre as colunas
                {
                    if (tab.Peca(i, j) == null)
                    {
                        Console.Write(tab.Peca(i, j) + "- ");
                    }
                    else
                    {
                        Console.Write(tab.Peca(i,j) + " ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
