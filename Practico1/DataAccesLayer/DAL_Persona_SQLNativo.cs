using Shared;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer
{
    public class DAL_Persona_SQLNativo : IDAL_Persona
    {
        
        private string cs = "Data Source=LAPTOP-IP61HA1Q;Initial Catalog=2021Personas;Integrated Security=True";

        public void AddPersona(Persona x)
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string documento = x.Documento;
                string nombre = x.Nombre;
                string fechNac = x.FechaNacimiento.ToString();
               

                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("INSERT INTO Personas VALUES(@doc, @nom, @fech)", con);
                    com.Parameters.Add(new SqlParameter("@doc", x.Documento));
                    com.Parameters.Add(new SqlParameter("@nom", x.Nombre));
                    com.Parameters.Add(new SqlParameter("@fech", x.FechaNacimiento));

                    int result = com.ExecuteNonQuery();

                    if (result <= 0)
                    {
                        throw new Exception();
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }
        }

        public List<Persona> GetPersonas()
        {
            List<Persona> personas = new List<Persona>();
            using (SqlConnection con = new SqlConnection(cs))
            {
                try
                {
                    con.Open();
                    SqlCommand com = new SqlCommand("SELECT * FROM Personas", con);
                    SqlDataReader sqlDataReader = com.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        Persona p = new Persona(
                                sqlDataReader.GetString(1),
                                sqlDataReader.GetString(0),
                                sqlDataReader.GetDateTime(2)
                            );

                        personas.Add(p);
                    }

                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    con.Close();
                }

            }

            return personas;
        }
    }
}

