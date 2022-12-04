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
        protected bool aparato;
        public bool Aparato
        {
            get { return aparato; }
            set { }
        }
        protected bool ahorro;
        protected int localidad;
        public int Localidad
        {
            get { return localidad; }
        }
        static int contador = 123;
        protected Stack<cPedido> repartos;
        protected Stack<int> recorrido;
        public Stack<cPedido> Repartos
        {
            get { return repartos; }
        }
        public Stack<int> Recorrido
        {
            get { return recorrido; }
        }
        public cVehiculo(int _peso, float _largo,float _ancho, float _alto, float _nafta, bool _ahorro, float _consumo)
        {
            this.peso = _peso;
            this.volumen = _largo * _ancho * _alto;
            this.nafta = _nafta;
            this.consumo = _consumo;
            this.repartos = new Stack<cPedido>();
            this.ahorro = _ahorro;
            this.aparato = false;
            this.patente = contador;
            this.recorrido= new Stack<int>();
            contador++;
            int filas = (int)_largo * 100;
            int columnas = (int)_ancho * 100;
        }
       

        ~cVehiculo() { 
            repartos.Clear();
        }

        public void OrdenarPila()
        {
            List<cPedido> lista = new List<cPedido>();
            for (int i = 0; i < repartos.Count(); i++)
            {
                lista.Add(repartos.Pop());
            }

            lista.Sort((a, b) => a.Peso_tot.CompareTo(b.Peso_tot));
            for(int j = 0; j < lista.Count(); j++)
            {
                repartos.Push(lista[j]);
            }
        }
    }
}
