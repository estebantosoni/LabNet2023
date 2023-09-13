using Entidades;
using Entidades.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Services
{
    public class EmpleadoService
    {
        readonly Empleados empleados = new Empleados();

        public List<EmployeesDTO> GetAll()
        {
            List<Employees> listEmployees = empleados.GetAll();

            List<EmployeesDTO> listEmployeesDTO = listEmployees.Select(
                e => new EmployeesDTO
                {
                    ID = e.EmployeeID,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                    Title = e.Title,
                    HireDate = e.HireDate,
                    City = e.City,
                    Country = e.Country,
                    HomePhone = e.HomePhone,
                }).ToList();

            return listEmployeesDTO;
        }

        public EmployeesDTO Find(int id)
        {
            Employees e = empleados.Find(id);
            EmployeesDTO employeeDTO = new EmployeesDTO
            {
                ID = e.EmployeeID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title,
                HireDate = e.HireDate,
                City = e.City,
                Country = e.Country,
                HomePhone = e.HomePhone,
            };
            return employeeDTO;

        }

        public void Insert(EmployeesDTO e)
        {
            Employees emp = new Employees
            {
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title,
                HireDate = e.HireDate,
                City = e.City,
                Country = e.Country,
                HomePhone = e.HomePhone
            };

            empleados.Insert(emp);
        }

        public void Update(EmployeesDTO e)
        {
            Employees employee = new Employees
            {
                EmployeeID = e.ID,
                FirstName = e.FirstName,
                LastName = e.LastName,
                Title = e.Title,
                HireDate = e.HireDate,
                City = e.City,
                Country = e.Country,
                HomePhone = e.HomePhone,
            };

            empleados.Update(employee);
        }

        public void Delete(int id)
        {
            empleados.Delete(id);
        }
    }
}
