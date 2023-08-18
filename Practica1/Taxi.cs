using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Taxi : TransportePublico
    {

        public Taxi(int cantPasajeros,string nombre) : base(cantPasajeros, nombre) {
        }

        public override string Avanzar()
        {
            return $"El taxi avanzó";
        }

        public override string Detenerse()
        {
            return $"El taxi se detuvo";
        }
    }
}
