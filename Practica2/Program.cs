using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int i = 5;

            Console.WriteLine("EJERCICIO 1");
            Console.WriteLine(Exceptions.ExTest(i));


            Console.WriteLine("\nEJERCICIO 2");
            Console.WriteLine("Ingrese dos numeros, dividendo y divisor:\n");
            Console.Write("Dividendo -> ");
            string s = Console.ReadLine();
            Console.Write("Divisor -> ");
            string s2 = Console.ReadLine();
            Console.WriteLine(Exceptions.ExTest2(s, s2));
            

            Console.WriteLine("\nEJERCICIO 3");
            try
            {
                Logic l = new Logic();
                Console.WriteLine(l.Exception());
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}\nTipo de error: {ex.GetType()}");
            }
            finally { Console.WriteLine("El ejercicio 3 ha terminado."); }


            Console.WriteLine("\nEJERCICIO 4");
            try
            {
                CustomEx.ThrowCustomEx();
            }catch (CustomEx ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally { Console.WriteLine("El ejercicio 4 ha terminado."); }

            Console.ReadLine();
        }
    }
}
