using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class MarketingFirm
    {
        public interface ISweepstakesManager
        {
            void InsertSweepstakes(Contestant contestant);

            Sweepstakes GetSweepstakes();
        }
            

    }
}
