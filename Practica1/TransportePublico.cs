using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal abstract class TransportePublico
    {

        private int pasajeros;
        private string nombre;

        public TransportePublico(int cantPasajeros,string nombre) { 
            Pasajeros = cantPasajeros;
            Nombre = nombre;
        }

        public int Pasajeros { get => pasajeros; set => pasajeros = value; }
        public string Nombre { get => nombre; set => nombre = value; }

        public abstract string Avanzar();

        public abstract string Detenerse();

    }
}
