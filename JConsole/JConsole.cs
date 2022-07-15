using System;
using System.Text;
using Kokuban;
using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public static class JConsole
    {
        public static void Init()
        {
            AnsiStyle style = Chalk.Bold.Gray.BgYellow;
            JConsoleDisplay.BufferDisplay[(1, 1)] = new JConsoleChar();
            JConsoleDisplay.BufferDisplay[(1, 1)].style = style;
            JConsoleDisplay.BufferDisplay[(1, 1)].c = 'a';
            
            Console.ReadKey();
        }

        public static void Update()
        {

        }
    }
}