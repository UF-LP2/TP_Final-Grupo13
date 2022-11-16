using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
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
            int i, j;
            pedidosH.Clear();
            for (i=0; i < pedidosE.Count(); i++){
                pedidosH.Add(pedidosE[i]);
            }

            pedidosE.Clear();
            for (i=0; i < pedidosN.Count(); i++){
                pedidosE.Add(pedidosN[i]);
            }

            pedidosN.Clear();
            for (i=0; i < pedidosD.Count(); i++){
                pedidosN.Add(pedidosD[i]);
            }

            for (j = 0; j < _vehiculos.Count(); j++)
            {
                vehiculos.Add(_vehiculos[i]);
            }

            //Empiezo el llenado de vehiculos y el despachado 
            RepartoPedidosHoy();
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
        public void RepartoPedidosHoy() {
            List<cPedido> especiales = new List<cPedido>(); //para poder ordenar bien la lista MAY -> MEN, pero con la LB y las teles adelante
            int i, cont_especiales = 0;
            for (i = 0; i < pedidosH.Count(); i++) {//separamos la linea blanca y a los televisores

                if (pedidosH[i].ProductoEspecial()) {
                    especiales.Add(pedidosH[i]);
                    pedidosH.RemoveAt(i);
                    cont_especiales++;
                }
            }

            pedidosH.Sort((a, b) => a.Peso_tot.CompareTo(b.Peso_tot));//ordena la lista de pedidos hoy por peso

            for (i = 0; i < cont_especiales + 1; i++)
                pedidosH.Add(especiales[i]);          //agrego los especiales al final
            
            pedidosH.Reverse(); //doy vuelta la lista para que queden especiales y despues de mayor peso a menor

            while (viajes != 0 && pedidosH.Count() != 0)
            {
                if (viajes == 6)
                { //viaje del furgon
                    cont_especiales = CargaVehiculo(vehiculos[0], cont_especiales);
                    Recorrido(vehiculos[0]);
                }

                if (viajes == 5)
                {
                    cont_especiales = CargaVehiculo(vehiculos[1], cont_especiales);
                    Recorrido(vehiculos[1]);
                }
                if (viajes < 5)
                {
                    cont_especiales = CargaVehiculo(vehiculos[2], cont_especiales);
                    Recorrido(vehiculos[2]);
                }
                viajes--;
            }

            // SE TERMINAN LOS VIAJES POR HOY -> SE SUPONE QUE NO HAY MAS PEDIDOS QUE LOS QUE SE PUEDEN ENTREGAR EN UN DIA
            // HAY QUE HACERLE UN CIERRE

        }

        public int CargaVehiculo(cVehiculo vehiculo, int cont_espe)
        {
            for(int y = 0; y < pedidosH.Count; y++)
            {
                pedidosH[y].SettearTele(vehiculo);  //a las televiciones le ponemos la altura del vehiculo
            }
            int l;
            List<int> vol = new List<int>();
            List<int> peso = new List<int>();
            int acumPeso = 0;
            for (l = 0; l < pedidosH.Count(); l++)
            {
                vol.Add((int)pedidosH[l].Vol_tot); 
                peso.Add(pedidosH[l].Peso_tot);
            }
           
            List<int> val = new List<int>();  //val o beneficio son 1 - 2 - 5
            for (l = 0; l < pedidosH.Count(); l++)
            {
                if (l < cont_espe)
                    val.Add(5);     //le pongo prioridad 5 a todo los de lineablanca o televisores
                else
                    val.Add(1);  
            }

            int elementos = pedidosH.Count();
            int espacio = (int)vehiculo.Volumen; 
            int peso_permitido = vehiculo.Peso;
            int i, j;
            int[,] CAP = new int[elementos, espacio + 1]; //filas = elementos , columnas = volumen

            for (i = 0; i < elementos; i++) //i representa los elementos
            {

                for (j = 0; j < espacio; j++) //j representa las instancias de volumenes
                {
                    int volElem_i = vol[i];
                    int gananciaElem_i = val[i];
                    if (i == 0)                                
                    {
                        if (j < volElem_i)
                        {
                            CAP[i, j] = 0;
                        }
                        else
                        {
                            CAP[i, j] = gananciaElem_i;
                        }
                    }
                    else
                    {
                        int anterior = CAP[i - 1, j];
                        int mejor = 0;
                        if (j - volElem_i >= 0)
                        {
                            mejor = CAP[i - 1, j - volElem_i] + gananciaElem_i;
                        }
                        if (anterior <= mejor && acumPeso + peso[i] <= peso_permitido) // me fijo que sea mejor el nuevo y que este bajo el peso permitido
                        {
                            CAP[i, j] = mejor;
                            acumPeso += peso[i];
                        }
                        else
                        {
                            CAP[i, j] = anterior;
                        }
                    }
                }
            }

            //en una lista booleana infora si lleva o no el elemento, true = lleva / false = nolleva
            List<bool> entrantes = new List<bool>();
            i = elementos - 1;
            j = espacio;
            //recorre la matriz de forma inversa, dch-abajo -> izq-arriba 
            while (true)
            {
                int mejor = 0;
                if (i == 0)  //cuando llega a la ultima pos o ultimo elemento
                {
                    if (CAP[i,j] != 0)
                        entrantes.Add(true);
                    break;
                }
          
                if (j - vol[i] >= 0)
                {
                    mejor = CAP[i - 1, j - vol[i]] + val[i];
                }

                int anterior = CAP[i - 1, j];
                if (mejor > anterior) //no toma el =
                {
                    j = j - vol[i];
                    entrantes.Add(true);
                }
                else
                {
                    entrantes.Add(false);
                }
                i = i - 1;
                
                if (j < 0)
                    break;
            }
            entrantes.Reverse(); //invierto la lista porq me queda al reves cuando se llena

            int k;
            for (k = 0; k < pedidosH.Count(); k++)
            {
                if (entrantes[k] == true) //si en la lista booleana marca que lo llevo se lo agrego al camion y se lo saco a pedidos
                {
                    vehiculo.Repartos.Add(pedidosH[k]);
                    if (pedidosH[k].ProductoEspecial() == true)
                        cont_espe--;
                    pedidosH.RemoveAt(k);
                }
            }
       
            return cont_espe; 
        }
        public Dictionary<int, double> Adyacentes(double[,] matrixCostos, int _nodo)
        {
            Dictionary<int, double> r = new Dictionary<int, double>();
            for (int i = 0; i < 24; i++)
            {
                if (i != _nodo && matrixCostos[i, _nodo] > 0)
                    r.Add(i, matrixCostos[i, _nodo]);
            }
            return r;
        }
        public Stack<int> ConvertirDaQ(Dictionary<int, int> dic, int _inicio, int _fin, double[,] matrixCostos)
        {
            Stack<int> r = new Stack<int>();
            
            r.Push(_fin);
            while (dic[r.Peek()] != -1)
            {
                r.Push(dic[r.Peek()]);
            }
            return r;
        }
        public Stack<int> CaminoMinimo(double[,] matrixCostos, int _inicio, int _fin)
        {
            int n = 24; //ver si se puede hacer gobal
            var distancias = new Dictionary<int, double>();
            var padre = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                distancias[i] = 2147483647;
            }
            distancias[_inicio] = 0;
            padre[_inicio] = -1;
            Queue<int> cola_de_ejecución = new Queue<int>();
            cola_de_ejecución.Enqueue(_inicio);
            while (cola_de_ejecución.Count != 0)
            {
                int v = cola_de_ejecución.Dequeue();
                if (v == _fin)
                    return ConvertirDaQ(padre, _inicio, _fin, matrixCostos);
                foreach (KeyValuePair<int, double> ady in Adyacentes(matrixCostos, v))//cada adyacente del nodo v
                {
                    if (distancias[v] + ady.Value < distancias[ady.Key])
                    {
                        distancias[ady.Key] = distancias[v] + ady.Value;
                        padre[ady.Key] = v;
                    }
                    cola_de_ejecución.Enqueue(ady.Key);
                }

            }
            return ConvertirDaQ(padre, _inicio, _fin, matrixCostos);
        }
        public void Recorrido(cVehiculo _v)
        {
            _v.repartos.Sort((a, b) => a.Peso_tot.CompareTo(b.Peso_tot));//los repartos se cargan al camion en orden creciente de peso
            int anterior = 1;

            for (int i = 0; i < _v.repartos.Count(); i++)
            {
                Stack<int> c = new Stack<int>();
                c = CaminoMinimo(matrixNodos ,anterior, _v.repartos[i]);
                while(c.Count()>0) {
                    _v.recorrido.Push(c.Pop());
                }
             
            }
            _v.recorrido.Push(1);


        }

    }
}
