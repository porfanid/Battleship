using System;
using System.Threading;
using System.Net;
namespace ConsoleApp1
{
    class Program
    {
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
            catch(Exception)
            {
                report = false;
            }
            return report;
        }






        






        private static void validate()
        {
            Console.WriteLine("Do you want to upgrade to pro?(yes/no)");
            string answer = Console.ReadLine();
            while (answer != "yes" && answer != "no")
            {
                Console.WriteLine("wrong input please try again");
                answer = Console.ReadLine();
            }
            if (answer == "no")
            {
                return;
            }
            Console.WriteLine("Do you want to have a license or do you want to upgrade online?(license/online)");
            answer = Console.ReadLine();
            while (answer != "license" && answer != "online")
            {
                Console.WriteLine("wrong input please try again");
                answer = Console.ReadLine();
            }
            if (answer == "license")
            {
                Validate validator = new Validate();
                validator.testLicense();
            }
            if (answer == "online")
            {
                Validate validator = new Validate();
                validator.testLicense();
            }
        }




        private static void orderOnline()
        {
            Console.WriteLine("Game is over. Do you want to order online?(yes/no)");
            string answer = Console.ReadLine();
            while (answer != "yes" && answer != "no")
            {
                Console.WriteLine("wrong input. Please try again.");
                answer = Console.ReadLine();
            }
            if (answer == "no")
            {
                return;
            }



            Console.WriteLine("Please choose online store(efood/deliveras)");
            answer = Console.ReadLine();
            while (answer != "deliveras" && answer != "efood")
            {
                Console.WriteLine("wrong input. Please try again.");
                answer = Console.ReadLine();
            }
            if (answer == "efood")
            {
                System.Diagnostics.Process.Start("https://www.e-food.gr/");
            }
            if (answer == "deliveras")
            {
                System.Diagnostics.Process.Start("https://www.deliveras.gr/");
            }
        }



        private static void contactDeveloper()
        {
            Console.WriteLine("Do you want to contact the developer?(yes/no)");
            string answer = Console.ReadLine();
            while (answer != "yes" && answer != "no")
            {
                Console.WriteLine("wrong input. Please try again.");
                answer = Console.ReadLine();
            }
            if (answer == "no")
            {
                return;
            }




            Console.WriteLine("via email or sip?(email/sip)");
            answer = Console.ReadLine();
            while (answer != "email" && answer != "sip")
            {
                Console.WriteLine("wrong input. Please try again.");
                answer = Console.ReadLine();
            }


            if (answer == "sip")
            {
                System.Diagnostics.Process.Start("https://app.onsip.com/app/call/?n=Pavlos%20Orfanidis&a=pavlos%40orfanidis.xyz");
            }
            if (answer == "email")
            {
                Console.Clear();
                Console.WriteLine("Please enter the subject");
                string subject= Console.ReadLine();
                Console.WriteLine("Please enter the message in a single line. (If you press enter the message will be sent.sorry about that)");
                string message = Console.ReadLine();
                Mail paul = new Mail();
                paul.contact(subject, message);
            }
        }





        private static void checkIfUserWantsPro()
        {
            if (!GetRegistryInfo())
            {
                validate();
            }
        }



        private static void donate()
        {
            if (!GetRegistryInfo())
            {
                Console.WriteLine("Do you want to donate to the developer?(yes/no)");
                string answer = Console.ReadLine();
                while (answer != "yes" && answer != "no")
                {
                    Console.WriteLine("wrong input. Please try again.");
                    answer = Console.ReadLine();
                }
                if (answer == "no")
                {
                    return;
                }



                Console.WriteLine("Please enter the amount you want to donate");
                string amountAsString = Console.ReadLine();




                int amount;
                while (true)
                {
                    try
                    {
                        amount = Int32.Parse(amountAsString);
                    }
                    catch (Exception)
                    {
                        amount = -1;
                        Console.WriteLine("Wrong input. Please try again.");
                        amountAsString = Console.ReadLine();
                    }

                    if (amount>0)
                    {
                        break;
                    }
                }







                string _MerchantEmail = "porfanid@gmail.com";
                string _ReturnURL = "https://www.yourwebsite.com/paymentsuccess";
                string _CancelURL = "https://www.yourwebsite.com/paymentfailed";
                string _CurrencyCode = "EUR";
                int _Amount = amount;
                string _ItemName = "item1"; //We are using this field to pass the order number
                int _Discount = 0;
                double _Tax = 0;
                string _PayPalURL = $"https://www.paypal.com/cgi-bin/webscr?cmd=_xclick&business={_MerchantEmail}&return={_ReturnURL}&cancel_return={_CancelURL}&currency_code={_CurrencyCode}&amount={_Amount}&item_name={_ItemName}&discount_amount={_Discount}&tax={_Tax}";

                System.Diagnostics.Process.Start(_PayPalURL);
            }
        }




        private static void game()
        {
            BattleShip newGame = new BattleShip();
            newGame.StartGame();
        }



        private static void exitIfNotPro()
        {
            if (GetRegistryInfo() == false)
            {
                Console.Write("Press any key to continue...");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }


        private static void playMusic()
        {
            MusicPlayer test = new MusicPlayer();
            test.GetMp3();
        }




        public static void Main(string[] args)
        {
            Thread startMusic =new Thread(playMusic);
            startMusic.Start();
            //This creates the animation at the beginning of the programm.
            //****************************************************************************
            StartUpAnimation sa = new StartUpAnimation();
            sa.createStartUpAnimation();
            //****************************************************************************
            donate();
            checkIfUserWantsPro();
            game();
            exitIfNotPro();
            orderOnline();
            contactDeveloper();
            Console.Write("Press any key to continue...");
            Console.ReadKey();
        }
    }
}