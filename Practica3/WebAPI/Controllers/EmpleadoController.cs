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
                return StatusCode(HttpStatusCode.NotFound);
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
                
                return StatusCode(HttpStatusCode.OK);
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

                return StatusCode(HttpStatusCode.OK);
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

                return StatusCode(HttpStatusCode.OK);
            }
            catch (InvalidOperationException)
            {
                return StatusCode(HttpStatusCode.NotFound);
            }
            catch (DbUpdateException)
            {
                return StatusCode(HttpStatusCode.Conflict);
            }
            catch (Exception)
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

        }
    }
}
