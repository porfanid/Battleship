using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SlowPrint
    {
        public void Print(String message)
        {
            // Get message, convert to char array
            char[] chars = message.ToCharArray();

            // Print a char from the array, then sleep for 1/10 second
            for (int i = 0; i < chars.Length; i++)
            {
                Console.Write(chars[i]);
                System.Threading.Thread.Sleep(100);
            }
            Console.Write("\n");
            // Repeat for all chars
        }
    }
}
