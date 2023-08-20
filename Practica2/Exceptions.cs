using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica2
{
    internal class Exceptions
    {

        public static string ExTest(int x)
        {
            try
            {
                int res = x / 0;
                return $"El valor devuelto es {res}";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
            finally
            {
                Console.WriteLine("La operacion ha terminado.");
            }
        }

        public static string ExTest2(string x, string y)
        {
            try
            {
                int res = int.Parse(x) / int.Parse(y);
                return $"El valor devuelto es {res}";
            }
            catch (DivideByZeroException ex)
            {
                return $"¡Usted esta intentando romper las leyes espacio-temporales y eso podria causar una paradoja que destruiria al universo!\nError: {ex.Message}";
            }
            catch (FormatException ex)
            {
                return $"¡Seguro Ingreso una letra o no ingreso nada! Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                return $" Error: {ex.Message}";
            }
            finally { Console.WriteLine("La operacion ha terminado."); }
        }

    }
}
