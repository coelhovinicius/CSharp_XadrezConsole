﻿/* >>> CLASSE TABULEIROCLASSE - PASTA TABULEIRO <<< */
namespace Tabuleiro
{
    class TabuleiroClasse
    {
        public int Linhas { get; set; }
        public int Colunas { get; set; }
        private Peca[,] Pecas;

        public TabuleiroClasse(int linhas, int colunas)
        {
            this.Linhas = linhas;
            this.Colunas = colunas;
            Pecas = new Peca[linhas, colunas];
        }
    }
}
