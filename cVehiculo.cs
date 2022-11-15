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
        protected float largo, ancho, alto, nafta, consumo, volumen;
        public float Volumen
        {
            get { return volumen; }
        }
        protected bool aparato, ahorro;
        static int contador = 123;
        protected List<cPedido> repartos;
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
