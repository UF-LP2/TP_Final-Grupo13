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
        protected bool aparato, ahorro;
        static int contador = 123;
        protected List<cElectrodomestico> listaP;
        protected float [,] espacio;

        public cVehiculo(int _peso, float _largo,float _ancho, float _alto, float _nafta, bool _ahorro, float _consumo)
        {
            this.peso = _peso;
            this.volumen = _largo*_ancho*_alto;
            this.nafta = _nafta;
            this.consumo = _consumo;
            this.listaP = new List<cElectrodomestico>();
            this.ahorro = _ahorro;
            this.aparato = false;
            this.patente = contador;
            contador++;
            int filas = (int)_largo * 100;
            int columnas = (int)_ancho * 100;
            this.espacio= new float [filas, columnas];
            for(int i=0; i<_largo; i++){
                for(int j=0; j<_ancho;j++){
                    espacio[i,j]= _alto;
                }
            }
        }

        ~cVehiculo() { 
            listaP.Clear();
        }

    }
}
