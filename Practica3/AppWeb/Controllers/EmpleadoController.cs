using Entidades;
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
            try
            {
                List<EmployeesDTO> listEmployeesDTO = empleadoService.GetAll();
                return View(listEmployeesDTO);
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al traer la lista de empleados.";
                return RedirectToAction("Home");
            }
        }

        // POST: Empleado

        [HttpPost]
        public ActionResult Insert(EmployeesDTO employeeDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empleadoService.Insert(employeeDTO);
                    TempData["SuccessMessage"] = "Empleado creado exitosamente.";
                    return RedirectToAction("Index");
                }
                return View("InsertView", employeeDTO);

            }
            catch(Exception) {

                TempData["ErrorMessage"] = "Ocurrio un error al crear al empleado.";
                return RedirectToAction("Index");

            }


        }

        // PUT: Empleado

        [HttpPost]
        public ActionResult Update(EmployeesDTO employeeDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    empleadoService.Update(employeeDTO);
                    TempData["SuccessMessage"] = "Empleado actualizado exitosamente.";
                    return RedirectToAction("Index");
                }
                return View("UpdateView", employeeDTO);

            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al actualizar al empleado.";
                return RedirectToAction("Index");
            }

        }

        // DELETE: Empleado
        public ActionResult Delete(int id)
        {
            try
            {
                empleadoService.Delete(id);
                TempData["SuccessMessage"] = "Empleado eliminado exitosamente.";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                TempData["ErrorMessage"] = "Ocurrio un error al eliminar al empleado.";
                return RedirectToAction("Index");
            }

        }
    }
}