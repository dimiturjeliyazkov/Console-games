using System;
using System.Collections.Generic;
using System.Text;

namespace Fight
{
    class SecondFighter : Fighter
    {
        private int fireballDirection;
        int pos = 1;
        int pos2 = 1;
        public override int FireBallDirection
        {
            get { return fireballDirection; }
            set { fireballDirection = value; }
        }
        public SecondFighter(int x, int y, int fireballDirection, int spearMovement)
        {
            this.x = x;
            this.y = y;
            FireBallDirection = fireballDirection;
            SpearMovement = spearMovement;
        }
        
        private int spearMovement;
        public override int SpearMovement { get => spearMovement; set => spearMovement = value; }
        public override void PrintTheSpear(int x, int y)
        {
            Console.SetCursorPosition(x, y);
            for (int i = 0; i < 3; i++)
            {
                weapons.Add(new Cordinat(x + i, y));
            }
            Console.Write('<' + new string('-', 10) );
        }
        public override void BladeAttacking(int x, int y)
        {
            for (int i = 4; i < 12; i++)
            {
                if (i == 4)
                {
                    Console.SetCursorPosition(x - 1 - i, y + 5);
                    weapons.Add(new Cordinat(x - 1 - i, y + 5));
                    Console.Write("*");
                }

                {
                    Console.SetCursorPosition(x - 1 - i++, y + 4);
                    weapons.Add(new Cordinat(x - 1 - i, y + 4));
                    Console.Write("*");
                }
            }
        }

        public override void PrintLeftHand(int x, int y)
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 4)
                {
                    Console.SetCursorPosition(x - 1 - i++, y + 3);
                    playerCordinations.Add(new Cordinat(x - 1 - i, y + 3));
                    Console.Write("*");
                }
                else
                {
                    Console.SetCursorPosition(x - 1 - i++, y + 4);
                    playerCordinations.Add(new Cordinat(x - 1 - i, y + 4));
                    Console.Write("*");
                }
            }
        }

        public override void PrintRightHand(int x, int y)
        {
            if (IsShoutingFireBall == true && pos == 1)
            {
                pos++;
            }
            if (IsThrowingSpear == true && pos2 == 1)
            {
                pos2++;
            }
            if ((pos == 1 || pos == 0) && (pos2 == 1 || pos2 == 0))
            {
                for (int i = 0; i < 2; i++)
                {
                    Console.SetCursorPosition(x + 5, y + 2 + i);
                    playerCordinations.Add(new Cordinat(x + 5, y + 2 + i));
                    Console.Write('*');
                }
                Console.SetCursorPosition(x + 3, y + 4);
                playerCordinations.Add(new Cordinat(x + 3, y + 4));
                Console.Write('*');
                if (IsShoutingFireBall == false)
                {
                    pos = 1;
                }
                if (IsThrowingSpear == false)
                {
                    pos2 = 1;
                }
            }
            else if(pos > 1)
            {
                pos++;
                if (pos == 8)
                {
                    pos = 0;
                }
                for (int i = 0; i < 5; i++)
                {

                    if (i == 4)
                    {
                        Console.SetCursorPosition(x - 1 - i++, y + 7);
                        playerCordinations.Add(new Cordinat(x - 1 - i, y + 7));
                        Console.Write("*");
                    }
                    else
                    {
                        Console.SetCursorPosition(x - 3 + i++, y + 6);
                        playerCordinations.Add(new Cordinat(x - 3 + i, y + 6));
                        Console.Write("*");
                    }
                }

            }
            else if(pos2 > 1)
            {
                pos2++;
                if (pos2 == 3)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Console.SetCursorPosition(x + 3 + i, y + 4 - i);
                        playerCordinations.Add(new Cordinat(x + 3 + i, y + 4 - i));
                        Console.Write('*');
                    }
                }
                else
                {
                    for (int i = 0; i < 4; i++)
                    {
                        Console.SetCursorPosition(x - i, y + 4 - i);
                        playerCordinations.Add(new Cordinat(x - i, y + 4 - i));
                        Console.Write('*');
                    }
                }
                if (pos2 == 8)
                {
                    pos2 = 0;
                }
            }
        }
    }
}
