using Kokuban.AnsiEscape;

namespace JuhaKurisu.JConsole
{
    public class JConsoleDisplay
    {
        /// <summary>
        /// ディスプレイの内容
        /// </summary>
        public Dictionary<(int, int), JConsoleChar> DisplayBuffer = new Dictionary<(int, int), JConsoleChar>();

        /// <summary>
        /// 指定された座標のDisplayのデータを取得します
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <returns>取得したデータ</returns>
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

        /// <summary>
        /// 指定された座標のDisplayのcharを変更します
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="c">charの変更内容</param>
        /// <returns>取得したデータ</returns>
        public JConsoleChar SetBDisplay(int x, int y, char c)
        {
            JConsoleChar jcd = GetBDisplay(x, y);

            jcd.c = c;

            return jcd;
        }

        /// <summary>
        /// 指定された座標のDisplayのstyleを変更します
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="style">styleの変更内容</param>
        /// <returns>取得したデータ</returns>
        public JConsoleChar SetBDisplay(int x, int y, AnsiStyle style)
        {
            JConsoleChar jcd = GetBDisplay(x, y);

            jcd.style = style;
            
            return jcd;
        }

        /// <summary>
        /// 指定された座標のDisplayのstyleを変更します
        /// </summary>
        /// <param name="x">x座標</param>
        /// <param name="y">y座標</param>
        /// <param name="c">charの変更内容</param>
        /// <param name="style">styleの変更内容</param>
        /// <returns>取得したデータ</returns>
        public JConsoleChar SetBDisplay(int x , int y , char c , AnsiStyle style)
        {
            JConsoleChar jcd = GetBDisplay(x, y);

            jcd.c = c;
            jcd.style = style;

            return jcd;
        }
    }
}
