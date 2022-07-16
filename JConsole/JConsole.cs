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

                    Parallel.For(0, Console.WindowWidth, j =>
                    {
                        if (_display[i][j] == '\0')
                        {
                            _display[i][j] = ' ';
                        }
                    });
                });

                lateWindowHeight = Console.WindowHeight;
                lateWindowWidth = Console.WindowWidth;
                _display[0][0] = 'a';
                _display[3][10] = 'a';
            }

            // _displayの内容を文字列化
            string[] ss = new string[_display.Length];
            for (int i = 0; i < ss.Length; i++)
            {
                ss[i] = string.Join("", _display[i]);
            }
            Console.Write(string.Join('\n', ss));


            sw.Stop();
            TimeSpan span = sw.Elapsed;
            //            Console.WriteLine(1 / span.TotalSeconds);
        }
    }
}