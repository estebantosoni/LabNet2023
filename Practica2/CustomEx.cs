using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class CustomEx : Exception
    {

        public CustomEx(string mensaje) : base($"{mensaje}. Mensaje de la excepcion personalizada.") { }

        public static void ThrowCustomEx()
        {
            throw new CustomEx("Error de ejecución");
        }

    }
}
