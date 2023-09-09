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

            try
            {
                List<Employees> listEmployees = empleados.GetAll();

                List<EmployeesDTO> listEmployeesDTO = listEmployees.Select(
                    e => new EmployeesDTO
                    {
                        ID = e.EmployeeID,
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                    }).ToList();

                return listEmployeesDTO;
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public void Insert(EmployeesDTO employeeDTO)
        {
            try
            {
                Employees emp = new Employees
                {
                    FirstName = employeeDTO.FirstName,
                    LastName = employeeDTO.LastName,
                };

                empleados.Insert(emp);

            }
            catch (Exception) {

                throw new Exception();

            }
        }

        public void Update(EmployeesDTO employeedDTO)
        {
            try
            {
                Employees employee = new Employees
                {
                    EmployeeID = employeedDTO.ID,
                    FirstName = employeedDTO.FirstName,
                    LastName = employeedDTO.LastName
                };

                empleados.Update(employee);

            }
            catch (Exception)
            {

                throw new Exception();

            }
        }

        public void Delete(int id)
        {
            try
            {

                empleados.Delete(id);

            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
