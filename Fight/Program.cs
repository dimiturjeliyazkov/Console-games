using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Fight
{
    class Cordinat
    {
        public int x { get; set; }
        public int y { get; set; }

        public Cordinat(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    
    public class Program
    {
        

        public static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Fighter firstPlayer = new FirstFighter(10, Console.WindowHeight-15,3);                             // creating fighters
            Fighter secondPlayer = new SecondFighter(Console.WindowWidth-10, Console.WindowHeight - 15, 10, 10);     // creating fighters

            List<Cordinat> firstPlayerCordinations = new List<Cordinat>();
            List<Cordinat> secondPlayerCordinations = new List<Cordinat>();

            int fireBallStartX1 = 0;
            int fireBallStartY1 = 0;

            int fireBallStartX2 = 0;
            int fireBallStartY2 = 0;

            int SpearStartX1 = 0;
            int SpearStartY1 = 0;
                
            int SpearStartX2 = 0;
            int SpearStartY2 = 0;


            while (firstPlayer.IsDead == false && secondPlayer.IsDead == false)
            {
                
                if (Console.KeyAvailable)
                {

                    ConsoleKeyInfo usr = Console.ReadKey();  
                    if (usr.Key == ConsoleKey.D)            //moving the left fighter 
                    {
                        if(firstPlayer.x + 8 < Console.WindowWidth-3)
                        firstPlayer.x += 3;
                    }
                    else if(usr.Key == ConsoleKey.A)        //moving the left fighter 
                    {
                        if(firstPlayer.x-3 > 3 )
                        firstPlayer.x -= 3;
                    }


                    if(usr.Key == ConsoleKey.LeftArrow)              //moving the right fighter 
                    {
                        if (secondPlayer.x - 6 > 3)
                            secondPlayer.x -= 3;
                    }
                    else if(usr.Key == ConsoleKey.RightArrow)        //moving the right fighter 
                    {
                        if (secondPlayer.x + 7 < Console.WindowWidth - 3)
                        secondPlayer.x += 3;
                    }






                    if (usr.Key == ConsoleKey.S)             //squating the left fighter
                    {
                        firstPlayer.IsHeSquatting = true;

                    }
                    if (usr.Key == ConsoleKey.DownArrow)     //squating the right fighter 
                    {
                        secondPlayer.IsHeSquatting = true;
                    }




                    if(usr.Key == ConsoleKey.W)       
                    {
                        if(firstPlayer.IsHeSquatting == true)     //stand up left fighter
                        {
                            firstPlayer.IsHeSquatting = false;
                            firstPlayer.y -= 4;
                            firstPlayer.alreadySquatting = 1;
                        }
                        else
                        {
                            firstPlayer.isJumping = true;         // jumping left fighter 
                            
                        }
                    }

                    

                    if (usr.Key == ConsoleKey.UpArrow)
                    {
                        if (secondPlayer.IsHeSquatting == true)   //stand up right fighter
                        {
                            secondPlayer.IsHeSquatting = false;
                            secondPlayer.y -= 4;
                            secondPlayer.alreadySquatting = 1;
                        }
                        else
                        {
                           secondPlayer.isJumping = true;         // jumping right fighter 

                        }
                    }



                    if(usr.Key == ConsoleKey.Q)                  //Blade attacking <3 
                    {
                       firstPlayer.activeBlade = true;
                    }

                    if(usr.Key == ConsoleKey.J)
                    {
                        secondPlayer.activeBlade = true;
                    }
                    



                    if(usr.Key == ConsoleKey.E)                //fireball
                    {
                        if (firstPlayer.mana > 1)
                        {
                            firstPlayer.IsShoutingFireBall = true;
                            fireBallStartX1 = firstPlayer.x;
                            fireBallStartY1 = firstPlayer.y;
                            if(firstPlayer.IsFireballAlreadyFlying == false)
                            firstPlayer.mana -= 5;
                            firstPlayer.IsFireballAlreadyFlying = true;
                        }
                       
                        
                        
                    }
                    if (usr.Key == ConsoleKey.K)
                    {
                        if(secondPlayer.mana > 1)
                        {
                            
                            secondPlayer.IsShoutingFireBall = true;
                            fireBallStartX2 = secondPlayer.x;
                            fireBallStartY2 = secondPlayer.y;

                            if(secondPlayer.IsFireballAlreadyFlying == false)
                            {
                                secondPlayer.mana--;
                            }
                            secondPlayer.IsFireballAlreadyFlying = true;
                        }
                       

                    }
                    if(usr.Key == ConsoleKey.R)
                    {
                        firstPlayer.IsThrowingSpear  = true;
                        SpearStartX1 = firstPlayer.x;
                        SpearStartY1 = firstPlayer.y;
                    }
                    if(usr.Key == ConsoleKey.L)
                    {
                        secondPlayer.IsThrowingSpear = true;
                        SpearStartX2 = secondPlayer.x;
                        SpearStartY2 = secondPlayer.y;
                    }
                }
                
                if (firstPlayer.isJumping == true)                                                                                         //the jumping itself 
                {                                                                                                                          //the jumping itself 
                    jump(ref firstPlayer, ref firstPlayer.isFallingDown, ref firstPlayer.jumpingCounter, ref firstPlayer.isJumping);       //the jumping itself 
                }                                                                                                                          //the jumping itself 
                if (secondPlayer.isJumping == true)                                                                                        //the jumping itself 
                {                                                                                                                          //the jumping itself 
                    jump(ref secondPlayer, ref secondPlayer.isFallingDown, ref secondPlayer.jumpingCounter, ref secondPlayer.isJumping);   //the jumping itself 
                }
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                
                if(firstPlayer.IsShoutingFireBall == true)
                {
                    LaunchTheBall(firstPlayer, fireBallStartX1,fireBallStartY1);
                }
                if (secondPlayer.IsShoutingFireBall == true)
                {
                    LaunchTheBall(secondPlayer, fireBallStartX2, fireBallStartY2);
                }
                Console.ForegroundColor = ConsoleColor.Yellow;

                if (firstPlayer.IsThrowingSpear == true)
                {
                    LaunchTheSpear(firstPlayer,SpearStartX1 ,SpearStartY1 );
                }
                if(secondPlayer.IsThrowingSpear == true)
                {
                    LaunchTheSpear(secondPlayer,SpearStartX2,SpearStartY2);
                }
                DrawRoad(0, Console.WindowHeight - 2);

                Console.ForegroundColor = ConsoleColor.Red;

                firstPlayer.Print(firstPlayer.x, firstPlayer.y, firstPlayerCordinations);                 //printing the fighters
                secondPlayer.Print(secondPlayer.x, secondPlayer.y, secondPlayerCordinations);             //printing the fighters

                Console.ForegroundColor = ConsoleColor.White;
                AttackingWithTheBlade(firstPlayer);
                AttackingWithTheBlade(secondPlayer);
                Console.ForegroundColor = ConsoleColor.Red;
                firstPlayer.PrintHealth(2, 2,firstPlayer);
                secondPlayer.PrintHealth(Console.WindowWidth - secondPlayer.health-2, 2,secondPlayer );
                

                System.Threading.Thread.Sleep(20);
                
                foreach (var Plcordinat in firstPlayer.playerCordinations)
                {
                    foreach (var Wpcordinat in secondPlayer.weapons)
                    {
                        if(Plcordinat.x == Wpcordinat.x && Plcordinat.y == Wpcordinat.y)
                        {
                            if (firstPlayer.health <1 )
                            {
                                firstPlayer.IsDead = true;
                            }
                            else
                            {
                                firstPlayer.health--;
                                if (firstPlayer.x - 2 > 3)
                                    firstPlayer.x--;
                            }
                            
                           

                        }/*     /
                          *    /
                          *   / 
                          * \/
                          *  \   */
                    }
                }
                foreach (var Plcordinat in secondPlayer.playerCordinations)
                {
                    foreach (var Wpcordinat in firstPlayer.weapons)
                    {
                        if (Plcordinat.x == Wpcordinat.x && Plcordinat.y == Wpcordinat.y)
                        {
                            if(secondPlayer.health < 1)
                            {
                                secondPlayer.IsDead = true;
                            }
                            else
                            {
                                secondPlayer.health--;
                                if(secondPlayer.x+5<Console.WindowWidth - 3)
                                secondPlayer.x++;
                            }

                        }
                    }
                }
                firstPlayer.weapons.Clear();
                firstPlayer.playerCordinations.Clear();

                secondPlayer.weapons.Clear();
                secondPlayer.playerCordinations.Clear();
                if(firstPlayer.IsDead == false && secondPlayer.IsDead == false)
                Console.Clear();
                firstPlayer.PrintHealth(2, 2, firstPlayer);
                secondPlayer.PrintHealth(Console.WindowWidth - secondPlayer.health - 2, 2, secondPlayer);
            }
            Console.SetCursorPosition(Console.WindowWidth / 2, 1);
            if(firstPlayer.IsDead == false)
            {
                Console.Write("Player one wins!");
                Console.SetCursorPosition(Console.WindowWidth / 2, 1);
                Console.Write("Press Enter to continue...");
            }
            else
            {
                Console.Write("Player two wins!");
                Console.SetCursorPosition(Console.WindowWidth / 2, 1);
                Console.Write("Press Enter to continue...");
            }
            
            ConsoleKeyInfo user = Console.ReadKey();
            while (user.Key != ConsoleKey.Enter)
            {
                user = Console.ReadKey();
            }

        }
        private static void LaunchTheSpear(Fighter fighter, int startX, int startY)
        {
            if (fighter.GetType().FullName == "Fight.FirstFighter")
            {
                if(startX + 4 + fighter.SpearMovement + 11 < Console.WindowWidth)
                {
                    fighter.PrintTheSpear(startX + 4 + fighter.SpearMovement, startY);
                    fighter.SpearMovement += 5;
                }
                else
                {
                    fighter.SpearMovement = 0;
                    fighter.IsThrowingSpear = false;
                }
            }
            else
            {
                if (startX - 4 - fighter.SpearMovement - 1 > 0)
                {
                    fighter.PrintTheSpear(startX - 4 - fighter.SpearMovement, startY);
                    fighter.SpearMovement += 5;
                }
                else
                {
                    fighter.SpearMovement = 8;
                    fighter.IsThrowingSpear = false;
                }
            }   
        }
        private static void LaunchTheBall (Fighter fighter,int x,int y)
        {
            if (fighter.GetType().FullName == "Fight.FirstFighter")
            {
                if (x + fighter.FireBallDirection + 7 < Console.WindowWidth)
                {
                    fighter.PrintFireBall(x + fighter.FireBallDirection, y);
                    fighter.FireBallDirection += 4;
                }
                else
                {
                    fighter.IsShoutingFireBall = false;
                    fighter.FireBallDirection = 2;
                    fighter.IsFireballAlreadyFlying = false;
                }
            }
            else
            {
                if(x - fighter.FireBallDirection+4 > 0)
                {
                    fighter.PrintFireBall(x - fighter.FireBallDirection, y);
                    fighter.FireBallDirection += 4;
                }
                else
                {
                    fighter.IsShoutingFireBall = false;
                    fighter.FireBallDirection = 10;
                    fighter.IsFireballAlreadyFlying = false;
                }
            }
            
            
        }
        private static void jump(ref Fighter fighter, ref bool isFallingDown, ref int jumpingCounter, ref bool isJumping)
        {
            if (isFallingDown == false)
            {
                jumpingCounter++;
                
                fighter.y -= 2;
            }
            else
            {
                fighter.y += 2;
                jumpingCounter--;
                if (jumpingCounter == 0)
                {
                    isJumping = false;
                    isFallingDown = false;
                }
            }
            if (jumpingCounter == 4)
            {
                
                isFallingDown = true;
            }
        }
        private static void DrawRoad(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(new string('_', Console.WindowWidth - 1));
        }
        private static void AttackingWithTheBlade(Fighter fighter)
        {
            if (fighter.activeBlade == true)
            {
                if (fighter.bladeStaying != 4)
                {
                    fighter.BladeAttacking(fighter.x, fighter.y);
                    fighter.bladeStaying++;
                }
                else
                {
                    fighter.activeBlade = false;
                    fighter.bladeStaying = 0;
                }
            }
        }
    }
}
