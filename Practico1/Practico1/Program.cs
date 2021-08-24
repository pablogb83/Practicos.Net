using DataAccesLayer;
using Shared;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practico1
{
    class Program
    {
        static void Main(string[] args)
        {

            //IDAL_Persona dal = new DAL_Persona_SQLNativo();


            ManejadorPersonas manejador = new ManejadorPersonas();
            string nombre = "";
            string documento = "";
            string fNac="";
            string opcion = "";
            List<string> prueba = null;
            
            do
            {
                mostrarMenu();
                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        prueba = manejador.listarPersonas().Select(x=>x.toString()).ToList();
                        if (prueba != null /*&& !prueba.Any()*/)
                        {
                            prueba.ForEach(x =>
                                {
                                    Console.WriteLine(x);
                                });
                        }
                        else
                        {
                            Console.WriteLine("No hay personas ingresadas");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Ingresa tu nombre");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Ingresa tu documento");
                        documento = Console.ReadLine();
                        Console.WriteLine("Ingresa tu fecha de nacimiento (dd-mm-aaaa)");
                        fNac = Console.ReadLine();
                        manejador.ingresarPersona(nombre, documento, fNac);
                        break;
                    case "3":
                        Console.WriteLine("Ingresa tu nombre");
                        nombre = Console.ReadLine();
                        Console.WriteLine("Ingresa tu documento");
                        documento = Console.ReadLine();
                        prueba = manejador.filtrarPersonas(nombre, documento).Select(x => x.toString()).ToList();
                        if (prueba != null)
                        {
                            prueba.ForEach(x =>
                            {
                                Console.WriteLine(x);
                            });
                        }
                        else
                        {
                            Console.WriteLine("No hay personas ingresadas con esos datos");
                        }
                        break;
                    case "4":
                        break;
                    default:
                        Console.WriteLine("Ingresa una opcion valida");
                        break;

                }

            } while (opcion != "4");

            

        }

        public static void mostrarMenu()
        {
            Console.WriteLine("********MENU********");
            Console.WriteLine("-------------------");
            Console.WriteLine("1- Listar Personas");
            Console.WriteLine("2- Ingresar Persona");
            Console.WriteLine("3- Filtrar y Listar");
            Console.WriteLine("4- Salir");
            Console.WriteLine("-------------------");
            Console.WriteLine("Selecciona la opcion 1, 2, 3 o 4 para salir");
        }

    }
}