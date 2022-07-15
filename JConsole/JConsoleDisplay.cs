using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public class JConsoleDisplay
    {
        public Dictionary<(int, int), JConsoleChar> DisplayBuffer = new Dictionary<(int, int), JConsoleChar>();

        public JConsoleChar GetBDisplay(int x, int y)
        {
            if (DisplayBuffer.TryGetValue((x, y), out JConsoleChar? value))
            {
                if (value == null)
                {
                    DisplayBuffer.Add((x, y), new JConsoleChar());
                    return DisplayBuffer[(x, y)];
                }

                return value;
            }

            DisplayBuffer.Add((x, y), new JConsoleChar());
            return DisplayBuffer[(x, y)];
        }

        public JConsoleChar SetBDisplay(int x, int y, char c)
        {
            JConsoleChar jcd = GetBDisplay(x, y);

            jcd.c = c;

            return jcd;
        }

        public JConsoleChar SetBDisplay(int x, int y, AnsiStyle style)
        {
            JConsoleChar jcd = GetBDisplay(x, y);

            jcd.style = style;
            
            return jcd;
        }

        public JConsoleChar SetBDisplay(int x , int y , char c , AnsiStyle style)
        {
            JConsoleChar jcd = GetBDisplay(x, y);

            jcd.c = c;
            jcd.style = style;

            return jcd;
        }
    }
}
