using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Documento { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public Persona(string nombre, string documento, DateTime fechaNacimiento)
        {
            Nombre = nombre;
            Documento = documento;
            FechaNacimiento = fechaNacimiento;
        }

        public int getEdad()
        {
            //return (DateTime.Now - FechaNacimiento).Days / 365;
            int age = 0;
            age = DateTime.Now.Year - FechaNacimiento.Year;
            if (DateTime.Now.DayOfYear < FechaNacimiento.DayOfYear)
                age = age - 1;

            return age;
        }

        public string toString()
        {
            return "Nombre: " + Nombre + ". Documento: " + Documento + ". Fecha Nacimiento: " + FechaNacimiento.ToString("dd-MM-yyyy") + " Edad: " + getEdad();
        }
    }
}
