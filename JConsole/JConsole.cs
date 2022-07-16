using System.Diagnostics;
using Kokuban;
using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public static class JConsole
    {
        public static JConsoleDisplay Display = new JConsoleDisplay();
        public static char[][] _display = new char[0][];
        public static Stopwatch sw = new Stopwatch();

        public static int lateWindowHeight = 0;
        public static int lateWindowWidth = 0;

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

            // _displayを初期化
            if (lateWindowHeight != Console.WindowHeight || lateWindowWidth != Console.WindowWidth)
            {
                _display = new char[Console.WindowHeight][];

                Parallel.For(0, Console.WindowHeight, i =>
                {
                    _display[i] = new char[Console.WindowWidth];
                });

                lateWindowHeight = Console.WindowHeight;
                lateWindowWidth = Console.WindowWidth;
            }



            sw.Stop();
            TimeSpan span = sw.Elapsed;
            //            Console.WriteLine(1 / span.TotalSeconds);
            Console.WriteLine(lateWindowHeight);
            Console.WriteLine(lateWindowWidth);
        }
    }
}