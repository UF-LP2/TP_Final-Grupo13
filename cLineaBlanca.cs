using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cLineaBlanca:cElectrodomestico
    {
        public cLineaBlanca(int _altura, int _largo, int _ancho, int _peso) : base(_altura, _largo, _ancho, _peso, true) { }
        ~cLineaBlanca() { }
    }
}
