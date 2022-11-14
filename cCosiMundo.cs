using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cCosiMundo
    {
        List<cPedido> pedidosE;
        List<cPedido> pedidosN;
        List<cPedido> pedidosD;
         List<cPedido> pedidosH;
        List<cVehiculo> vehiculos;
        float[,] matrixNodos = float[24,24];

        public cCosiMundo()
        {
            this.pedidosE = new List<cPedido>();
            this.pedidosN= new List<cPedido>();
            this.pedidosD= new List<cPedido>();
            this.pedidosH= new List<cPedido>();
            this.vehiculos = new List<cVehiculo>();
        }
        ~cCosiMundo(){
            pedidosD.Clear();
            pedidosN.Clear();
            pedidosE.Clear();
            vehiculos.Clear();
        }

        public void Inicio_Programa()//el programa se corre 1vez x dia -> al comienzo de cada dia todos los pedidos se mueven 1 posicion
        {
            for(int i=0; i<pedidosE.Count();i++){
                pedidosH.Clear();
                pedidosH[i]=pedidosE[i];
            }
            for(int i=0; i<pedidosN.Count();i++){
                pedidosE.Clear();
                pedidosE[i]=pedidosN[i];
            }
            for(int i=0; i<pedidosD.Count();i++){
                pedidosN.Clear();
                pedidosN[i]=pedidosD[i];
            }
        }
        public void OrdenarPedidos (List<cPedido> _pedidos){
            for(int i=0; i < _pedidos.Count();i++){
                switch (_pedidos[i].Tipo){
                    case 1:
                        pedidosE.Add(_pedidos[i]);
                        break;
                    case 2:
                        pedidosN.Add(_pedidos[i]);
                        break;
                    case 3:
                        pedidosD.Add(_pedidos[i]);
                        break;
                    default:
                        pedidosD.Add(_pedidos[i]);
                        break;
                }
            }
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
