using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cTelevisor:cElectrodomestico
    {
        public cTelevisor(int _largo, int _ancho, int _peso) : base(110, _largo, _ancho, _peso, false) { }
        ~cTelevisor() { }
    }
}
