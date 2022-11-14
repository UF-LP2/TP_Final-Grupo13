using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cCosiMundo
    {
        List<cPedido> pedidos = new List<cPedido>();
        List<cVehiculo> vehiculos = new List<cVehiculo>();

        public cCosiMundo(List<cPedido> _pedidos, List<cVehiculo> _vehiculos)
        {
            this.pedidos = _pedidos;
            this.vehiculos = _vehiculos;
        }

        public void Inicio_Programa()
        {

        }

        public List<cPedido> ListaDeHoy(List<cPedido> pedidos)
        {
            List<cPedido> aux = new List<cPedido>();
            for(int i = 0; i < pedidos.Count(); i++)
            {
                if (pedidos[i].Tipo == eTipo.express)
                    aux.Add(pedidos[i]);
            }
            return aux;
        }

    }
}
