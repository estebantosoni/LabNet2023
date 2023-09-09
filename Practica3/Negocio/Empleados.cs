using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Empleados : Base, ICRUD<Employees>
    {
        public int CountEmployees()
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
            var emp = context.Employees.Find(employees.EmployeeID);
            emp.FirstName = employees.FirstName;
            emp.LastName = employees.LastName;
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
