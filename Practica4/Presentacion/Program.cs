using Entidades;
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

            Console.WriteLine("MENU");

            do
            {
                Console.WriteLine("\nSeleccione una opcion:");
                Console.WriteLine(" 1.Query para devolver objeto customer");
                Console.WriteLine(" 2.Query para devolver todos los productos sin stock");
                Console.WriteLine(" 3.Query para devolver todos los productos que tienen stock y que cuestan más de 3 por unidad");
                Console.WriteLine(" 4.Query para devolver todos los customers de la Región WA");
                Console.WriteLine(" 5.Query para devolver el primer elemento o nulo de una lista de productos donde el ID de producto sea igual a 789");
                Console.WriteLine(" 6.Query para devolver los nombre de los Customers.Mostrarlos en Mayuscula y en Minuscula.");
                Console.WriteLine(" 7.Query para devolver Join entre Customers y Orders donde los customers sean de la Región WA y la fecha de orden sea mayor a 1 / 1 / 1997.");
                Console.WriteLine(" 0. Salir de la app.");
                Console.Write("\n-> ");
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":

                        break;
                    case "4":

                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    case "7":

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
    
    }
}
