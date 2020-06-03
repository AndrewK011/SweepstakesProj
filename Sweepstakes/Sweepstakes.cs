using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            contestants = new Dictionary<int, Contestant>();
            for (int i = 0; i < 3; i++)
            {
                RegisterContestant(CreateContestant(i));
            }
            PickWinner();
            NotifyContestants();
        }

        public void RegisterContestant(Contestant contestant)
        {
            if (contestants.ContainsKey(contestant.RegistrationNumber))
            {
                UserInterface.Print("User already registered");
            }
            else
            {
                contestants.Add(contestant.RegistrationNumber, contestant);
            }
        }

        public Contestant PickWinner()
        {
            Random rnd = new Random();
            Contestant winner = contestants.ElementAt(rnd.Next(0, contestants.Count)).Value;
            winner.isWinner = true;
            PrintContestantInfo(winner);
            NotifyContestants();

            return winner;
        }

        public void NotifyContestants()
        {
            List<Contestant> contestantKeys = new List<Contestant>(contestants.Values);
            foreach(Contestant contestant in contestantKeys)
            {
                if(contestant.isWinner)
                {
                    UserInterface.Print("Congratulations! You won!");
                }
                else
                {
                    UserInterface.Print("Sorry, you are not the winner.");
                }
            }
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            UserInterface.DisplayWinner(contestant);
        }

        public Contestant CreateContestant(int regNumber)
        {
            Contestant contestant = new Contestant();
            contestant.SetRegistrationNumber(regNumber);
            return contestant;
        }
    }
}
