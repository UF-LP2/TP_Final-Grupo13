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
        protected float volumen, nafta, consumo;
        protected bool aparato, ahorro;
        static int contador = 123;
        protected List<cElectrodomestico> listaP;

        public cVehiculo(int _peso, float _volumen, float _nafta, bool _ahorro, float _consumo)
        {
            this.peso = _peso;
            this.volumen = _volumen;
            this.nafta = _nafta;
            this.consumo = _consumo;
            this.listaP = new List<cElectrodomestico>();
            this.ahorro = _ahorro;
            this.aparato = false;
            this.patente = contador;
            contador++;
        }

        ~cVehiculo() { 
            listaP.Clear();
        }

    }
}
