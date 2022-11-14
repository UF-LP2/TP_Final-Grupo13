using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cFurgon:cVehiculo
    {
        public cFurgon(): base(490000, (float)10.8, (float)30.5, true, (float)14.84) { }
        ~cFurgon() { }
    }
}
