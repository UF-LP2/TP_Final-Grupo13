using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cCamioneta:cVehiculo
    {
        public cCamioneta() : base(160000, (float)1.2, (float)1.5, (float)3.1, (float)7.5, false, (float)7.2) { }
        ~cCamioneta() { }
    }
}
