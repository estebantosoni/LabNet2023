using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Logic
    {

        private readonly Exception[] arregloEx =
        {
            new DivideByZeroException(),
            new FormatException(),
            new AccessViolationException(),
            new IndexOutOfRangeException(),
            new InvalidCastException(),
            new NullReferenceException(),
            new InvalidOperationException("Operacion no valida"),
        };

        public Exception[] ArregloEx => arregloEx;

        public Exception Exception()
        {
            Random random = new Random();
            int x = random.Next(0, ArregloEx.Length-1);

            throw ArregloEx[x];
        }
    }
}
