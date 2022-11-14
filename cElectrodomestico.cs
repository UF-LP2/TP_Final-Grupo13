using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tp_final
{
    internal class cElectrodomestico
    {
        protected int id_elec;
        static int contador = 0;
        protected int altura, ancho, largo;
        protected int volumen, peso;
        public int Volumen
        {
            get { return volumen; }
        }
        public int Peso
        {
            get { return peso; }
        }
        protected bool apilable;
    
        public cElectrodomestico(int _altura, int _largo, int _ancho, int _peso, bool _apilable)
        {
            this.volumen = _largo * _ancho * _altura;
            this.peso = _peso;
            this.apilable = _apilable;
            this.id_elec = contador;
            contador++;
        }

        ~cElectrodomestico() { }
    }
}
