﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sweepstakes
{
    class SweepstakesQueueManager : ISweepstakesManager
    {
        private Queue<Sweepstakes> queue;

        public void InsertSweepstakes(Sweepstakes sweepstakes)
        {

        }

        public Sweepstakes GetSweepstakes()
        {
            Sweepstakes sweepstakes = new Sweepstakes("freeCar");

            return sweepstakes;
        }
    }
}
