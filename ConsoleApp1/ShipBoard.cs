using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class ShipBoard
    {
        private Random rand = new Random();
        private int[] ShipSizes = { 2, 3, 4, 5 };
        private String initialVertical;
        private int Vertical;
        private int initialHorizontalPosition;
        private int initialVerticalPosition;
        private String initialDirection;
        private int myInteger = -2;
        private int Coordinate;
        private int[,] ShipBoardForPlayer = new int[10,10];
        private int[,] hitBoard = new int[10,10];
        private bool isHit;
        private int[,] initialShipBoard = new int[10,10];
        private int ShipId;


        public int[,] returnBoard()
        {
            return ShipBoardForPlayer;
        }
        //--------------------------------------------------------------------------------------
        // Function BetweenLimits
        // check if the input with the size of the ship with the coordinates are greater than 10. 
        //--------------------------------------------------------------------------------------
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
                Console.WriteLine(InputString);
                myLimit = size + this.Coordinate - 1;
                Console.WriteLine("this.Coordinate in while = " + this.Coordinate);
                Console.WriteLine("My Limit in while = " + myLimit);
            }
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




        public bool getStrike(int x, int y)
        {
            bool isHit;
            //		boolean checkSank=true;
            int hitId = ShipBoardForPlayer[x - 1,y - 1];
            if (hitId == 0)
            {
                isHit = false;
            }
            else
            {
                isHit = true;
                ShipBoardForPlayer[x - 1,y - 1] = 0;
                // check if all places of ship are hit
                bool checkSank = lastStrikeSankShip(x, y, hitId);
            }


            //		System.out.print("get strike checkSank = "+checkSank);


            this.isHit = isHit;
            //		System.out.print("get strike isHit= "+isHit);
            return isHit;
        }




        public bool lastStrikeSankShip(int x, int y, int hitId)
        {
            bool checkSank = true;
            // check if all places of ship are hit
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ShipBoardForPlayer[i,j] == hitId)
                    {
                        checkSank = false;
                    }
                }
            }
            return checkSank;
        }




        public bool returnisHit()
        {
            return isHit;
        }



        public bool allShipsSank()
        {
            bool AllSank = true;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (ShipBoardForPlayer[i,j] != 0)
                    {
                        AllSank = false;
                    }
                }
            }
            return AllSank;
        }


        private void printBoard()
        {
            // print board
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(ShipBoardForPlayer[i,j] + " ");
                }
                Console.Write("\n");
            }
        }


        private void enterShipManually(int ShipId)
        {
            int size = 0;
            int sizeX;
            int sizeY;
            int checkplace = 0;
            if (ShipId < 2)
            {
                size = ShipId + 2;
            }
            if (ShipId >= 2)
            {
                size = ShipId + 1;
            }
            // Check the initial position. Whether it is horizontal or vertical.
            while (true)
            {
                Console.Write("Please enter the direction of the ship(V/H):");
                String initialDirection = Console.ReadLine();
                if (initialDirection=="V" || initialDirection=="H")
                {
                    this.initialDirection = initialDirection;
                    break;
                }
                else
                {
                    Console.Write("Wrong direction. Please try again.");
                }
            }

            if (this.initialDirection=="H")
            {
                sizeX = size;
                sizeY = 0;
            }
            else
            {
                sizeX = 0;
                sizeY = size;
            }
            // Check Horizontal Position
            Console.Write("Please enter the initial horizontal position of the ship:");
            String InputString = Console.ReadLine();
            //***************		
            BetweenLimits(sizeY, InputString);
            this.initialHorizontalPosition = myInteger;
            // Check Vertical Position
            Console.Write("Please enter the initial vertical position of the ship:");
            InputString = Console.ReadLine();
            //***************			
            BetweenLimits(sizeX, InputString);
            this.initialVerticalPosition = myInteger;
            // initialHorizontalPosition-1 (0<x<9   +sizeY-1 (contains x)
            if (this.initialDirection=="V")
            {
                for (int i = initialHorizontalPosition - 1; i < initialHorizontalPosition + sizeY - 1; i++)
                {
                    checkplace = checkplace + ShipBoardForPlayer[i,initialVerticalPosition - 1];
                }
                if (checkplace == 0)
                {
                    for (int i = initialHorizontalPosition - 1; i < initialHorizontalPosition + sizeY - 1; i++)
                    {
                        ShipBoardForPlayer[i,initialVerticalPosition - 1] = ShipId + 1;
                    }
                }
                else
                {
                    Console.Write("Occupied position. Retry\n");
                    this.ShipId--;
                }
            }
            else
            {
                // initialHorizontalPosition-1 (0<x<9   +sizeY-1 (contains x)
                for (int i = initialVerticalPosition - 1; i < initialVerticalPosition + sizeX - 1; i++)
                {
                    checkplace = checkplace + ShipBoardForPlayer[initialHorizontalPosition - 1,i];
                }
                if (checkplace == 0)
                {
                    for (int i = initialVerticalPosition - 1; i < initialVerticalPosition + sizeX - 1; i++)
                    {
                        ShipBoardForPlayer[initialHorizontalPosition - 1,i] = ShipId + 1;

                    }
                }
                else
                {
                    Console.Write("Occupied position. Retry\n");
                    this.ShipId--;
                }
            }
            printBoard();
        }


        public void enterAllShipsManually()
        {
            for (this.ShipId = 0; this.ShipId < 5; this.ShipId++)
            {
                Console.WriteLine("Ship: " + (this.ShipId + 1));
                enterShipManually(this.ShipId);
            }
            this.initialShipBoard =this.ShipBoardForPlayer;
        }




        private void AutomaticBetweenLimits(int size, String InputString)
        {
            checkLimits(InputString);
            // the sum of size with coordinates. It must not be greater than 10. If it is, it will be out of bounds.
            int myLimit = size + this.Coordinate - 1;
            // check if size is greater than 10.
            while (myLimit > 10)
            {
                Console.Write("Out of Limits.Please try again.");
                InputString = rand.Next(1, 10).ToString();
                checkLimits(InputString);
                myLimit = size + this.Coordinate - 1;
            }
        }



        public void enterAllShipsRandomly()
        {
            for (this.ShipId = 0; this.ShipId < 5; this.ShipId++)
            {
                Console.Write("Ship: " + (this.ShipId + 1));
                enterShipRandomly(this.ShipId);
            }
            initialShipBoard = ShipBoardForPlayer;
        }



        private void enterShipRandomly(int ShipId)
        {
            int size = 0;
            int sizeX;
            int sizeY;
            int checkplace = 0;
            if (ShipId < 2)
            {
                size = ShipId + 2;
            }
            if (ShipId >= 2)
            {
                size = ShipId + 1;
            }
            // Check the initial position. Whether it is horizontal or vertical.
            //System.out.println("Please enter the direction of the ship(V/H):");
            //String initialDirection=keyboard.nextLine();
            int Direction = rand.Next(1, 2);
            if (Direction == 0)
            {
                this.initialDirection = "V";
            }
            else
            {
                this.initialDirection = "H";
            }
            if (this.initialDirection=="H")
            {
                sizeX = size;
                sizeY = 0;
            }
            else
            {
                sizeX = 0;
                sizeY = size;
            }
            // Check Horisontal Position
            //***************
            String InputString = rand.Next(1, 10).ToString();
            AutomaticBetweenLimits(sizeY, InputString);
            this.initialHorizontalPosition = myInteger;
            //		System.out.println(HorizontalPosition);
            // Check Vertical Position
            //***************
            InputString = rand.Next(1, 10).ToString();
            AutomaticBetweenLimits(sizeX, InputString);
            this.initialVerticalPosition = myInteger;
            //		System.out.println(VerticalPosition);
            // initialHorizontalPosition-1 (0<x<9   +sizeY-1 (contains x)
            if (this.initialDirection=="V")
            {
                for (int i = initialHorizontalPosition - 1; i < initialHorizontalPosition + sizeY - 1; i++)
                {
                    checkplace = checkplace + ShipBoardForPlayer[i,initialVerticalPosition - 1];
                }
                if (checkplace == 0)
                {
                    for (int i = initialHorizontalPosition - 1; i < initialHorizontalPosition + sizeY - 1; i++)
                    {
                        ShipBoardForPlayer[i,initialVerticalPosition - 1] = ShipId + 1;
                    }
                }
                else
                {
                    Console.Write("Occupied position. Retry\n");
                    this.ShipId--;
                }
            }
            else
            {
                // initialHorizontalPosition-1 (0<x<9   +sizeY-1 (contains x)
                for (int i = initialVerticalPosition - 1; i < initialVerticalPosition + sizeX - 1; i++)
                {
                    checkplace = checkplace + ShipBoardForPlayer[initialHorizontalPosition - 1,i];
                }
                if (checkplace == 0)
                {
                    for (int i = initialVerticalPosition - 1; i < initialVerticalPosition + sizeX - 1; i++)
                    {
                        ShipBoardForPlayer[initialHorizontalPosition - 1,i] = ShipId + 1;

                    }
                }
                else
                {
                    Console.Write("Occupied position. Retry\n");
                    this.ShipId--;
                }
            }
            printBoard();
        }
    }
}