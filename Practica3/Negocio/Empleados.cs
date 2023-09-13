using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Empleados : Base, ICRUD<Employees>
    {
        public int Count()
        {
            return context.Employees.Count();
        }

        public Employees Find(int id)
        {
            return context.Employees.FirstOrDefault(e => e.EmployeeID == id);
        }

        public List<Employees> GetAll()
        {
            return context.Employees.ToList();
        }

        public void Insert(Employees employees)
        {
            context.Employees.Add(employees);
            context.SaveChanges();
        }

        public void Update(Employees employees)
        {
            context.Employees.Attach(employees);

            var entry = context.Entry(employees);
            entry.State = EntityState.Modified;

            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var i = context.Employees.First(e => e.EmployeeID == id);
            context.Employees.Remove(i);
            context.SaveChanges();
        }
    }
}
