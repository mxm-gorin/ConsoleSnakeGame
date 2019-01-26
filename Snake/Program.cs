using System;
using static System.Console;


namespace Snake
{
    class Program
    {
        static void Main()
        {
            Start:
            GameParameters.SetAll();
            Game.Run();

            goto Start;
        }
    }
}