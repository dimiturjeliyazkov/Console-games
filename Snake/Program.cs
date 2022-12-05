using System;
using System.Collections.Generic;

namespace Snake
{
    class SnakeCordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Element { get; set; }

   
        public SnakeCordinates(int x, int y,char element)
        {
            X = x;
            Y = y;
            Element = element;
        }
        
        
    }
    class AppleCordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char Element { get; set; }


        public AppleCordinates(int x, int y, char element)
        {
            X = x;
            Y = y;
            Element = element;
        }

    }
    public class Program
    {
        public static void Main(string[] args)
        {
            List<SnakeCordinates> snakeBody = new List<SnakeCordinates>();
            char heading = 'r';
            SnakeCordinates previusHead = new SnakeCordinates(0,0,' ');
            var random = new Random();
            int score = 0;
            int speed = 50;
            bool IsGameOver = false;

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.BufferWidth;

            

            for (int i = 0; i < 7; i++)
            {
                snakeBody.Add(new SnakeCordinates(i, Console.WindowHeight / 2,'*'));
                if (i == 6)
                {
                    snakeBody[i].Element = '>';
                }
            }
            AppleCordinates apple = new AppleCordinates(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight), '@');
            while (true)
            {
                
                foreach (var bodyPart in snakeBody)
                {
                    Console.SetCursorPosition(bodyPart.X, bodyPart.Y);
                    Console.Write(bodyPart.Element);
                
                }
                switch (heading)
                {
                    case 'r':
                        {
                            previusHead = new SnakeCordinates(snakeBody[snakeBody.Count - 1].X, snakeBody[snakeBody.Count - 1].Y, '*');
                            snakeBody[snakeBody.Count - 1].Element = '>';
                            snakeBody[snakeBody.Count - 1].X++ ;
                            break;
                        }
                    case 'l':
                        {
                            previusHead = new SnakeCordinates(snakeBody[snakeBody.Count - 1].X, snakeBody[snakeBody.Count - 1].Y, '*');
                            snakeBody[snakeBody.Count - 1].Element = '<';
                            snakeBody[snakeBody.Count - 1].X-- ;
                            break;
                        }
                    case 'u':
                        {
                            previusHead = new SnakeCordinates(snakeBody[snakeBody.Count - 1].X, snakeBody[snakeBody.Count - 1].Y, '*');
                            snakeBody[snakeBody.Count - 1].Element = '^';
                            snakeBody[snakeBody.Count - 1].Y--;
                            break;
                        }
                    case 'd':
                        {
                            previusHead = new SnakeCordinates(snakeBody[snakeBody.Count - 1].X, snakeBody[snakeBody.Count - 1].Y, '*');
                            snakeBody[snakeBody.Count - 1].Element = 'v';
                            snakeBody[snakeBody.Count - 1].Y++;
                            break;
                        }
                }
                for (int i = 0; i < snakeBody.Count-1; i++)
                {
                    
                    if(i == snakeBody.Count - 2)
                    {
                        snakeBody[i] = previusHead;
                    }
                    else
                    {
                        snakeBody[i] = snakeBody[i + 1];
                    }
                }
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo usr = Console.ReadKey();
                    if (usr.Key == ConsoleKey.LeftArrow)
                    {
                        if(heading!='r')
                            heading = 'l';                   }
                    if (usr.Key == ConsoleKey.RightArrow )
                    {
                        if (heading != 'l')
                            heading = 'r';
                    }
                    if (usr.Key == ConsoleKey.UpArrow)
                    {
                        if (heading != 'd')
                            heading = 'u';
                    }
                    if (usr.Key == ConsoleKey.DownArrow)
                    {
                        if (heading != 'u')
                            heading = 'd';
                    }
                }

                
                Console.SetCursorPosition(apple.X,apple.Y);
                Console.Write(apple.Element);

                if (apple.X == snakeBody[snakeBody.Count-1].X&&apple.Y == snakeBody[snakeBody.Count - 1].Y)
                {
                    snakeBody.Add(new SnakeCordinates(snakeBody[snakeBody.Count - 1].X, snakeBody[snakeBody.Count - 1].Y, '*'));
                
                    apple = new AppleCordinates(random.Next(Console.WindowWidth), random.Next(Console.WindowHeight), '@');
                    score += 100;
                    if(speed > 25)
                    {
                        speed--;
                    }
                }

                Console.SetCursorPosition(0, 0);
                Console.Write("Your score is: {0}",score);

                if(snakeBody[snakeBody.Count - 1].X == 0 || snakeBody[snakeBody.Count-1].X==Console.WindowWidth
                    || snakeBody[snakeBody.Count - 1].Y == 0 || snakeBody[snakeBody.Count - 1].Y == Console.WindowHeight)
                {
                    IsGameOver = true;
                }
                for (int i = 0; i < snakeBody.Count-2; i++)
                {
                    if(snakeBody[snakeBody.Count-1].X == snakeBody[i].X && snakeBody[snakeBody.Count-1].Y == snakeBody[i].Y)
                    {

                        IsGameOver = true ;
                    }
                }
                if (IsGameOver)
                {
                    break;
                }
                System.Threading.Thread.Sleep(speed);
                Console.Clear();
            }
            Console.SetCursorPosition(0, 0);
            Console.Write("GAME OVER! Your final score is: {0}\nPress Enter to continue...", score);
            ConsoleKeyInfo user = Console.ReadKey();
            while (user.Key != ConsoleKey.Enter)
            {
                user = Console.ReadKey();
            }
        }

    }
}
