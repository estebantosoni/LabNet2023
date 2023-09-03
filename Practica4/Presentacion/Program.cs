using Entidades;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables para el menu
            string opcion;
            bool b = true;

            Queries q = new Queries();

            Console.WriteLine("\nNOTA: para los ejercicios 2 y 3 es necesario ejecutar el archivo .sql subido a la rama para que se agreguen datos en la tabla Productos\n");

            Console.Write("MENU");

            do
            {
                Console.WriteLine("\nSeleccione una opcion:");
                Console.WriteLine(" 1.Query para devolver objeto customer");
                Console.WriteLine(" 2.Query para devolver todos los productos sin stock");
                Console.WriteLine(" 3.Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
                Console.WriteLine(" 4.Query para devolver todos los customers de la Región WA");
                Console.WriteLine(" 5.Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
                Console.WriteLine(" 6.Query para devolver los nombre de los Customers. Mostrarlos en Mayuscula y en Minuscula.");
                Console.WriteLine(" 7.Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.");
                Console.WriteLine(" 0. Salir de la app.");
                Console.Write("\n-> ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Consulta1(q);
                        break;
                    case "2":
                        Consulta2(q);
                        break;
                    case "3":
                        Consulta3(q);
                        break;
                    case "4":
                        Consulta4(q);
                        break;
                    case "5":
                        Consulta5(q);
                        break;
                    case "6":
                        Consulta6(q);
                        break;
                    case "7":
                        Consulta7(q);
                        break;
                    case "0":
                        b = false;
                        break;
                    default:
                        Console.WriteLine("Ingrese un valor correcto.\n");
                        break;
                }
                
            } while (b);

            Console.ReadLine();
        }

        #region Consultas

        public static void Consulta1(Queries q)
        {
            try
            {
                Customers customer = q.GetCustomer();

                Console.WriteLine($"ID: {customer.CustomerID}\nNombre: {customer.CompanyName}\n" +
                $"Contacto: {customer.ContactName}\nTitulo: {customer.ContactTitle}\n" +
                $"Direccion: {customer.Address}\nCiudad: {customer.City}\nPais: {customer.Country}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void Consulta2(Queries q)
        {
            try
            {
                List<Products> products = q.GetProductsWithoutStock();

                foreach (var item in products)
                {
                    Console.WriteLine($"ID: {item.ProductID} - Nombre: {item.ProductName} - Stock: {item.UnitsInStock}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public static void Consulta3(Queries q)
        {
            try
            {
                List<Products> products = q.GetProductsMoreThan3PerUnit();
                foreach (var item in products)
                {
                    Console.WriteLine($"ID: {item.ProductID} - Nombre: {item.ProductName}" +
                        $" - Stock: {item.UnitsInStock} - Precio por unidad: {item.UnitPrice}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }


        public static void Consulta4(Queries q)
        {
            string s;

            try
            {
                s = ElegirRegion();

                List < Customers > customer = q.GetCustomerByRegion(s);

                foreach (var item in customer)
                {
                    Console.WriteLine($"ID: {item.CustomerID} - Nombre: {item.CompanyName}" +
                        $" - Region: {item.Region} - Ciudad: {item.City} - Pais: {item.Country}");
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        public static void Consulta5(Queries q)
        {
            try
            {                
                Products product = q.GetProductsByID();
                Console.WriteLine($"ID: {product.ProductID} - Nombre: {product.ProductName}");
                
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine($"El valor devuelto fue NULL\nMensaje de error: {nre.Message}");
            }
            catch(Exception ex) { Console.WriteLine(ex.Message); }

        }

        public static void Consulta6(Queries q)
        {
            try
            {
                Console.WriteLine("\nSe tomaron unicamente los primeros 10 customers para evitar ver mucha informacion en pantalla.\n");

                List<string> customers = q.GetCustomers();

                Console.WriteLine("Lista de customers en minuscula:\n");
                foreach (var item in customers)
                {
                    Console.WriteLine($"-> {item.ToLower()}");
                }

                Console.WriteLine("\nLista de customers en mayuscula:\n");
                foreach (var item in customers)
                {
                    Console.WriteLine($"-> {item.ToUpper()}");
                }


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        public static void Consulta7(Queries q)
        {
            try
            {
                List<Orders> orders = q.JoinCustomersAndOrders();
                foreach (var item in orders)
                {
                    Console.WriteLine($"ID Orden: {item.OrderID} - ID Customer: {item.CustomerID} - Fecha: {item.OrderDate}");
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.ToString());
            }
        }

        #endregion

        #region Helpers
        public static string ElegirRegion()
        {
            bool b = true;
            string s = "";
            string opcion;

            Console.WriteLine("Seleccione una region de la lista: ");
            Console.WriteLine(" 1. BC");
            Console.WriteLine(" 2. SP");
            Console.WriteLine(" 3. WA");
            Console.WriteLine(" 4. OR");
            Console.WriteLine(" 5. DF");
            Console.WriteLine(" 6. RJ");

            do
            {
                Console.Write("\n-> ");

                opcion = Filtrado(false);

                if (opcion != "1" && opcion != "2" && opcion != "3" && opcion != "4" && opcion != "5" && opcion != "6")
                {
                    Console.WriteLine("Ingrese correctamente.\n");

                }
                else
                {
                    b = false;
                }
            } while (b);

            switch (opcion)
            {
                case "1":
                    s = "BC";
                    break;
                case "2":
                    s = "SP";
                    break;
                case "3":
                    s = "WA";
                    break;
                case "4":
                    s = "OR";
                    break;
                case "5":
                    s = "DF";
                    break;
                case "6":
                    s = "RJ";
                    break;
            }

            return s;
        }

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

        #endregion
    }
}
