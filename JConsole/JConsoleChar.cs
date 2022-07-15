using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kokuban;
using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public class JConsoleChar
    {
        /// <summary>
        /// charの内容
        /// </summary>
        public char c = ' ';

        /// <summary>
        /// スタイル
        /// </summary>
        public AnsiStyle style = new AnsiStyle();

        public override string ToString()
        {
            return style + c.ToString();
        }
    }
}
