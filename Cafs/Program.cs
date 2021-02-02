using System;
using System.Collections.Generic;

namespace Cafs
{
    class Cordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Cordinates(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
    public class Car
    {
        public static void PrintEnemyCar(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write("|-|");
        }
        public static void PrintMyCar(int x, int y)
        {
            Console.SetCursorPosition(x+1, y);
            Console.Write('_');
            Console.SetCursorPosition(x, y+1);
            Console.Write("|_|");
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Random rng = new Random();
            bool stop = false;
            bool secondCar = false;
            bool ThirdCar = false;
            int points = 0;
            Cordinates temp = new Cordinates(0, 0);
            Cordinates temp2 = new Cordinates(0, 0);
            Cordinates temp1 = new Cordinates(0, 0);

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.BufferWidth;

            int UserCarX = Console.BufferWidth / 2 - 2;
            int UserCarY = 15;

            List<Cordinates> enemyCars = new List<Cordinates>();
            for (int i = 0; i < 12; i+=3)
            {
                enemyCars.Add(new Cordinates(Console.BufferWidth/2-2+i, 3));
            }
            var enemyCar = enemyCars[rng.Next(0, enemyCars.Count)];
            var enemyCar2 = enemyCars[rng.Next(0, enemyCars.Count)];
            var enemyCar3 = enemyCars[rng.Next(0, enemyCars.Count)];
            temp1.X = enemyCar.X;
            temp1.Y = enemyCar.Y;
            temp.X = enemyCar2.X;
            temp.Y = enemyCar2.Y;
            temp2.X = enemyCar3.X;
            temp2.Y = enemyCar3.Y;
            while (stop == false)
            {
                drawField();
                if (temp1.Y < 18)
                {
                   
                    temp1.Y++;
                    Car.PrintEnemyCar(temp1.X, temp1.Y);
                }
                else
                {
                    points += 100;
                    temp1.Y = 3;
                    temp1 = enemyCars[rng.Next(0, enemyCars.Count)];
                }
                if (points > 600 && temp1.Y == 11) secondCar = true;
                
                if(secondCar == true)
                {
                    
                    if (temp.Y < 18)
                    {
                        
                        temp.Y++;
                        Car.PrintEnemyCar(temp.X, temp.Y);
                    }
                    else
                    {
                        points += 100;
                        enemyCar2.Y = 3;
                        enemyCar2 = enemyCars[rng.Next(0, enemyCars.Count)];
                        temp.X = enemyCar2.X;
                        temp.Y = enemyCar2.Y;
                        secondCar = false;
                    }
                }

                if (points > 2000 && temp1.Y == 15) ThirdCar = true;

                if (ThirdCar == true)
                {

                    if (temp2.Y < 18)
                    {
                        temp2.Y++;
                        Car.PrintEnemyCar(temp2.X, temp2.Y);
                        
                    }
                    else
                    {
                        points += 100;
                        enemyCar3 = enemyCars[rng.Next(0, enemyCars.Count)];
                        temp2.X = enemyCar3.X;
                        temp2.Y = enemyCar3.Y;
                        ThirdCar = false;
                    }
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo usr = Console.ReadKey();
                    if (usr.Key == ConsoleKey.LeftArrow && UserCarX > Console.BufferWidth / 2 - 2)
                    {
                        UserCarX -= 3;
                    }
                    if(usr.Key == ConsoleKey.RightArrow && UserCarX < Console.BufferWidth / 2 - 2+9 )
                    {
                        UserCarX += 3;
                    }
                }
                Car.PrintMyCar(UserCarX, UserCarY);
                Console.SetCursorPosition(Console.WindowWidth / 2, 0);
                Console.Write("Current points: {0}", points);
               
                if (points > 3000)
                {
                     System.Threading.Thread.Sleep(30);
                }
                else if(points > 2000)
                {
                    System.Threading.Thread.Sleep(35);
                }
                else if(points > 1000)
                {
                   System.Threading.Thread.Sleep(45);
                }
                else
                {
                    System.Threading.Thread.Sleep(50);
                }
                if ( temp1.X == UserCarX && temp1.Y-2 == UserCarY || temp.X == UserCarX && 
                    temp.Y - 2 == UserCarY|| temp2.X == UserCarX && temp2.Y - 2 == UserCarY)
                {
                    stop = true;
                }
                Console.Clear();
            }
            Console.WriteLine("Game over!\nYour points are {0}",points);
        }
        static void drawField()
        {
            Console.SetCursorPosition(Console.BufferWidth / 2 - 2, 1);
            Console.Write(new String('_', 12));
            
            Console.SetCursorPosition(Console.BufferWidth / 2 - 2, 18);
            Console.Write(new String('_', 12));
        }
    }
}
