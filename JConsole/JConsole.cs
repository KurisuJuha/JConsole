using System;
using System.Text;
using System.Threading.Tasks;
using Kokuban;
using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public static class JConsole
    {
        public static JConsoleDisplay Display = new JConsoleDisplay();
        public static char c;

        public static void Init()
        {
            AnsiStyle style = Chalk.BgYellow;
            Display.SetBDisplay(1, 1, 't', style);
            while (true)
            {
                c = Console.ReadKey(false).KeyChar;
                Update();
            }
        }

        public static void Update()
        {
            Console.SetCursorPosition(0, 0);
            char[] d = new char[Console.WindowHeight * (Console.WindowWidth + 1)];
            
            Parallel.For(0, Console.WindowHeight, y =>
            {
                Parallel.For(0, Console.WindowWidth, x =>
                {
                    d[y * (Console.WindowWidth + 1) + x] = c;
                });
                d[y * (Console.WindowWidth + 1)] = '\n';
            });
            /*
            for (int y = 0; y < Console.WindowHeight; y++)
            {
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    d[y * (Console.WindowWidth + 1) + x] = c;
                }
                d[y * (Console.WindowWidth + 1)] = '\n';
            }
            */

            Console.ReadKey(false);


            Console.Write(string.Join("", d));
        }
    }
}