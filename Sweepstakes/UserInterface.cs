using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    static class UserInterface
    {
        public static string GetUserInputFor(string prompt)
        {
            Console.WriteLine($"Please enter {prompt}:");
            string userInput = Console.ReadLine();

            return userInput;
        }

        public static void Print(string printedString)
        {
            Console.WriteLine(printedString);
        }

        public static void DisplayContestantInfo(Contestant contestant)
        {
            Console.WriteLine($"{contestant.FirstName}\n{contestant.LastName}\n{contestant.EmailAddress}\n{contestant.RegistrationNumber}");

        }


    }
}
