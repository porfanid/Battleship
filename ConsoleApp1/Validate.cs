using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PartialKeyVerification.Checksum;
using PartialKeyVerification.Hash;
namespace ConsoleApp1
{
    class Validate
    {
        string[] Blacklist = {"QDKZUO-JLLWPY-XWOULC-ONCQIN-5R5X35-ZS3KEQ" };
        private static void ModifyRegistryInfo()
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("Battleship_Evaluation");
            key.SetValue("Evaluation", "True");
            key.Close();
        }





        public void onlineActivation()
        {

        }




        public void testLicense()
        {
            Console.WriteLine("Enter the license number:");
            string key = Console.ReadLine();
            var isValid = PartialKeyValidator.ValidateKey(new Adler16(), new Jenkins96(), key, 0, 1);
            while (true)
            {
                bool existance=false;
                foreach(string s in Blacklist)
                {
                    if (key==s)
                    {
                        existance = true;
                    }
                }
                if (isValid && !existance)
                {
                    ModifyRegistryInfo();
                    Console.WriteLine("You have successfully upgraded to pro!!!");
                    try
                    {
                        System.Threading.Thread.Sleep(1500);
                    }
                    catch(Exception)
                    { }
                    break;
                }
                else
                {
                    Console.WriteLine("This key is invalid. Do you want to try again?(yes/no)");
                    string answer = Console.ReadLine();
                    while (answer!="yes" && answer!="no")
                    {
                        Console.WriteLine("wrong input please try again");
                        answer = Console.ReadLine();
                    }
                    if (answer == "no")
                    {
                        return;
                    }
                    Console.WriteLine("Enter the license number:");
                    key = Console.ReadLine();
                    isValid = PartialKeyValidator.ValidateKey(new Adler16(), new Jenkins96(), key, 0, 1);
                }
            }
        }
    }
}