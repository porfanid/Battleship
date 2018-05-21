using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class HumanPlayer
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


        //	reset the constructor
        public HumanPlayer(String playerName)
        {
            this.playerName = playerName;
        }

        // return the Strike Boaard	
        public int[,] returnStrikeBoard()
        {
            return strikeBoard;
        }



        // return the players name	
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



        public int[] nextStrike()
        {
            bool checkHit = true;
            String ReadLine;
            int[] coordinates = new int[2];
            while (checkHit)
            {
                Console.WriteLine("Please enter the horizontal position to strike:");
                ReadLine = Console.ReadLine();
                int Xcoord = BetweenLimits(ReadLine);
                Console.WriteLine("Please enter the vertical position to strike:");
                ReadLine = Console.ReadLine();
                int Ycoord = BetweenLimits(ReadLine);
                //int[] coordinates={Xcoord,Ycoord};
                coordinates[0] = Xcoord;
                coordinates[1] = Ycoord;
                //check if posision has been stoke previously
                if (strikeBoard[coordinates[0] - 1,coordinates[1] - 1] == 0)
                {
                    checkHit = false;
                }
                else
                {
                    Console.WriteLine("The posision has been stoke previously. Please try again.");
                }
            }
            return coordinates;
        }


        // print the board	

        private void printBoard(int[,] ShipBoard)
        {
            // print board
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(ShipBoard[i,j] + " ");
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
                strikeBoard[coordinates[0] - 1,coordinates[1] - 1] = 1;
            }
            else
            {
                strikeBoard[coordinates[0] - 1,coordinates[1] - 1] = -1;
            }
            return strikeBoard;
        }
    }
}