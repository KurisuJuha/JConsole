using System.Text;
using System.Threading.Tasks;

namespace JuhaKurisu.console;

public static class JConsole
{
    private static StringBuilder builder = new StringBuilder();

    /// <summary>
    /// JConsoleをスタートします。
    /// JConsoleの全ての機能はStart関数を実行しないと利用できません。
    /// </summary>
    public static void Start()
    {
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

    public static void Write()
    {

    }

    public static void Flash()
    {
        Console.CursorVisible = false;
        Console.SetCursorPosition(0, 0);
        Console.Write(builder);
    }
}