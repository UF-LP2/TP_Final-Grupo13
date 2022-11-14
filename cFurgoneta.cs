using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cFurgoneta:cVehiculo
    {
        public cFurgoneta(List<cElectrodomestico> _lista) : base(350000, (float)8.7, (float)9.0, _lista, false, (float)6.9) { }
        ~cFurgoneta() { }
    }
}
