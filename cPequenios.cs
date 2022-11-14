using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cPequenios : cElectrodomestico
    {
        public cPequenios(int _altura, int _largo, int _ancho, int _peso) : base (_altura, _largo, _ancho, _peso, true) { }
        ~cPequenios() { }
    }
}
