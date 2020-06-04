using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

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
            PrintContestantInfo(PickWinner());
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
            return winner;
        }

        public void NotifyContestants()
        {
            List<Contestant> contestantKeys = new List<Contestant>(contestants.Values);
            foreach(Contestant contestant in contestantKeys)
            {
                if(contestant.isWinner)
                {
                    UserInterface.Print($"Congratulations {contestant.FirstName}! You won!");
                    //EmailWinner(contestant);
                }
                else
                {
                    UserInterface.Print($"Sorry {contestant.FirstName}, you are not the winner.");
                }
            }
        }

        public void PrintContestantInfo(Contestant contestant)
        {
            UserInterface.DisplayContestantInfo(contestant);
        }

        public Contestant CreateContestant(int regNumber)
        {
            Contestant contestant = new Contestant();
            contestant.SetRegistrationNumber(regNumber);
            return contestant;
        }

        public void EmailWinner(Contestant contestant)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Sweepstakes Company", "Sweepstakes@company.com"));
            message.To.Add(new MailboxAddress(contestant.FirstName + " " + contestant.LastName, contestant.EmailAddress));
            message.Subject = (name);

            message.Body = new TextPart("plain")
            {
                Text = $"Congratulations! You have won our {name} sweepstakes!\nPlease reply to this email for more information!"

                    
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.domain.com", 25, false);

                // Note: only needed if the SMTP server requires authentication
                //client.Authenticate("username", "password");

                client.Send(message);
                client.Disconnect(true);
            }
        }
    }
}
