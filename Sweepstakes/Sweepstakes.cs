using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Sweepstakes
    {
        private Dictionary<int, Contestant> contestants;
        
        private string name;
        public string Name { get { return name; } set { name = value; } }

        public Sweepstakes(string name)
        {
            Name = name;
        }

        public void RegisterContestant(Contestant contestant)
        {
            contestants.Add(contestant.RegistrationNumber, contestant);      
        }

        public Contestant PickWinner()
        {
            
            Contestant winner = new Contestant();

            return winner;
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            UserInterface.Print(contestant.FirstName);
        }
    }
}
