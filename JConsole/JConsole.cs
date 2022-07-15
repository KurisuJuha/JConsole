using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Kokuban;
using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public static class JConsole
    {
        public static JConsoleDisplay Display = new JConsoleDisplay();
        public static char[][] _display;
        public static Stopwatch sw = new Stopwatch();

        public static void Init()
        {
            AnsiStyle style = Chalk.BgYellow;
            Display.SetBDisplay(1, 1, 't', style);
            Console.CursorVisible = false;
        }

        public static void Update()
        {
            sw.Restart();
            Console.SetCursorPosition(0, 0);
            _display = new char[Console.WindowHeight][];

            // _displayを初期化
            Parallel.For(0, Console.WindowHeight, i =>
            {
                _display[i] = new char[Console.WindowWidth];
            });



            sw.Stop();
            TimeSpan span = sw.Elapsed;
            Console.WriteLine(1 / span.TotalSeconds);
        }
    }
}