/* >>> CLASSE TABULEIROEXCEPTION - PASTA TABULEIRO <<< */

using System;

namespace Tabuleiro // Alterado
{
    class TabuleiroException :Exception
    {
        public TabuleiroException(string msg): base(msg)
        {
        }
    }
}
