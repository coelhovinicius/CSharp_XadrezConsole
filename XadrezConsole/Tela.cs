/* >>> CLASSE TELA  - CRIADA DIRETO DO PROJETO XADREZCONSOLE <<< */
using System;
using System.Collections.Generic;
using Tabuleiro;
using Xadrez;

namespace XadrezConsole
{
    class Tela
    {
        public static void ImprimirPartida(PartidaDeXadrez partida)
        {
            ImprimirTabuleiro(partida.Tab);
            Console.WriteLine();
            ImprimirPecasCapturadas(partida);
            Console.WriteLine();
            Console.WriteLine("Turno: " + partida.Turno);
            if (!partida.Terminada)
            {
                Console.WriteLine("Aguardando jogada: " + partida.JogadorAtual);
                if (partida.Xeque)
                {
                    Console.WriteLine("XEQUE!");
                }
            }
            else
            {
                Console.WriteLine("XEQUE-MATE!");
                Console.WriteLine("Vencedor: " + partida.JogadorAtual);
            }
        }

        public static void ImprimirPecasCapturadas(PartidaDeXadrez partida)
        {
            Console.WriteLine("Pecas capturadas: ");
            Console.Write("Brancas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Branca));
            Console.WriteLine();
            Console.Write("Pretas: ");
            ImprimirConjunto(partida.PecasCapturadas(Cor.Preta));
            Console.WriteLine();
        }

        public static void ImprimirConjunto(HashSet<Peca> conjunto)
        {
            Console.Write("[");
            foreach (Peca x in conjunto)
            {
                Console.Write(x + " ");
            }
            Console.Write("]");
        }

        public static void ImprimirTabuleiro(TabuleiroClasse tab)
        {
            for (int i = 0; i < tab.Linhas; i++) // Percorre as linhas
            {
                Console.Write(8 - i + " "); // Ao inicio de cada linha, imprime os numeros de 8 a 1 do tabuleiro de xadrez
                for (int j = 0; j < tab.Colunas; j++) // Percorre as colunas
                {
                    ImprimirPeca(tab.Peca(i, j));
                }

                Console.WriteLine();

            }
            Console.WriteLine("  a b c d e f g h"); // Ao fim de cada coluna, imprime as letras de a a h do tabuleiro de xadrez 
        }

        public static void ImprimirTabuleiro(TabuleiroClasse tab, bool[,] posicoesPossiveis)
        {

            ConsoleColor fundoOriginal = Console.BackgroundColor; // Acessa a cor de fundo da tela (preta, no caso)
            ConsoleColor fundoAlterado = ConsoleColor.DarkMagenta;

            for (int i = 0; i < tab.Linhas; i++) // Percorre as linhas
            {
                Console.Write(8 - i + " "); // Ao inicio de cada linha, imprime os numeros de 8 a 1 do tabuleiro de xadrez
                for (int j = 0; j < tab.Colunas; j++) // Percorre as colunas
                {
                    if (posicoesPossiveis[i, j])
                    {
                        Console.BackgroundColor = fundoAlterado;
                    }
                    else
                    {
                        Console.BackgroundColor = fundoOriginal;
                    }
                    ImprimirPeca(tab.Peca(i, j));
                    Console.BackgroundColor = fundoOriginal;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  a b c d e f g h"); // Ao fim de cada coluna, imprime as letras de a a h do tabuleiro de xadrez
            Console.BackgroundColor = fundoOriginal;
        }

        public static PosicaoXadrez LerPosicaoXadrez() // Metodo para ler a posicao digitada
        {
            string s = Console.ReadLine(); // Le a posicao informacao pelo usuario
            char coluna = s[0]; // Variavel para receber a letra da coluna da posicao digitada (posicao 0 da string informada)
            int linha = int.Parse(s[1] + ""); // Variavel para receber o numero da linha da posicao digitada (posicao 1 da string)
            return new PosicaoXadrez(coluna, linha); // Retorna a posicao indicada

        }

        public static void ImprimirPeca(Peca peca)
        {
            if (peca == null)
            {
                Console.Write("- ");
            }
            else
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
                Console.Write(" ");
            }
        }
    }
}
