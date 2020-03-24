using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignalRDemo.Service
{
    public class CountService
    {
        private int count;
        public int GetLatestCount()
        {
            return count++;
        }
    }
}
