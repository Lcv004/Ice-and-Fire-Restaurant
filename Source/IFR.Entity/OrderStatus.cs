using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFR.Entity
{
    public struct OrderStatus
    {
        public const int PENDING = 0;
        public const int PROCESSING = 1;
        public const int DONE = 2;
        public const int CANCELED = 3;
    }
}
