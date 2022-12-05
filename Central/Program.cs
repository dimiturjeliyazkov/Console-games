using System;
using System.Threading;

namespace Central
{
    public class Program
    {
        public static class Field
        {
            
            public static int x = 2;
            public static int y = 2;
            public static void PrintField(int nz)
            {
                Console.SetCursorPosition(x, y);
                if (nz % 2 == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                }
                Console.Write(new string(nz % 2 == 0 ? '_':'*', 60)); ;
                for (int i = 1; i < 25; i++)
                {
                    
                    Console.SetCursorPosition(x, y + i);
                    Console.Write(nz % 2 == 0 ?'|':'*');

                    Console.SetCursorPosition(x + 60, y + i);
                    Console.Write(nz % 2 == 0 ? "|":"*");
                }
                Console.SetCursorPosition(x, y+25);
                Console.Write(new string(nz % 2 == 0 ? '-':'*', 60));
            }
            public static void PrintGameOptions(int x, int y, string game,int pos)
            {
                
                Console.SetCursorPosition(x + 2, y + 4);
                Console.Write(new string('*',game.Length+4));

                for (int i = 0; i < 3; i++)
                {
                    Console.SetCursorPosition(x + 2, y + 4+i);
                    Console.Write('*');
                    Console.SetCursorPosition(x + game.Length + 5, y + 4 + i);
                    Console.Write('*');
                }

                Console.SetCursorPosition(x + 2, y + 6);
                Console.Write(new string('*', game.Length + 4));
                Console.SetCursorPosition(x+4, y+5);
                Console.Write(game);

            }
        }
        static void Main(string[] args)
        {
            int fieldSprinkel = 1;

            int Selectedposition = 0; 
            while (true)
            {
                Field.PrintField(fieldSprinkel++);
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo usr = Console.ReadKey();
                    if (usr.Key == ConsoleKey.DownArrow && Selectedposition < 3)
                    {
                        Selectedposition++;

                    }
                    else if(usr.Key == ConsoleKey.UpArrow && Selectedposition > 0)
                    {
                        Selectedposition--;
                    }

                    if (usr.Key == ConsoleKey.Enter)
                    {
                        if (Selectedposition == 0)
                        {
                            Dino.Program.Main(new string[1]);
                        }
                        else if (Selectedposition == 1)
                        {
                            
                            Fight.Program.Main(new string[1]);
                        }
                        else if (Selectedposition == 2)
                        {
                            Snake.Program.Main(new string[1]);
                        }
                        else if (Selectedposition == 3)
                        {
                            Cars.Program.Main(new string[1]);
                        }
                    }
                    Console.Clear();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                if (Selectedposition == 0)
                {
                   // if (fieldSprinkel % 2 != 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                   // else
                   // {
                   //     Console.ForegroundColor = ConsoleColor.Red;
                   // }
                }
                Field.PrintGameOptions(Field.x + 2, Field.y + 2, "Dino", Selectedposition);
                Console.ForegroundColor = ConsoleColor.Red;
                if (Selectedposition == 1)
                {
                  //  if (fieldSprinkel % 2 != 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                    //else
                    //{
                      //  Console.ForegroundColor = ConsoleColor.Red;
                    //}

                }
                Field.PrintGameOptions(Field.x + 2, Field.y + 5, "Fighters", Selectedposition);
                Console.ForegroundColor = ConsoleColor.Red;
                if (Selectedposition == 2)
                {
                   // if (fieldSprinkel % 2 != 0)
                        Console.ForegroundColor = ConsoleColor.Green;
                   // else
                   // {
                   //     Console.ForegroundColor = ConsoleColor.Red;
                   // }
                }
                Field.PrintGameOptions(Field.x + 2, Field.y + 8, "Snake", Selectedposition);
                Console.ForegroundColor = ConsoleColor.Red;
                if (Selectedposition == 3)
                {
                   // if (fieldSprinkel % 2 != 0)
                      Console.ForegroundColor = ConsoleColor.Green;
                   // else
                   // {
                   //     Console.ForegroundColor = ConsoleColor.Red;
                   // }
                }
                Field.PrintGameOptions(Field.x + 2, Field.y + 11, "CarsBG!", Selectedposition);
                Console.ForegroundColor = ConsoleColor.Red;
                Thread.Sleep(150);

            }
		}
        
    }
}
