using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Omnibus : TransportePublico
    {

        public Omnibus(int cantPasajeros,string nombre) : base(cantPasajeros,nombre) { 

        }

        public override string Avanzar()
        {
            return $"El omnibus avanzó";
        }

        public override string Detenerse()
        {
            return $"El omnibus se detuvo";
        }
    }
}
