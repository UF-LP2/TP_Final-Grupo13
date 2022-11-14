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
        protected var fecha;

        public cPedido(List<cElectrodomestico> _listaE, eTipo _tipo, int _dia, int _mes, int _hora)
        {
            this.listaE = _listaE;
            this.tipo = _tipo;
            this.id_pedido = contador;
            fecha = new DateTime(2022, _mes, _dia, _hora,0,0);

            contador++;
        }
        ~cPedido() {
            listaE.Clear();
        }
    }
}
