using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGetStarted
{
    internal class UserInput
    {
        public static string GetInput(string message)
        {
            Console.WriteLine(message);
            string userInput = Console.ReadLine() ?? "";

            return userInput;
        }
    }
}
