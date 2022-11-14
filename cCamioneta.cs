using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cCamioneta:cVehiculo
    {
        public cCamioneta(List<cElectrodomestico> _lista) : base(160000, (float)4.97, (float)7.5, _lista, false, (float)7.2) { }
        ~cCamioneta() { }
    }
}
