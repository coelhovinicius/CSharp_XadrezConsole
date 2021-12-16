/* >>> CLASSE PECA - PASTA TABULEIRO */
namespace Tabuleiro // Alterado
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; } // "protected set" - So pode ser alterada pela classe e suas subclasses
        public int QtdeMovimentos { get; protected set; }
        public TabuleiroClasse Tab { get; protected set; }

        public Peca(TabuleiroClasse tab, Cor cor)
        {
            this.Posicao = null;
            this.Tab = tab;
            this.Cor = cor;
            QtdeMovimentos = 0;
        }

        public void IncrementarQtdeMovimentos() // Controla a quantidade de movimentos dos jogadores na partida
        {
            QtdeMovimentos++;
        }

        public void DecrementarQtdeMovimentos() // Controla a quantidade de movimentos dos jogadores na partida
        {
            QtdeMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() // Verifica es a peca esta com os movimentos bloqueados
        {
            bool[,] mat = MovimentosPossiveis(); // Variavel temporaria recebendo os movimentos possiveis
            for (int i = 0; i < Tab.Linhas; i++)
            {
                for (int j = 0; j < Tab.Colunas; j++)
                {
                    if (mat[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos) // Verifica se e possivel movimentar a peca para a posicao selecionada
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis(); // Matriz de valores Booleanos (true / false)
    }
}
