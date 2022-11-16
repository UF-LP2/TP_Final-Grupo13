using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cVehiculo
    {
        protected int peso, patente;
        public int Peso
        {
            get { return peso; }
        }
        protected float largo, ancho, alto, nafta, consumo, volumen;

        public float Alto
        {
            get { return alto; }
        }
        public float Volumen
        {
            get { return volumen; }
        }
        public bool aparato;
        protected bool ahorro;
        public int localidad;
        static int contador = 123;
        public List<cPedido> repartos;
        public Stack<int> recorrido;
        public List<cPedido> Repartos
        {
            get { return repartos; }
        }
        protected float [,] espacio;

        public cVehiculo(int _peso, float _largo,float _ancho, float _alto, float _nafta, bool _ahorro, float _consumo)
        {
            this.peso = _peso;
            this.volumen = _largo*_ancho*_alto;
            this.nafta = _nafta;
            this.consumo = _consumo;
            this.repartos = new List<cPedido>();
            this.ahorro = _ahorro;
            this.aparato = false;
            this.patente = contador;
            this.recorrido= new Stack<int>();
            contador++;
            int filas = (int)_largo * 100;
            int columnas = (int)_ancho * 100;
            this.espacio = new float [filas, columnas];
            for(int i = 0; i < filas; i++){
                for(int j = 0; j < columnas; j++){
                    espacio[i,j] = _alto;
                }
            }
        }
       

        ~cVehiculo() { 
            repartos.Clear();
        }

    }
}
