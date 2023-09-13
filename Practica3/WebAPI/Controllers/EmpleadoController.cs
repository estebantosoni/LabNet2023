using Entidades.DTO;
using Negocio.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI.Controllers
{
    public class EmpleadoController : ApiController
    {
        private readonly EmpleadoService empleadoService = new EmpleadoService();

        // GET api/empleado
        public IHttpActionResult GetEmpleados()
        {
            try
            {
                List<EmployeesDTO> employees = empleadoService.GetAll();
                return Ok(employees);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

        }

        // GET api/empleado/{id}
        public IHttpActionResult GetEmpleado(int id)
        {
            try
            {
                EmployeesDTO employee = empleadoService.Find(id);

                return Ok(employee);
            }
            catch (NullReferenceException)
            {
                return BadRequest("El ID ingresado no corresponde a ningun empleado.");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

        }

        // POST api/empleado
        public IHttpActionResult PostEmpleado(EmployeesDTO employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                empleadoService.Insert(employee);

                return CreatedAtRoute("DefaultApi", new { id = employee.ID }, employee);
            }
            catch (NullReferenceException)
            {
                return BadRequest("Error: no ha creado el objeto Empleado.");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

        }

        // PUT api/empleado/{id}
        public IHttpActionResult PutEmpleado(EmployeesDTO employee)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                empleadoService.Update(employee);

                return Ok("El empleado ha sido actualizado exitosamente.");
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("Incluya el id del objeto a actualizar en el cuerpo del mensaje.");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

        }

        // DELETE api/empleado/{id}
        public IHttpActionResult DeleteEmpleado(int id)
        {
            try
            {
                empleadoService.Delete(id);

                return Ok("El empleado fue eliminado exitosamente.");
            }
            catch (InvalidOperationException)
            {
                return BadRequest("El ID ingresado no corresponde a ningun empleado.");
            }
            catch (DbUpdateException)
            {
                return BadRequest("No se puede eliminar el empleado debido a que tiene datos que tienen referencias con datos de otras tablas.");
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

        }
    }
}
