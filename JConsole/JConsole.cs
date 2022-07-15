using System;
using System.Text;
using Kokuban;
using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public static class JConsole
    {
        public static JConsoleDisplay Display = new JConsoleDisplay();

        public static void Init()
        {
            AnsiStyle style = Chalk.BgYellow;
            Display.SetBDisplay(1, 1, 't', style);
            Console.WriteLine(Display.GetBDisplay(1, 1).ToString());
            
            Console.ReadKey();
        }

        public static void Update()
        {

        }
    }
}