using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ManejadorPersonas
    {
        public List<Persona> lista = new List<Persona>();

        public List<Persona> listarPersonas()
        {
            return lista.OrderByDescending(x => x.getEdad()).ToList();
        }

        public void ingresarPersona(string nombre, string documento, string fechaNac)
        {
            if(nombre!=null && documento != null && fechaNac != null && nombre != "" && documento != "" && fechaNac != "")
            {
                DateTime nacimiento = DateTime.ParseExact(fechaNac, "dd-MM-yyyy", CultureInfo.InvariantCulture);
                Persona p = new Persona(nombre, documento, nacimiento);
                lista.Add(p);
            }

        }

        public List<Persona> filtrarPersonas(string nombre, string documento)
        {
            if (nombre != null || documento != null)
            {
                List<Persona> resultado = lista.Where(x => x.Nombre.Contains(nombre) && x.Documento.Contains(documento)).ToList();
                return resultado;
            }
            else
            {
                return null;
            }
        }
    }
}
