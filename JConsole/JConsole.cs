using System.Diagnostics;
using Kokuban;
using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public static class JConsole
    {
        public static JConsoleDisplay Display = new JConsoleDisplay();
        public static string[][] _display = new string[0][];
        public static Stopwatch sw = new Stopwatch();

        public static int lateWindowHeight = 0;
        public static int lateWindowWidth = 0;

        public static ConsoleKeyInfo key;



        public static void Init()
        {
            AnsiStyle style = Chalk.BgYellow;
            Display.SetBDisplay(10, 10, 't', style);
            Console.CursorVisible = false;
        }

        public static void Update()
        {
            try
            {
                sw.Restart();
                Console.SetCursorPosition(0, 0);

                if (Console.KeyAvailable)
                {
                    key = Console.ReadKey(true);
                }
                else
                {
                    key = null;
                }

                // _displayを初期化
                if (lateWindowHeight != Console.WindowHeight || lateWindowWidth != Console.WindowWidth)
                {
                    Console.Clear();
                    _display = new string[Console.WindowHeight][];

                    for (int i = 0; i < Console.WindowHeight; i++)
                    {
                        _display[i] = new string[Console.WindowWidth];

                        for (int j = 0; j < Console.WindowWidth; j++)
                        {
                            _display[i][j] = Display.GetBDisplay(j, i).ToString();
                        }
                    }

                    lateWindowHeight = Console.WindowHeight;
                    lateWindowWidth = Console.WindowWidth;
                }

                // displayのdiffを元に_displayを変更する
                for (int i = 0; i < Display.Diff.Count; i++)
                {
                    if (_display.Length > Console.WindowHeight - 1 - Display.Diff[i].Item2 && _display[0].Length > Display.Diff[i].Item1)
                    {
                        _display[Console.WindowHeight - 1 - Display.Diff[i].Item2][Display.Diff[i].Item1] = Display.GetBDisplay(Display.Diff[i].Item1, Console.WindowHeight - 1 - Display.Diff[i].Item2).ToString();
                    }

                    Display.ResetDiff();
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
            catch (Exception ex)
            {

            }
        }
    }
}
