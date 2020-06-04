using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class MarketingFirm
    {
        private ISweepstakesManager _manager;

        //Dependency injection in MarketingFirm constructor allows the constructor to take in any manager
        //that is compatible with the ISweepstakesManager interface, increasing flexibility and reusibility
        public MarketingFirm(ISweepstakesManager manager)
        {
            _manager = manager;
        }

        public void CreateSweepStakes(string sweepstakesName)
        {
            Sweepstakes newSweep = new Sweepstakes(sweepstakesName);
            _manager.InsertSweepstakes(newSweep);
        }
    }
}
