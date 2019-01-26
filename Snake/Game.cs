using System;
using System.Collections.Generic;
using System.Diagnostics;
using static System.Console;

namespace Snake
{
    static class Game
    {     
        public static void Run()
        {
            var randomNumber = new Random();
            var head = new Pixel(WindowWidth / 2, WindowHeight / 2, ConsoleColor.Red);

            var food = new Pixel(
                randomNumber.Next(3, WindowWidth - 3),
                randomNumber.Next(3, WindowHeight - 3),
                ConsoleColor.Magenta);

            var body = new List<Pixel>();
            var score = 2;
            var difficulty  = 0;
            var currentMovement = Direction.Right;
            var gameover = false;
            WorldBilder.DrawBorder();

            while (!gameover)
            {
                BackgroundColor = ConsoleColor.White;
                WorldBilder.ClearConsole(WindowWidth, WindowHeight);
                WorldBilder.DrawPixel(head);
                WorldBilder.DrawPixel(food);
                
                if (food.X == head.X && food.Y == head.Y)
                {
                    score++;
                    food = new Pixel(
                        randomNumber.Next(2, WindowWidth - 4), 
                        randomNumber.Next(2, WindowHeight - 4), 
                        ConsoleColor.Magenta);
                }

                foreach (var part in body)
                {
                    WorldBilder.DrawPixel(part);
                    gameover |= (part.X == head.X && part.Y == head.Y);
                    BackgroundColor = ConsoleColor.White;
                }

                var timer = Stopwatch.StartNew();        
                difficulty = 360 - score * 20;
                if (difficulty < 40) difficulty = 35;
                while (timer.ElapsedMilliseconds < difficulty)
                {
                    currentMovement = Control.ReadMovement(currentMovement);
                }

                body.Add(new Pixel(head.X, head.Y, ConsoleColor.DarkGreen));

                switch (currentMovement)
                {
                    case Direction.Up:
                        head.Y--;
                        break;
                    case Direction.Down:
                        head.Y++;
                        break;
                    case Direction.Left:
                        head.X--;
                        break;
                    case Direction.Right:
                        head.X++;
                        break;
                }

                if (body.Count > score)
                {
                    body.RemoveAt(0);
                }

                gameover |= (head.X == WindowWidth - 1 || head.X == 0 || head.Y == WindowHeight - 1 || head.Y == 0);
            }           

            ForegroundColor = ConsoleColor.Red;
            SetCursorPosition(WindowWidth / 2, WindowHeight / 2);
            WriteLine($"Game over, Score: {score - 2}");
            ReadKey();
        }
    }
}
