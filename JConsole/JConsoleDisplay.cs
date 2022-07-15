using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public static class JConsoleDisplay
    {
        public static Dictionary<(int, int), JConsoleChar> BufferDisplay = new Dictionary<(int, int), JConsoleChar>();

        public static JConsoleChar GetBDisplay(int x, int y)
        {
            if (BufferDisplay.TryGetValue((x,y), out JConsoleChar value))
            {
                if (value == null)
                {
                    return new JConsoleChar();
                }

                return value;
            }

            return new JConsoleChar();
        }

        public static JConsoleChar SetBDisplay(int x, int y, char c)
        {
            JConsoleChar jcd = GetBDisplay(x, y);

            jcd.c = c;

            return jcd;
        }

        public static JConsoleChar SetBDisplay(int x, int y, AnsiStyle style)
        {
            JConsoleChar jcd = GetBDisplay(x, y);

            jcd.style = style;

            return jcd;
        }

        public static JConsoleChar SetBDisplay(int x , int y , char c , AnsiStyle style)
        {
            JConsoleChar jcd = GetBDisplay(x, y);

            jcd.c = c;
            jcd.style = style;

            return jcd;
        }
    }
}
