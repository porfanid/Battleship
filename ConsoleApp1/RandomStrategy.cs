using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class RandomStrategy
    {
        private Random rand = new Random();
        //	private Scanner keyboard=new Scanner(System.in);
        private int[,] strikeBoard = new int[10,10];
        private int Coordinate;
        private int myInteger;




        private int AutoBetweenLimits(String InputString)
        {
            checkLimits(InputString);
            // the sum eith size with coordinates. It must not be greater than 10. If it is, it will be out of bounds.
            int myLimit = this.Coordinate;
            // check if size is greater than 10.
            while (myLimit > 10)
            {
                Console.WriteLine("Out of Limits.Please try again.");
                InputString = rand.Next(1,10).ToString();
                checkLimits(InputString);
                myLimit = this.Coordinate;
            }
            return myLimit;
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
                    InputString = rand.Next(1, 10).ToString();
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
                //			Random rand = new Random();
                Console.WriteLine("Out of limits. Please try again.");
                InputString = rand.Next(1, 10).ToString();
                this.Coordinate = isInteger(InputString); ;
            }
            return this.Coordinate;
        }
        //	Get the coordinates for the next strike
        public int[] nextStrike()
        {
            //		Random rand = new Random();
            bool checkHit = true;
            String ReadLine;
            int[] coordinates = new int[2];
            while (checkHit)
            {
                //			System.out.println("Please enter the horizontal position to strike:");
                ReadLine = rand.Next(1, 10).ToString();
                int Xcoord = AutoBetweenLimits(ReadLine);
                coordinates[0] = Xcoord;
                //			System.out.println("Please enter the vertical position to strike:");
                ReadLine = rand.Next(1, 10).ToString();
                int Ycoord = AutoBetweenLimits(ReadLine);
                coordinates[1] = Ycoord;
                //int[] coordinates={Xcoord,Ycoord};


                //check if posision has been stoke previously
                if (strikeBoard[coordinates[0] - 1,coordinates[1] - 1] == 0)
                {
                    checkHit = false;
                }
                else
                {
                    Console.WriteLine("The position has been stoke previously. Please try again.");
                }
            }
            return coordinates;
        }

        //	update the strike board with the new hit


        public int[,] update(int[] coordinates, bool isHit)
        {
            Console.WriteLine("Update Function: ");
            Console.WriteLine("coords are: " + coordinates[0] + " , " + coordinates[1]);
            Console.WriteLine("isHit= " + isHit);
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
