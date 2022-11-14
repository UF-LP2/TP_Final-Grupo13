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
        double[,] matrixNodos;

        public cCosiMundo()
        {
            this.pedidosE = new List<cPedido>();
            this.pedidosN = new List<cPedido>();
            this.pedidosD = new List<cPedido>();
            this.pedidosH = new List<cPedido>();
            this.vehiculos = new List<cVehiculo>();

            this.matrixNodos = new double[24, 24];
            String line;
            StreamReader sr = new StreamReader("C:\\Users\\lolyy\\OneDrive\\Documentos\\LP2\\nodos.txt");
            
            line = sr.ReadLine();//lee la 1er linea del archivo
           
            while (line != null && line.Length > 0)//leer hasta ENDOF
            { 
                String[] linea = line.Split(',');//substring hasta las comas
                matrixNodos[Convert.ToInt32(linea[0]) - 1, Convert.ToInt32(linea[1]) - 1] = Convert.ToDouble(linea[2]);
                matrixNodos[Convert.ToInt32(linea[1]) - 1, Convert.ToInt32(linea[0]) - 1] = Convert.ToDouble(linea[2]);
               
                line = sr.ReadLine();
            }
            
            sr.Close();
            /*imprimir matriz
            int rowLength = matrixNodos.GetLength(0);
            int colLength = matrixNodos.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0} ", matrixNodos[i, j]));
                }
                Console.Write(Environment.NewLine + Environment.NewLine);
            }*/

        }

    
        
        ~cCosiMundo(){
            pedidosD.Clear();
            pedidosN.Clear();
            pedidosE.Clear();
            vehiculos.Clear();
        }

        public void Inicio_Programa(List<cPedido> _pedidos, List<cVehiculo> _vehiculos)//el programa se corre 1vez x dia -> al comienzo de cada dia todos los pedidos se mueven 1 posicion
        {
            this.OrdenarPedidos(_pedidos);

            for(int i=0; i < pedidosE.Count(); i++){
                pedidosH.Clear();
                pedidosH[i] = pedidosE[i];
            }
            for(int i=0; i < pedidosN.Count(); i++){
                pedidosE.Clear();
                pedidosE[i] = pedidosN[i];
            }
            for(int i=0; i < pedidosD.Count(); i++){
                pedidosN.Clear();
                pedidosN[i] = pedidosD[i];
            }


        }
        public void OrdenarPedidos (List<cPedido> _pedidos){
            for(int i=0; i < _pedidos.Count(); i++){
                switch ((uint)_pedidos[i].Tipo){
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


    }
}
