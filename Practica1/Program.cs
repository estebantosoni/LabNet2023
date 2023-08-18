using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practica1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string s;
            bool b = true;
            bool b2 = true;

            int cantVehiculos = 0;

            int maxVehiculos = 4;
            int maxTipo = 2;
            int maxTaxis = 0;
            int maxOmnibus = 0;

            //datos para los vehiculos
            int pasajeros;
            string nombre;

            //variables para validaciones
            string nro;
            bool esNumero;
            int valor;

            List<TransportePublico> t = new List<TransportePublico>();

            Console.WriteLine($"Ingrese {maxVehiculos} vehiculos. Para cada tipo puede agregar {maxTipo} vehiculos como máximo:\n");

            do {

                Console.WriteLine("¿Que desea agregar?\n1. Omnibus\n2. Taxi\n");
                do
                {
                    Console.Write("-> ");
                    s = Console.ReadLine();
                    
                    if(s.Equals("1") && maxOmnibus == maxTipo)
                    {
                        Console.WriteLine("No puede agregar más bondis. Llegó al límite. Pruebe con otro tipo de vehículo.\n");
                    }
                    else if(s.Equals("2") && maxTaxis == maxTipo)
                    {
                        Console.WriteLine("No puede agregar más taxis. Llegó al límite. Pruebe con otro tipo de vehículo.\n");
                    }
                    else if (s.Equals("1") || s.Equals("2"))
                    {
                        b = false;
                    }
                    else
                    {
                        Console.WriteLine("Ingrese una opción válida.\n");
                    }

                } while (b);

                Console.Write("Ingrese un nombre para el vehiculo:\n-> ");
                nombre = Console.ReadLine();

                Console.Write("Ahora ingrese la cantidad de pasajeros del vehiculo (max. 50 para omnibus y max. 4 para taxis):\n");

                do
                {
                    Console.Write("-> ");
                    nro = Console.ReadLine();
                    esNumero = int.TryParse(nro, out valor);
                    if (esNumero)
                    {
                        if ((int.Parse(nro) < 0 || int.Parse(nro) > 50) && s.Equals("1"))
                        {
                            Console.WriteLine("Ingrese un numero válido.");
                        }
                        else if ((int.Parse(nro) < 0 || int.Parse(nro) > 4) && s.Equals("2"))
                        {
                            Console.WriteLine("Ingrese un numero válido.");
                        }
                        else
                        {
                            b2 = false;
                        }
                    }
                } while (b2);

                pasajeros = int.Parse(nro);

                if (s == "1")
                {
                    t.Add(new Omnibus(pasajeros, $"Omnibus {nombre}"));
                    maxOmnibus++;
                }
                else
                {
                    t.Add(new Taxi(pasajeros, $"Taxi {nombre}"));
                    maxTaxis++;
                }

                cantVehiculos++;
                b = true;
                b2 = true;

            } while (cantVehiculos < maxVehiculos);

            Console.WriteLine("\nCantidad de pasajeros por vehiculo:");
            foreach (var item in t)
            {
                Console.Write($"{item.Nombre} -> ");
                Console.WriteLine(item.Pasajeros);
            }

            Console.ReadLine();
        }
    }
}
