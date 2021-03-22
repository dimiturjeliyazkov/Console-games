using System;
using System.Collections.Generic;
using System.Text;

namespace Fight
{
    abstract class Fighter
    {
        public abstract int FireBallDirection { get; set; }

        public int alreadySquatting = 1;
        public bool isJumping = false;
        public int jumpingCounter = 0;
        public bool isFallingDown = false;
        public int bladeStaying = 0;
        public bool activeBlade = false;
        public bool IsShoutingFireBall = false;
        public bool IsFireballAlreadyFlying = false;
        public bool IsThrowingSpear = false;
        public bool IsDead = false;
        public int health = 30;
        public int mana = 30;
        public List<Cordinat> playerCordinations = new List<Cordinat>();
        public List<Cordinat> weapons = new List<Cordinat>();
        public abstract int SpearMovement { get; set; }
        public int x { get; set; }
        public int y { get; set; }

        private bool isHeSquatting;

        public bool IsHeSquatting
        {
            get { return isHeSquatting; }
            set { isHeSquatting = value; }
        }
        public void PrintHead(int x, int y, List<Cordinat> FC)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(new string('*', 3));
            playerCordinations.Add(new Cordinat(x , y));
            playerCordinations.Add(new Cordinat(x + 1, y));
            playerCordinations.Add(new Cordinat(x + 2, y));
            Console.SetCursorPosition(x - 1, y + 1);
            Console.Write("*(.)*");
            playerCordinations.Add(new Cordinat(x , y+1));
            playerCordinations.Add(new Cordinat(x + 1, y+1));
            playerCordinations.Add(new Cordinat(x + 2, y+1)); 
            playerCordinations.Add(new Cordinat(x + 3, y+1));
            playerCordinations.Add(new Cordinat(x + 4, y+1));
            Console.SetCursorPosition(x, y + 2);
            Console.Write(new string('*', 3));
            playerCordinations.Add(new Cordinat(x, y=2));
            playerCordinations.Add(new Cordinat(x + 1, y+2));
            playerCordinations.Add(new Cordinat(x + 2, y+2));
        }
        public void PrintBody(int x, int y)
        {
            for (int i = 0; i < 6; i++)
            {
                Console.SetCursorPosition(x + 1, y + 3 + i);
                playerCordinations.Add(new Cordinat(x + 1, y + 3 + i));
                Console.Write('*');
            }
        }
        abstract public void PrintLeftHand(int x, int y);

        abstract public void PrintRightHand(int x, int y);
        
        public void PrintLegs(int x, int y)
        {
            if(IsHeSquatting == false && jumpingCounter == 0)
            {
                int spaceBetweenLegs = 1;
                for (int i = 0; i < 5; i++)
                {
                    Console.SetCursorPosition(x - i, y + 9 + i);
                    playerCordinations.Add(new Cordinat(x - 1, y + 9 + i));
                    playerCordinations.Add(new Cordinat(x - 1, y + 9 + i + spaceBetweenLegs + 1));
                    Console.Write('*' + new string(' ', spaceBetweenLegs) + '*');
                    spaceBetweenLegs += 2;

                }
            }
            else if(IsHeSquatting == true)
            {
                Squatting(x, y);
                if (alreadySquatting == 1)
                {
                    
                    this.y += 4;
                    alreadySquatting = 2;
                    Console.Clear();
                }
                
                
                 
              //  IsHeSquatting = false;
            }
            if (jumpingCounter > 1)
            {
                Squatting(x, y);

            }
            else if(jumpingCounter == 1)
            {
                int spaceBetweenLegs = 1;
                for (int i = 0; i < 5; i++)
                {
                    if (i < 3)
                    {
                        Console.SetCursorPosition(x - i, y + 9 + i);
                        playerCordinations.Add(new Cordinat(x - 1, y + 9 + i));
                        playerCordinations.Add(new Cordinat(x - 1+spaceBetweenLegs+1, y + 9 + i));
                        Console.Write('*' + new string(' ', spaceBetweenLegs) + '*');
                        spaceBetweenLegs += 2;
                    }
                    else
                    {
                        Console.SetCursorPosition(x - 3, y + 9 + i);
                        playerCordinations.Add(new Cordinat(x - 3, y + 9 + i));
                        playerCordinations.Add(new Cordinat(x - 3+spaceBetweenLegs+1, y + 9 + i));
                        Console.Write('*' + new string(' ', spaceBetweenLegs) + '*');
                    }
                }
            }
        }
        public void Squatting(int x,int y)
        {
            
            Console.SetCursorPosition(x - 1, y + 8);
            playerCordinations.Add(new Cordinat(x - 1, y + 8));
            Console.Write('*');

            Console.SetCursorPosition(x + 3, y + 8);
            playerCordinations.Add(new Cordinat(x + 3, y + 8));
            Console.Write('*');

            for (int i = 0; i < 3; i++)
            {
                Console.SetCursorPosition(x - 2 - i, y + 7 + i);
                playerCordinations.Add(new Cordinat(x - 2 - i, y + 7 + i));
                Console.Write('*');
                Console.SetCursorPosition(x + 4 + i, y + 7 + i);
                playerCordinations.Add(new Cordinat(x + 4 + i, y + 7 + i));
                Console.Write('*');
            }

        }
        abstract public void BladeAttacking(int x, int y);

        abstract public void PrintTheSpear(int x, int y);
        public void PrintFireBall(int x, int y)
        {

            for (int i = 0; i < 3; i++)
            {
                if(i!= 1)
                {
                    Console.SetCursorPosition(x+5, y+5 + i);
                    for (int k = 0; k < 3; k++)
                    {
                        weapons.Add(new Cordinat(x + 5 + k, y + 5 + i));
                    }
                    Console.Write(new string('@',3));
                }
                else
                {
                    Console.SetCursorPosition(x+4, y+5 + i);
                    for (int k = 0; k < 5; k++)
                    {
                        weapons.Add(new Cordinat(x + 4 + k, y + 5 + i));
                    }
                    Console.Write(new string('@',5));
                }
            }
            /*
             
            @@@
           @@@@@
            @@@

             */
        }
        public void PrintHealth(int x, int y,Fighter fighter)
        {
            Console.SetCursorPosition(x, y - 1);
            if (fighter.GetType().FullName == "Fight.FirstFighter")
            {
                Console.Write("Player 1");
                Console.SetCursorPosition(x, y + 1);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(new string('|', mana));
            }
            else
            {
                Console.SetCursorPosition(x+health-9, y - 1);
                Console.Write("Player 2");
                
                Console.ForegroundColor = ConsoleColor.Blue;
                for (int i = Console.WindowWidth - 3; i > Console.WindowWidth - 3-mana; i--)
                {
                    Console.SetCursorPosition(i, y + 1);
                    Console.Write('|');
                }
            }
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(new string('|',health));

            

            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void Print(int x, int y, List<Cordinat> FC)
        {
            PrintHead(x, y, FC);
            PrintBody(x, y);
            PrintLeftHand(x, y);
            PrintRightHand(x, y);
            PrintLegs(x, y);

            /*
             ***
            * * *
          *  ***  
          *   *      *
            * * * * *   
              *    
              *  
              *
              *
             * *
            * 
             */
        }
       
    }
}
