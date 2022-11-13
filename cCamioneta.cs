using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cCamioneta:cVehiculo
    {
        public cCamioneta(int _peso, float _volumen, float _consumo) : base(2500, (float)3.97, (float)7.6) { }
        ~cCamioneta() { }
    }
}
