using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuhaKurisu.JConsole
{
    public static class JConsoleDisplay
    {
        public static Dictionary<(int, int), JConsoleChar> BufferDisplay = new Dictionary<(int, int), JConsoleChar>();

        public static JConsoleChar GetBDisplay((int, int) pos)
        {
            return GetBDisplay(pos.Item1, pos.Item2);
        }

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
    }
}
