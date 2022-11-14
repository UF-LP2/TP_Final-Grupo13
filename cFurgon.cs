using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cFurgon:cVehiculo
    {
        public cFurgon(): base(490000, 4, (float)1.5, (float)1.7, (float)30.5, true, (float)14.84) { }
        ~cFurgon() { }
    }
}
