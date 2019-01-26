using static System.Console;
using System;

namespace Snake
{
    public class GameParameters
    {
        public static void SetAll(string title = "snake", int width = 60, int height = 30)
        {
            Title = title;
            SetWindowSize(width, height);
            CursorVisible = false;
            BackgroundColor = ConsoleColor.White;
        }
    }
}
