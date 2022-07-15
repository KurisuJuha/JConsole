using System;
using System.Text;
using Kokuban;

namespace JuhaKurisu.JConsole
{
    public static class JConsole
    {
        public static void Init()
        {
            Console.WriteLine(Console.WindowHeight);
            Console.WriteLine(Console.WindowWidth);
            Console.WriteLine("\u001b[31mHello World!\u001b[0m");
            var stdout = Console.OpenStandardOutput();
            var con = new StreamWriter(stdout, Encoding.ASCII);
            con.AutoFlush = true;
            Console.SetOut(con);

            Console.WriteLine("\x1b[36mTEST\x1b[0m");
            Console.Write(Chalk.Gray + "test");
            Console.Write("test2");
            Console.ReadKey();
        }

        public static void Update()
        {

        }
    }
}