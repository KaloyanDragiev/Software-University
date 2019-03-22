namespace SnakeProject
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Net;
    using System.Collections;
    using System.Threading;

    struct Position
    {
        public int row;
        public int col;
        public Position(int row, int col)
        {
            this.row =row;
            this.col = col;
        }
    }
    class Snake
    {
        static void Main()
        {
            Position[] directions = new Position[] 
            {
                new Position(0, 1), //right
                new Position(0, -1), //left
                new Position(1, 0), //down
                new Position(-1, 0), //up
            };
            int direction = 0;
            Random randomNumbersGenerators = new Random();
            Console.BufferHeight = Console.WindowHeight;
            Position food = new Position(randomNumbersGenerators.Next(0, Console.WindowHeight),
                randomNumbersGenerators.Next(0, Console.WindowWidth));
            Console.SetCursorPosition(food.col, food.row);
            Console.Write("%");
           

            Queue<Position> snakeElements = new Queue<Position>();
            for (int i = 0; i < 5; i++)
            {
                snakeElements.Enqueue(new Position(0, i));
            }
            foreach (Position position in snakeElements)
            {
                Console.SetCursorPosition(position.col, position.row);
                Console.Write('&');
            }

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();
                    if (userInput.Key == ConsoleKey.LeftArrow)
                    {
                        direction = 1;
                    }
                    if (userInput.Key == ConsoleKey.RightArrow)
                    {
                        direction = 0;
                    }
                    if (userInput.Key == ConsoleKey.UpArrow)
                    {
                        direction = 3;
                    }
                    if (userInput.Key == ConsoleKey.DownArrow)
                    {
                        direction = 2;
                    }
                }
                Position snakehead = snakeElements.Last();
                Position Nextdirection = directions[direction];
                Position snakeNewhead = new Position(snakehead.row + Nextdirection.row, snakehead.col + Nextdirection.col);
                snakeElements.Enqueue(snakeNewhead);

                if (snakeNewhead.row < 0 || snakeNewhead.col < 0 ||
                    snakeNewhead.row >= Console.WindowHeight || snakeNewhead.col >= Console.WindowWidth)
                {
                    Console.SetCursorPosition(0, 0);
                    Console.WriteLine("Your points are: {0}", (snakeElements.Count - 6) * 100);
                    Console.WriteLine("Game Over!");
                    return;
                }
                
                Position newhead = snakeElements.Last();

                if (snakeNewhead.col == food.col && snakeNewhead.row == food.row)
                {
                    food = new Position(randomNumbersGenerators.Next(0, Console.WindowHeight),
                randomNumbersGenerators.Next(0, Console.WindowWidth));
                }
                else
                {
                    snakeElements.Dequeue();
                }
                Console.Clear();
                foreach (Position position in snakeElements)
                {
                    Console.SetCursorPosition(position.col, position.row);
                    Console.Write('*');
                }
                Console.SetCursorPosition(food.col, food.row);
                Console.Write("@");
                Thread.Sleep(100);
            }
        }
    }
}
