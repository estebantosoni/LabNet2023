using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables para el menu
            string opcion;
            bool b = true, b2 = true, b3 = true;

            //Variables para las entidades usadas
            Empleados e = new Empleados();
            Categorias c = new Categorias();

            Console.WriteLine("MENU");

            do
            {
                Console.WriteLine("\nSeleccione una opcion:");
                Console.WriteLine("1. Consultas simples a entidades");
                Console.WriteLine("2. CRUD a la entidad Empleados");
                Console.WriteLine("0. Salir de la app.");
                Console.Write("\n-> ");
                opcion = Console.ReadLine();

                if (opcion == "1")
                {
                    do
                    {
                        Console.WriteLine("\nSeleccione una entidad para ver algunas consultas: ");
                        Console.WriteLine("1. Empleados");
                        Console.WriteLine("2. Categorias");
                        Console.WriteLine("0. Volver");
                        Console.Write("\n-> ");
                        opcion = Console.ReadLine();

                        if (opcion == "1")
                        {
                            ConsultaSimpleEmpleados(e);

                        }
                        else if (opcion == "2")
                        {
                            ConsultaSimpleCategorias(c);
                        }
                        else if (opcion == "0")
                        {
                            b2 = false;
                        }
                        else
                        {
                            Console.WriteLine("Ingrese una opcion correcta.\n");
                        }
                    } while (b2);

                    b2 = true;
                }
                else if(opcion == "2")
                {
                    do
                    {
                        Console.WriteLine("\nSeleccione una opcion: ");
                        Console.WriteLine("1. Insertar nuevo empleado.");
                        Console.WriteLine("2. Actualizar empleado.");
                        Console.WriteLine("3. Eliminar empleado.");
                        Console.WriteLine("0. Volver");
                        Console.Write("\n-> ");
                        opcion = Console.ReadLine();

                        if (opcion == "1")
                        {

                            InsertarEmpleado(e);

                        }
                        else if (opcion == "2")
                        {
                            ActualizarEmpleado(e);

                        }
                        else if(opcion == "3")
                        {
                            EliminarEmpleado(e);
                                
                        }
                        else if (opcion == "0")
                        {
                            b3 = false;
                        }
                        else
                        {
                            Console.WriteLine("Ingrese una opcion correcta.\n");
                        }

                    } while (b3);

                    b3 = true;
                }
                else if(opcion == "0")
                {
                    b = false;
                }
                else
                {
                    Console.WriteLine("Ingrese una opcion correcta.\n");
                }

            } while (b);

            Console.ReadLine();
        }

        #region CRUD Empleados

        public static void InsertarEmpleado(Empleados e)
        {
            Console.Write("Ingrese el nombre del empleado: ");
            string nombre = Filtrado(true);
            Console.Write("Ingrese el apellido del empleado: ");
            string apellido = Filtrado(true);
            Employees emp = new Employees
            {
                FirstName = nombre,
                LastName = apellido
            };

            try
            {
                e.Insert(emp);
                Console.WriteLine("Empleado agregado exitosamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public static void ActualizarEmpleado(Empleados e)
        {
            Console.Write("Escriba el ID del empleado que desea actualizar: ");
            string s = Filtrado(false);
            int id = int.Parse(s);
            if (e.Find(id) != null)
            {
                Console.Write("Ingrese el nombre del empleado: ");
                string nombre = Filtrado(true);
                Console.Write("Ingrese el apellido del empleado: ");
                string apellido = Filtrado(true);
                Employees emp = new Employees
                {
                    EmployeeID = id,
                    FirstName = nombre,
                    LastName = apellido
                };

                try
                {
                    e.Update(emp);
                    Console.WriteLine("Empleado actualizado exitosamente");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            else
            {
                Console.WriteLine("El ID ingresado no corresponde a ningun empleado.");
            }
        }


        public static void EliminarEmpleado(Empleados e)
        {
            Console.Write("Escriba el ID del empleado que desea eliminar: ");
            string s = Filtrado(false);
            int id = int.Parse(s);
            if (e.Find(id) != null)
            {
                try
                {
                    e.Delete(id);
                    Console.WriteLine("Empleado eliminado exitosamente");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("\nError: El empleado no puede eliminarse porque esta relacionado con otra tabla.");
                    Console.WriteLine("Pruebe agregar un empleado desde consola y luego eliminarlo.\n\n");
                    Console.WriteLine("Mensaje de error: " + ex.ToString());
                }
            }
            else
            {
                Console.WriteLine("El ID ingresado no corresponde a ningun empleado.");
            }
        }

        #endregion

        #region Consultas Simples

        public static void ConsultaSimpleEmpleados(Empleados e)
        {
            int i = e.Count();
            Console.WriteLine("\nCantidad de empleados: " + i);

            List<Employees> employees = e.GetAll();

            Console.WriteLine("\nLista de empleados: ");
            foreach (var item in employees)
            {
                Console.WriteLine("ID: " + item.EmployeeID + " | " + "Nombre: " + item.FirstName + " " + item.LastName);
            }
        }

        public static void ConsultaSimpleCategorias(Categorias c)
        {
            List<Categories> list = c.GetAll();

            Console.WriteLine("\nLista de categorias: ");
            foreach (Categories cat in list)
            {
                Console.WriteLine("-> Nombre: " + cat.CategoryName + " | " + "Descripcion: " + cat.Description);
            }
        }

        #endregion

        static string Filtrado(bool b)
        {
            string texto = "";
            ConsoleKeyInfo tecla;

            do
            {
                tecla = Console.ReadKey(intercept: true);

                if (b)
                {
                    if (char.IsLetter(tecla.KeyChar))
                    {
                        Console.Write(tecla.KeyChar);
                        texto += tecla.KeyChar;
                    }
                }
                else
                {
                    if (char.IsDigit(tecla.KeyChar))
                    {
                        Console.Write(tecla.KeyChar);
                        texto += tecla.KeyChar;
                    }
                }
                
            } while (tecla.Key != ConsoleKey.Enter);

            Console.WriteLine();

            return texto;
        }
    }
}
