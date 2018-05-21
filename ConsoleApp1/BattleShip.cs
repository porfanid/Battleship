using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BattleShip
    {
        String playerName1;
        String playerName2;
        int[,] ShipBoardPlayer1;
        int[,] StrikeBoardPlayer1;
        int[,] ShipBoardPlayer2;
        int[,] StrikeBoardPlayer2;
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


        private void wait(int seconts)
        {
            try
            {
                System.Threading.Thread.Sleep(seconts * 1000);
            }
            catch (Exception)
            {

            }
        }



        private static bool GetRegistryInfo()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Battleship_Evaluation");
            string value = key.GetValue("Evaluation").ToString();
            bool report;
            try
            {
                report = Convert.ToBoolean(value);
            }
            catch (Exception)
            {
                report = false;
            }
            return report;
        }




        private void HumanVsHuman()
        {
            SlowPrint Slow = new SlowPrint();
            string emailaddress1="";
            int amount1=0;
            string emailaddress2 = "";
            int amount2 = 0;
            Paypalbet bet = new Paypalbet();



            //****************************************************************************		
            //		Player enter the names
            Console.WriteLine("Please enter the name for player 1: ");
            String playerName1 = Console.ReadLine();
            Console.WriteLine("Please enter the name for player 2: ");
            String playerName2 = Console.ReadLine();
            Console.WriteLine("\n");
            //****************************************************************************				

            string answer="";



            if (GetRegistryInfo())
            {
                Console.WriteLine("Do you wanna place a bet(Paypal will be used for this exact reason)?(yes/no)");
                answer = Console.ReadLine();
                while (answer != "yes" && answer != "no")
                {
                    Console.WriteLine("wrong input. Please try again.");
                    answer = Console.ReadLine();
                }

                if (answer == "yes")
                {
                    Console.WriteLine(playerName1 + " please enter your email address to receive your payment if you win");
                    emailaddress1 = Console.ReadLine();
                    Console.WriteLine("Now, please enter the amount of money you are willing to bet.");
                    string amount1AsString = Console.ReadLine();

                    while (true)
                    {
                        try
                        {
                            amount1 = Int32.Parse(amount1AsString);
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("wrong input. Please try again");
                            amount1AsString = Console.ReadLine();
                        }
                    }


                    Console.WriteLine(playerName2 + " please enter your email address to receive your payment if you win");
                    emailaddress2 = Console.ReadLine();
                    Console.WriteLine("Now, please enter the amount of money you are willing to bet.");
                    string amount2AsString = Console.ReadLine();

                    while (true)
                    {
                        try
                        {
                            amount2 = Int32.Parse(amount2AsString);
                            break;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("wrong input. Please try again");
                            amount2AsString = Console.ReadLine();
                        }
                    }
                }
            }













            //****************************************************************************		
            ShipBoard boardPlayer1 = new ShipBoard();
            //****************************************************************************		



            //****************************************************************************		
            Console.Clear();


            //****************************************************************************		
            // creates player 1 and a ShipBoard for him.
            HumanPlayer player1 = new HumanPlayer(playerName1);
            //****************************************************************************		



            //****************************************************************************		
            // creates player 2 and a ShipBoard for him.
            HumanPlayer player2 = new HumanPlayer(playerName2);
            ShipBoard boardPlayer2 = new ShipBoard();
            //****************************************************************************		
            //****************************************************************************		
            //		player 2 places his ships
            Console.WriteLine("Place your ships player: " + playerName1);
            boardPlayer1.enterAllShipsManually();
            //****************************************************************************		
            //****************************************************************************		
            //		return the ship and strike board of player 2
            int[,] ShipBoardPlayer1 = boardPlayer1.returnBoard();
            int[,] StrikeBoardPlayer1 = player1.returnStrikeBoard();

            //****************************************************************************		
            //****************************************************************************		
            //		print the shipboard
            Console.WriteLine("The ship board for player: " + playerName1 + " is :\n");
            printBoard(ShipBoardPlayer1);
            //****************************************************************************		
            Console.Clear();
            //****************************************************************************








            //****************************************************************************		
            //		player 2 places his ships
            Console.WriteLine("Place your ships player: " + playerName2);
            boardPlayer2.enterAllShipsManually();

            //****************************************************************************		
            //		return the ship and strike board of player 2
            int[,] ShipBoardPlayer2 = boardPlayer2.returnBoard();
            int[,] StrikeBoardPlayer2 = player2.returnStrikeBoard();


            //****************************************************************************		
            //		print the ship board
            Console.WriteLine("The ship board for player: " + playerName2 + " is :\n");
            printBoard(ShipBoardPlayer2);
            //****************************************************************************		
            Console.Clear();
            //****************************************************************************		
            bool allSank = false;
		    while(!allSank)
		    {
                //****************************************************************************			
                //			    Player1

                Console.WriteLine("Hit point for: "+playerName1);

                int[] coordinates = player1.nextStrike();
                //			System.out.println( coordinates[0]+" , "+coordinates[1]);
                bool isHit = boardPlayer1.getStrike(coordinates[0], coordinates[1]);
                //			System.out.print("Main isHit= "+isHit);
                int[,] strikeBoardPlayer1 = player1.update(coordinates, isHit);
                Console.WriteLine("The strike board for player: "+playerName1+" is :\n");
                printBoard(strikeBoardPlayer1);
                bool allSank1 = boardPlayer1.allShipsSank();			
			
			
//			Check if All of Player 1 Ships have been Sank.
			
			    if(allSank1)
			    {
                    if (GetRegistryInfo() == true)
                    {
                        if (answer == "yes")
                        {
                            bet.makePayment(emailaddress2, amount1);
                        }
                    }
                    allSank =allSank1;
                    Console.WriteLine(player2+" is the winner!!!");
				    break;
			    }

                //			Delay for 1 second

                wait(1);
                    //****************************************************************************			
                    //****************************************************************************			
                    //			Player2

                Console.WriteLine("Hit point for: "+playerName2);
                coordinates=player2.nextStrike();
    //			System.out.println( coordinates[0]+" , "+coordinates[1]);
			    isHit=boardPlayer2.getStrike(coordinates[0], coordinates[1]);
    //			System.out.print("Main isHit= "+isHit);
			    int[,] strikeBoardPlayer2 = player2.update(coordinates, isHit);
                    Console.WriteLine("The strike board for player: "+playerName2+" is :\n");
                    printBoard(strikeBoardPlayer2);
                bool allSank2 = boardPlayer2.allShipsSank();
			
			    if(allSank2)
			    {
                    
                    if (GetRegistryInfo() == true)
                    {
                        if (answer == "yes")
                        {
                            bet.makePayment(emailaddress1, amount2);
                        }
                    }
                    allSank =allSank2;
                    Console.WriteLine(player1+" is the winner!!!");
				    break;
			    }
				
		    }
            Console.WriteLine("Thanks for playing. That was a really nice game.");
		
	    }
	
	
	
		









        public void SavePlayer1Progress()
        {   
            GetProgress player1Progress = new GetProgress(playerName1, playerName1);
            player1Progress.SaveProgress(1, ShipBoardPlayer1, StrikeBoardPlayer1);
            return;
        }





        public void SavePlayer2Progress()
        {
            GetProgress player2Progress = new GetProgress(playerName2, playerName2);
            player2Progress.SaveProgress(1, ShipBoardPlayer2, StrikeBoardPlayer2);
        }



        private void HumanVsComputer()
        {
            SlowPrint Slow = new SlowPrint();





            //****************************************************************************		
            //		Player enter the names
            Console.WriteLine("Please enter the name for player 1: ");
            playerName1 = Console.ReadLine();
            Console.WriteLine("Please enter the name for player 2: ");
            playerName2 = Console.ReadLine();
            Console.WriteLine("\n");
            //****************************************************************************	
            // check the age of the player
            //	Change the credentials here	
            //ageControl(playerName2, "test", "test");
            //****************************************************************************		







            ShipBoard boardPlayer1 = new ShipBoard();




            //****************************************************************************	
            Console.Clear();
            //****************************************************************************	

            //****************************************************************************	
            // creates player 1 and a ShipBoard for him.
            RandomStrategy pcStrategy = new RandomStrategy();
            ComputerPlayer player1 = new ComputerPlayer(playerName1);





            //****************************************************************************
            // creates player 2 and a ShipBoard for him.
            HumanPlayer player2 = new HumanPlayer(playerName2);
            ShipBoard boardPlayer2 = new ShipBoard();

            //****************************************************************************		
            //		player 1 places his ships
            Console.WriteLine("Place your ships player: " + playerName1);
            boardPlayer1.enterAllShipsRandomly();
            //****************************************************************************		
            //		return the ship and strike board
            ShipBoardPlayer1 = boardPlayer1.returnBoard();
            StrikeBoardPlayer1 = player1.returnStrikeBoard();


            //****************************************************************************		
            //		print the shipboard
            Console.WriteLine("The ship board for player: " + playerName1 + " is :\n");
            printBoard(ShipBoardPlayer1);
            //****************************************************************************		
            Console.Clear();
            //****************************************************************************








            //****************************************************************************		
            //		player 2 places his ships
            Console.WriteLine("Place your ships player: " + playerName2);
            boardPlayer2.enterAllShipsManually();
            //****************************************************************************		
            //****************************************************************************		
            //		return the ship and strike board of player 2
            ShipBoardPlayer2 = boardPlayer2.returnBoard();
            StrikeBoardPlayer2 = player2.returnStrikeBoard();
            //****************************************************************************		


            //		print the ship board
            Console.Write("The ship board for player: " + playerName2 + " is :\n");
            printBoard(ShipBoardPlayer2);
            //****************************************************************************		
            //	Creating 2 threads to run simultaneously with the main(Parallel prossesing)


            // We want to start just 2 threads at the same time, but let's control that 
            // timing from the main thread. That's why we have 3 "parties" instead of 2.		
            //            System.Threading.Barrier gate = new System.Threading.Barrier(3);


            //		Creating threads.		

            SavePlayer1Progress();

            SavePlayer2Progress();






            
            

            bool allSank = false;
            while (!allSank)
            {
                //****************************************************************************			
                //			Player1

                Console.WriteLine("Hit point for: " + playerName1);

                int[] coordinates = pcStrategy.nextStrike();
                //			System.out.println( coordinates[0]+" , "+coordinates[1]);
                bool isHit = boardPlayer1.getStrike(coordinates[0], coordinates[1]);
                //			System.out.print("Main isHit= "+isHit);
                int[,] strikeBoardPlayer1 = player1.update(coordinates, isHit);
                Console.WriteLine("The strike board for player: " + playerName1 + " is :\n");
                printBoard(strikeBoardPlayer1);
                bool allSank1 = boardPlayer1.allShipsSank();


                //			Check if All of Player 1 Ships have been Sank.

                if (allSank1)
                {
                    Console.WriteLine(playerName2 + " is the winner!!!");
                    allSank = allSank1;
                    break;
                }

                //			Delay for 1 second

                wait(1);
                //****************************************************************************			
                //****************************************************************************			
                //			Player2

                Console.WriteLine("Hit point for: " + playerName2);
                coordinates = player2.nextStrike();
                //			System.out.println( coordinates[0]+" , "+coordinates[1]);
                isHit = boardPlayer2.getStrike(coordinates[0], coordinates[1]);
                //			System.out.print("Main isHit= "+isHit);
                int[,] strikeBoardPlayer2 = player2.update(coordinates, isHit);
                Console.WriteLine("The strike board for player: " + playerName2 + " is :\n");
                printBoard(strikeBoardPlayer2);
                bool allSank2 = boardPlayer2.allShipsSank();
                //****************************************************************************		
                //****************************************************************************			
                if (allSank2)
                {
                    Console.WriteLine(playerName1 + " is the winner!!!");
                    allSank = allSank2;
                    break;
                }
                SavePlayer1Progress();

                SavePlayer2Progress();
            }
        }




        public void StartGame()
        {

            //		This creates the animation at the beginning of the programm.
            //****************************************************************************
            //****************************************************************************		
;
            //		Takes the user input and considers if the user wants to play versus human or cpu
            Console.WriteLine("Do you want to play against computer or CPU(player/CPU).");
            String versus = Console.ReadLine();
            while (versus!="player" && versus!="CPU")
            {
                Console.WriteLine("Wrong input. Please try again.");
                versus = Console.ReadLine();
            }



            if (versus=="CPU")
            {
                HumanVsComputer();
            }
            if (versus=="player")
            {
                HumanVsHuman();
            }
        }
    }
}
