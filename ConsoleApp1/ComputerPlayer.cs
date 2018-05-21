using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ComputerPlayer
    {
        private Random rand = new Random();
        private String playerName;
        private int[][] ShipBoardP1;
        private int myInteger;
        private int Coordinate;
        private int[,] strikeBoard = new int[10,10];


        public int[][] returnBoard()
        {
            return ShipBoardP1;
        }
        // return the Strike Board	
        public int[,] returnStrikeBoard()
        {
            return strikeBoard;
        }
        // Set the name for the computer player	
        public ComputerPlayer(String playerName)
        {
            this.playerName = playerName;
        }



        //	return the computer's name


        public String toString()
        {
            return playerName;
        }




        private int isInteger(String InputString)
        {
            //		System.out.println("a1 "+  " - " + InputString);
            // Check if "InputString" is text then isInteger=0
            //while(myInteger!=-1253)
            while (true)
            {
                try
                {
                    int isInteger = Int32.Parse(InputString);
                    // make isInteger public var. When using try catch, the var used has to be public.
                    //Otherwise, it is treated as a local var and thus cannot be used outside of the current block.
                    myInteger = isInteger;
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Wrong input. Please try again.");
                    InputString = Console.ReadLine();
                    //				System.out.println("a3 "+  " - " + InputString);
                }
            }
            return myInteger;
        }




        private int AutoBetweenLimits(String InputString)
        {
            checkLimits(InputString);
            // the sum of size with coordinates. It must not be greater than 10. If it is, it will be out of bounds.
            int myLimit = this.Coordinate;
            // check if size is greater than 10.
            while (myLimit > 10)
            {
                Console.WriteLine("Out of Limits.Please try again.");
                InputString = rand.Next(1, 10).ToString();
                checkLimits(InputString);
                myLimit = this.Coordinate;
            }
            return myLimit;
        }

        private int checkLimits(String InputString)
        {
            this.Coordinate = isInteger(InputString);// set the Coordinate var as the integer set.
            while (myInteger < 1)
            {
                Console.WriteLine("Out of limits. Please try again.");
                InputString = Console.ReadLine();
                this.Coordinate = isInteger(InputString);
            }
            return this.Coordinate;
        }





        private void BetweenLimits(int size, String InputString)
        {
            checkLimits(InputString);
            // the sum eith size with coordinates. It must not be greater than 10. If it is, it will be out of bounds.
            int myLimit = size + this.Coordinate - 1;
            // check if size is greater than 10.
            while (myLimit > 10)
            {
                Console.WriteLine("Out of Limits.Please try again." + myLimit + "b");
                InputString = Console.ReadLine();
                checkLimits(InputString);
                myLimit = size + this.Coordinate - 1;
                //			System.out.println("this.Coordinate in while = "+this.Coordinate);
                //			System.out.println("My Limit in while = "+myLimit);
            }
        }



        private int BetweenLimits(String InputString)
        {
            checkLimits(InputString);
            // the sum eith size with coordinates. It must not be greater than 10. If it is, it will be out of bounds.
            int myLimit = this.Coordinate;
            // check if size is greater than 10.
            while (myLimit > 10)
            {
                Console.WriteLine("Out of Limits.Please try again.");
                InputString = Console.ReadLine();
                checkLimits(InputString);
                myLimit = this.Coordinate;
            }
            return myLimit;
        }





        private void printBoard(int[,] ShipBoard)
        {
            // print board
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(ShipBoard[i, j] + " ");
                }
                Console.Write("\n");
            }
        }



        // update the strikeboard with the hit	
        public int[,] update(int[] coordinates, bool isHit)
        {
            //		System.out.println("Update Function: ");
            //		System.out.println("coords are: " +coordinates[0]+" , "+coordinates[1]);
            //		System.out.println("isHit= "+ isHit);
            if (isHit)
            {
                strikeBoard[coordinates[0] - 1, coordinates[1] - 1] = 1;
            }
            else
            {
                strikeBoard[coordinates[0] - 1, coordinates[1] - 1] = -1;
            }
            return strikeBoard;
        }
    }
}
