using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cFurgoneta:cVehiculo
    {
        public cFurgoneta(int _peso, float _volumen, float _consumo) : base(3500, (float)17, (float)6.9) { }
        ~cFurgoneta() { }
    }
}
