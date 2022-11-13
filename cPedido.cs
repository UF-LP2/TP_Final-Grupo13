using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.dll;

namespace tp_final
{
    enum eTipo
    {
        express,
        normal,
        diferido
    }
    internal class cPedido
    {
        protected List<cElectrodomestico> listaE = new List<cElectrodomestico>();
        protected eTipo tipo;
        protected int id_pedido;
        static int contador = 0;
        protected var fecha = new Datetime(2000, 4, 5, 0, 0, 0);

        public cPedido (List<cElectrodomestico> _listaE, eTipo _tipo)
        {
            this.listaE = _listaE;
            this.tipo = _tipo;
            this.id_pedido = contador;
            contador++;
        }
        ~cPedido() {
            listaE.Clear();
        }
    }
}
