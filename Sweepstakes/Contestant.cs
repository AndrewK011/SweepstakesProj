using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Contestant
    {
        public string FirstName;
        public string LastName;
        public string EmailAddress;
        public int RegistrationNumber;

        public Contestant()
        {
            FirstName = UserInterface.GetUserInputFor("first name");
            LastName = UserInterface.GetUserInputFor("last name");
            EmailAddress = UserInterface.GetUserInputFor("email address");

        }
    }
}
