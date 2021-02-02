using System;
using System.Collections.Generic;

namespace Dino
{
    public class Cordinations
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Cordinations(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }
    public class Tree
    {
        static int move = 1;
        public static List<Cordinations> TreeCordinations = new List<Cordinations>();
        public List<char> PartsOftrees { get; set; }
        public static int downOrhigh = 0;

        public Tree(List<char> PartsOftrees)
        {
            this.PartsOftrees = PartsOftrees;
        }
        
        public static void PrintTree(int x, int y, List<char> POT)
        {
            
            if(POT.Count == 0)
            {
               
                
                if (x - 12 > 0)
                {
                    if(downOrhigh == 1)
                    {
                        y += 3;
                    }
                    
                    Console.SetCursorPosition(x - 9, y - 7);
                    TreeCordinations.Add(new Cordinations(x-9, y-7));
                    TreeCordinations.Add(new Cordinations(x - 5, y - 7));
                    if (move == 1)
                    {
                        Console.WriteLine(@"/  \");
                        move = 0;
                    }
                    else
                    {
                        Console.WriteLine(@"\  /");
                        move = 1;
                    }
                    Console.SetCursorPosition(x - 12, y - 6);
                    TreeCordinations.Add(new Cordinations(x - 12, y - 6));
                    TreeCordinations.Add(new Cordinations(x - 12, y - 5));
                    TreeCordinations.Add(new Cordinations(x - 12, y - 7));
                    TreeCordinations.Add(new Cordinations(x - 13, y - 7));
                    Console.Write(@"_/*|_\/__");
                    Console.SetCursorPosition(x - 5, y - 5);
                    Console.Write(@"/\");
                }
                
            }
            else
            {
                for (int i = 0; i < POT.Count; i++)
                {
                    Console.SetCursorPosition(x, y);
                    TreeCordinations.Add(new Cordinations(x, y));
                    if (i == 1)
                    {
                        Console.SetCursorPosition(x - 2, y);
                        TreeCordinations.Add(new Cordinations(x - 2, y));
                        Console.Write("|_|_");
                    }
                    Console.Write(POT[i]);
                    y--;
                    /*              \  /
                     |        _/*|___\/____
                     |         \_|      /\
                   |_|_|
                     |
                         */
                }
            }
            
            
        }
    }
    static class Dino
    {
        static public List<Cordinations> DinoCordinations = new List<Cordinations>();
        static int move = 1;
        public static void Print(int x,int y, List<Cordinations> cord)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(" ___");
            DinoCordinations.Add(new Cordinations(x, y));
            Console.SetCursorPosition(x, y+1);
            DinoCordinations.Add(new Cordinations(x, y+1));
            Console.Write("|*");
            Console.SetCursorPosition(x, y + 2);
            DinoCordinations.Add(new Cordinations(x, y+2));
            Console.Write("/");
            Console.SetCursorPosition(x-1, y + 2);
            DinoCordinations.Add(new Cordinations(x-1, y+2));
            Console.Write(@"\");
            Console.SetCursorPosition(x - 2, y + 2);
            DinoCordinations.Add(new Cordinations(x-2, y+2));
            Console.Write(@"|");
            Console.SetCursorPosition(x - 1, y + 3);
            DinoCordinations.Add(new Cordinations(x-1, y+3));
            Console.Write(@"\");
            Console.Write("__");
            Console.Write("|");
            Console.SetCursorPosition(x+2, y + 2);
            Console.Write("/");
            Console.SetCursorPosition(x + 2, y + 1);
            Console.Write(" _|");
            DinoCordinations.Add(new Cordinations(x+2, y+1));
            DinoCordinations.Add(new Cordinations(x + 4, y + 1));
            DinoCordinations.Add(new Cordinations(x + 3, y + 1));
            Console.SetCursorPosition(x - 1, y + 4);
            if(move == 1)
            {
                Console.WriteLine(@"/  \");
                move = 0;
            }
            else
            {
                Console.WriteLine(@"\ /");
                move = 1;
            }
            DinoCordinations.Add(new Cordinations(x+1, y + 4));
            DinoCordinations.Add(new Cordinations(x, y + 4));
            DinoCordinations.Add(new Cordinations(x-1, y + 4));
            
            /*   ___
                |* _|
              |\/ /
               \ _|     
                \ /   */
        }
        public static void Jump(int x,int y,ref int jumpingPosition,ref bool fallingDown)
        {
            
            {
                int isHighEnough = -9;

                if (jumpingPosition == isHighEnough)
                {
                    fallingDown = true;
                }
                if(fallingDown == true) 
                {
                    Print(x, y + jumpingPosition,DinoCordinations);
                    jumpingPosition += 3;
                   // System.Threading.Thread.Sleep(20);
                }
                else
                {
                    Print(x, y + jumpingPosition, DinoCordinations);
                    jumpingPosition -= 3;
                   // System.Threading.Thread.Sleep(35);
                }
            }
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            bool stop = false;
            int points = 0;

            List<Tree> trees = new List<Tree>();
            trees.Add(new Tree(new List<char>() { '|', '|', '|', '|', '|' }));
            trees.Add(new Tree(new List<char>() { '|', '|', '|', '|' }));
            trees.Add(new Tree(new List<char>() { '|', '|', '|'}));

            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            int x = 10;
            int y = 10;
            
            Random rgb = new Random();
            Tree tree = trees[rgb.Next(trees.Count - 1)];
            int treeX = Console.WindowWidth - 5;
            int treeY = 10+2;

            int jumpingRounds = 6;
            int jumpingPosition = -3;
            bool fallingDown = false;
            bool stayingOnTheGound = true;

            while (stop == false)
            {
                
                Console.SetCursorPosition(0, y + 4);
                Console.Write(new string('_',Console.WindowWidth-1));
                
                if (Console.KeyAvailable)
                {
                    
                    ConsoleKeyInfo usr = Console.ReadKey();
                    if (usr.Key == ConsoleKey.Spacebar)
                    {
                        stayingOnTheGound = false;
                        
                    }

                }
                
                if (stayingOnTheGound == true)
                {
                     Dino.Print(x, y,Dino.DinoCordinations);
                     //System.Threading.Thread.Sleep(50);
                }
                else
                {
                    if (jumpingRounds == 0)
                    {
                        jumpingRounds = 6;
                        stayingOnTheGound = true;
                        fallingDown = false;
                        jumpingPosition = -3;
                    }
                    else
                    {
                        Dino.Jump(x, y, ref jumpingPosition, ref fallingDown);
                        
                        jumpingRounds--;
                    }
                }
                if(treeX > 0)
                {
                    Tree.PrintTree(treeX, treeY+2, tree.PartsOftrees);
                    if (points == 700)
                        trees.Add(new Tree(new List<char>(13)));
                       // System.Threading.Thread.Sleep(50);
                    //else System.Threading.Thread.Sleep(30);
                   foreach (var dinoPart in Dino.DinoCordinations)
                   {
                       foreach (var treePart in Tree.TreeCordinations)
                       {
                           if(dinoPart.X == treePart.X && dinoPart.Y == treePart.Y)
                           {
                               stop = true;
                           }
                       }
                   }
                    treeX -=4;
                    Dino.DinoCordinations.Clear();
                    Tree.TreeCordinations.Clear();
                }
                else
                {
                    Tree.downOrhigh = rgb.Next(0, 2);
                    points += 100;
                    tree = trees[rgb.Next(0,trees.Count)];
                    treeX = Console.WindowWidth-1;
                    Dino.DinoCordinations.Clear();
                }
                Console.SetCursorPosition(0, 0);
                Console.Write("Currnet points; {0}", points);

                System.Threading.Thread.Sleep(50);
                Console.Clear();
                
            }
            Console.WriteLine("Game over!\n" +
                "Your points are {0}",points);
        }
        
    }
}
