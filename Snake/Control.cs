using System;
using static System.Console;

namespace Snake
{
    class Control
    {
        public static Direction ReadMovement(Direction movement)
        {
            if (!KeyAvailable) return movement;

            var key = ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.UpArrow:
                case ConsoleKey.W:
                    movement = Direction.Up;
                    break;
                case ConsoleKey.DownArrow:
                case ConsoleKey.S:
                    movement = Direction.Down;
                    break;
                case ConsoleKey.LeftArrow:
                case ConsoleKey.A:
                    movement = Direction.Left;
                    break;
                case ConsoleKey.RightArrow:
                case ConsoleKey.D:
                    movement = Direction.Right;
                    break;
            }

            return movement;
        }
    }
}
