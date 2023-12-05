using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsTopScores
{
    internal class UserInput
    {
        public static String GetInput(string message)
        {
            Console.WriteLine(message);
            String userInput = Console.ReadLine() ?? "";

            return userInput;
        }
    }
}
