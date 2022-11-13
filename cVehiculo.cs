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
        protected float volumen, consumo;
        protected bool aparato;
        static int contador = 123;
        protected List<cElectrodomestico> listaP = new List<cElectrodomestico>();

        public cVehiculo(int _peso, float _volumen, float _consumo)
        {
            this.peso = _peso;
            this.volumen = _volumen;
            this.consumo = _consumo;
            this.aparato = false;
            this.patente = contador;
            contador++;
        }

        ~cVehiculo() { 
            listaP.Clear();
        }

    }
}
