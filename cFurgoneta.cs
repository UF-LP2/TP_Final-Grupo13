using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cFurgoneta:cVehiculo
    {
        public cFurgoneta() : base(3500000, (float) 3, (float)1.5, (float)2, (float)9.0, false, (float)6.9) { }
        ~cFurgoneta() { }
    }
}
