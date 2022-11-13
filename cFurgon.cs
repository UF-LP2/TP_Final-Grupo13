using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cFurgon:cVehiculo
    {
        public cFurgon(int _peso, float _volumen, float _consumo): base(7000, (float)10.8, (float)14.84) { }
        ~cFurgon() { }
    }
}
