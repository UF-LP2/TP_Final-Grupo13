using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cTelevisor:cElectrodomestico
    {
        public cTelevisor(int _altura, int _largo, int _ancho, int _peso, bool _aplicable) : base(_altura, _largo, _ancho, _peso, false) { }
        ~cTelevisor() { }
    }
}
