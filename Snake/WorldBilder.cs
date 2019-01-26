using System;
using System.Linq;
using static System.Console;

namespace Snake
{
    static class WorldBilder
    {
        public static void DrawPixel(Pixel pixel)
        {
            SetCursorPosition(pixel.X, pixel.Y);
            BackgroundColor = pixel.Color;
            Write("  ");
            SetCursorPosition(0, 0);
        }

        public static void DrawBorder()
        {
            BackgroundColor = ConsoleColor.Black;

            for (var i = 0; i < WindowWidth; i++)
            {
                SetCursorPosition(i, 0);
                Write(" ");

                SetCursorPosition(i, WindowHeight - 1);
                Write(" ");
            }

            for (var i = 0; i < WindowHeight; i++)
            {
                SetCursorPosition(0, i);
                Write("  ");

                SetCursorPosition(WindowWidth - 2, i);
                Write("  ");
            }
        }

        public static void ClearConsole(int windowWidth, int windowHeight)
        {
            var blackLine = string.Join("", new byte[windowWidth - 4].Select(b => " ").ToArray());
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 1; i < WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(2, i);
                Console.Write(blackLine);
            }
        }

    }
}
