using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    internal interface ICRUD<T>
    {
        List<T> GetAll();

        void Insert(T employees);

        void Update(T employees);

        void Delete(int id);
    }
}
