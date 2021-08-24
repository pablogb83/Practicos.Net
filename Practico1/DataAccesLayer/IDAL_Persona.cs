using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public interface IDAL_Persona
    {
        List<Persona> GetPersonas();
        void AddPersona(Persona x);
    }
}
