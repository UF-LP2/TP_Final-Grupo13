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
        int viajes;
        public cCosiMundo()
        {
            this.pedidosE = new List<cPedido>();
            this.pedidosN = new List<cPedido>();
            this.pedidosD = new List<cPedido>();
            this.pedidosH = new List<cPedido>();
            this.vehiculos = new List<cVehiculo>();
            this.viajes = 6;

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
        public void CargaVehiculos() {
            List<cPedido> especiales = new List<cPedido>();
            
            for (int i = 0; i < pedidosH.Count(); i++) {//separamos la linea blanca
                if (pedidosH[i].ProductoEspecial()) {
                    especiales.Add(pedidosH[i]);
                    pedidosH.RemoveAt(i);
                }
            }
            pedidosH.Sort((a, b) => a.Peso_tot.CompareTo(b.Peso_tot));//ordena la lista de pedidos hoy por peso

            while (viajes != 0 && pedidosH.Count() != 0)
            {
                if(viajes == 6) //viaje del furgon
                {

                }
            }

        }

        public List<cPedido> CargaVehiculo(List<cPedido> especiales, cVehiculo vehiculo)
        {
            List<int> vol = new List<int>();
            //lleno la lista de volumen con los elementos de especiales
            List<int> val = new List<int>();
            //lleno la lista de valores/beneficios con los valores que creo de los elem de los especiales

            int elementos = especiales.Count();
            int espacio = (int)vehiculo.Volumen;
            int i, j;
            int[,] CAP = new int[elementos, espacio + 1]; //filas = elementos , columnas = volumen

            for (i = 0; i < elementos; i++) //i representa los elementos
            {

                for (j = 0; j < espacio; j++)
                {
                    int volElem_i = vol[i];
                    int gananciaElem_i = val[i];
                    /*
                     BMAX[1,j] = val[i] si j >= volElem_i
                               = 0 en cualquier otro caso

                     BMAX[i,j] = Max(BMAX[ i-1, j ], 
                                     BMAX[ i-1, j-vol[i] ] + val[i])
                     */
                    if (i == 0)
                    {
                        if (j < vol[i])
                        {
                            CAP[i, j] = 0;
                        }
                        else
                        {
                            CAP[i, j] = val[i];
                        }
                    }
                    else
                    {
                        //int MAX = 0;
                        int anterior = CAP[i - 1, j];
                        int mejor = 0;
                        if (j - vol[i] >= 0)
                        {
                            mejor = CAP[i - 1, j - vol[i]] + val[i];
                        }
                        if (anterior > mejor)
                        {
                            CAP[i, j] = anterior;
                        }
                        else
                        {
                            CAP[i, j] = mejor;
                        }
                    }
                }
            }

            List<bool> entrantes = new List<bool>();
            i = elementos - 1;
            j = espacio;

            while (true)
            {
                int mejor = 0;
                if (j - vol[i] >= 0)
                {
                    mejor = CAP[i - 1, j - vol[i]] + val[i];
                }

                int anterior = CAP[i - 1, j];
                if (mejor > anterior)
                {
                    j = j - vol[i];
                    entrantes[i] = true;
                }
                else
                {
                    entrantes[i] = false;
                }
                i = i - 1;

                if (j < 0)
                    break;
            }

            return especiales;
        }


    }
}
