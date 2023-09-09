using Entidades.DTO;
using Negocio.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWeb.Controllers
{
    public class EmpleadoController : Controller
    {
        readonly EmpleadoService empleadoService = new EmpleadoService();

        // VIEW: Insert
        public ActionResult InsertView()
        {
            return View();
        }

        // VIEW: Update
        public ActionResult UpdateView(EmployeesDTO employee)
        {
            return View(employee);
        }

        // GET: Empleado

        [HttpGet]
        public ActionResult Index()
        {

            List<EmployeesDTO> listEmployeesDTO = empleadoService.GetAll();

            return View(listEmployeesDTO);
        }

        // POST: Empleado

        [HttpPost]
        public ActionResult Insert(EmployeesDTO employeeDTO)
        {
            empleadoService.Insert(employeeDTO);

            return RedirectToAction("Index");
        }

        // PUT: Empleado

        [HttpPost]
        public ActionResult Update(EmployeesDTO employeesDTO)
        {
            empleadoService.Update(employeesDTO);

            return RedirectToAction("Index");
        }

        // DELETE: Empleado
        public ActionResult Delete(int id)
        {
            try
            {
                empleadoService.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index", "Error");
            }
        }
    }
}