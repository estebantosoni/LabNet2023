using Datos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Base
    {
        protected readonly NorthwindContext context;

        public Base()
        {
            context = new NorthwindContext();
        }
    }
}
