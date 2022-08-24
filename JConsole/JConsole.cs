using System.Text;
using System.Threading.Tasks;

namespace JuhaKurisu.console;

public static class JConsole
{
    private static StringBuilder builder = new StringBuilder();
    private static int CursorPosition;

    /// <summary>
    /// JConsoleをスタートします。
    /// JConsoleの全ての機能はStart関数を実行しないと利用できません。
    /// </summary>
    public static void Start()
    {
        Clear();
        Flash();

        Task.Run(() =>
        {
            while (true)
            {
                Flash();
            }
        });
    }

    /// <summary>
    /// 画面全体をClearします。
    /// </summary>
    public static void Clear()
    {
        builder.Clear();

        for (int y = 0; y < Console.WindowHeight; y++)
        {
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                builder.Append(' ');
            }
        }
    }

    /// <summary>
    /// 画面に文字列を描画します。
    /// 改行は上手く動作しないため書き込まないことを推奨します。
    /// </summary>
    public static void Write(string s)
    {
        for (int i = 0; i < s.Length; i++)
        {
            WriteChar(s[i]);
        }
    }

    /// <summary>
    /// 画面に文字を描画します。
    /// 改行は上手く動作しないため書き込まないことを推奨します。
    /// </summary>
    /// <param name="c"></param>
    public static void WriteChar(char c)
    {
        if (CursorPosition >= 0 && CursorPosition < builder.Length)
        {
            builder[CursorPosition] = c;
        }
        CursorPosition++;
    }

    /// <summary>
    /// カーソルの位置を取得できます。
    /// </summary>
    /// <returns></returns>
    public static (int x,int y) GetCursorPosition()
    {
        return (CursorPosition % Console.WindowWidth, CursorPosition / Console.WindowWidth);
    }

    /// <summary>
    /// カーソルの位置を設定できます。
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public static void SetCursorPosition(int x, int y)
    {
        CursorPosition = y * Console.WindowWidth + x;
    }

    /// <summary>
    /// 画面全体を描画します。
    /// この関数は本来メインループで使用するためライブラリ使用者が利用することはありませんが、独自でメインループを実装したい場合などに利用できます。
    /// </summary>
    public static void Flash()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        Console.Write(builder);
    }

    /// <summary>
    /// 待ち続けますが、whileでループを回しているだけなので各自で実装した方が確実に効率がいいです。
    /// </summary>
    public static void Wait()
    {
        while (true) { }
    }
}