using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Runtime.dll;
using System.DirectoryServices;

namespace tp_final
{
    enum eTipo
    {
        express,
        normal,
        diferido
    }
    internal class cPedido
    {
        protected List<cElectrodomestico> listaE = new List<cElectrodomestico>();
        protected eTipo tipo;
        protected int peso_tot, ubicacion;
        protected float volumen_tot;
        public float Vol_tot
        {
            get { return volumen_tot; }
        }

        public int Ubicacion
        {
            get { return ubicacion; }
        }
        public int Peso_tot
        {
            get { return peso_tot; }
        }
        public eTipo Tipo
        {
            get { return tipo; }
        }
        protected int id_pedido;
        static int contador = 0;
       // protected var fecha;

        public cPedido (List<cElectrodomestico> _lista, eTipo _tipo, int _mes, int _dia, int _ubi)
        {
            this.listaE = _lista;
            this.tipo = _tipo;
            this.id_pedido = contador;
            this.ubicacion = _ubi;
            //this.fecha = new Datetime(2000, _mes, _dia, 0, 0, 0);
            for (int i = 0; i < _lista.Count(); i++)
            {
                volumen_tot += _lista[i].Volumen;
                peso_tot += _lista[i].Peso;
            }
            contador++;
        }
        ~cPedido() {
            listaE.Clear();
        }
        public bool ProductoEspecial()
        {
            for (int i = 0; i < listaE.Count(); i++)
            {
                if (listaE[i].GetType() == typeof(cLineaBlanca) || listaE[i].GetType() == typeof(cTelevisor))
                    return true;
            }
            return false;
        }
        public void SettearTele(cVehiculo vehiculo)
        {
            for (int i = 0; i < listaE.Count(); i++)
            {
                if (listaE[i].GetType() == typeof(cTelevisor))
                    listaE[i].SetAltura((int)vehiculo.Alto * 100);
            }
        }
    }
}
