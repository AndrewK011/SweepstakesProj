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
