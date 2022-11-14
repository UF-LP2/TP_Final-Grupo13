using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.dll;
using System.DirectoryServices;

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
        protected var fecha;

        public cPedido (List<cElectrodomestico> _listaE, eTipo _tipo, int _mes, int _dia)
        {
            this.listaE = _listaE;
            this.tipo = _tipo;
            this.id_pedido = contador;
            this.fecha = new Datetime(2000, _mes, _dia, 0, 0, 0);
            contador++;
        }
        ~cPedido() {
            listaE.Clear();
        }
    }
}
