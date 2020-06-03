using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class Simulation
    {
            ISweepstakesManager manager;
        public bool isDone = false;
        public void CreateMarketingFirmWithManager()
        {
            while (isDone)
            {
                switch (UserInterface.GetUserInputFor("sweepstakes manager type:\n 1) Queue manager\n 2) Stack manager\n 3) Exit"))
                {
                    case "1":
                        manager = new SweepstakesQueueManager();
                        break;
                    case "2":
                        manager = new SweepstakesStackManager();
                        break;
                    case "3":
                        isDone = true;
                        break;
                    default:
                        break;
                }

                MarketingFirm marketingFirm = new MarketingFirm(manager);
                marketingFirm.CreateSweepStakes(UserInterface.GetUserInputFor("sweepstakes name"));
            }
            
        }
    }
}
