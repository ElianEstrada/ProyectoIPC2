using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidad;

namespace Acceso_Datos
{
    public class NivelDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;

        public LinkedList<Nivel> listaNiveles(int idUsuario)
        {
            LinkedList<Nivel> niveles = new LinkedList<Nivel>();

            try
            {
                cmd = new SqlCommand("show_Nivel", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Nivel nivel = new Nivel();
                    nivel.idNivel = int.Parse(reader["idNivel"].ToString());
                    nivel.alto = double.Parse(reader["alto"].ToString());
                    nivel.largo = double.Parse(reader["largo"].ToString());
                    nivel.ancho = double.Parse(reader["ancho"].ToString());
                    nivel.letraEstante = reader["fk_estante"].ToString();

                    niveles.AddLast(nivel);
                }
            }
            catch (Exception e)
            {
                return null;
            }

            return niveles;
        }

        public bool addNivel(int idNivel, double alto, string letra)
        {

            try
            {
                cmd = new SqlCommand("add_Nivel", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idNivel", idNivel);
                cmd.Parameters.AddWithValue("@alto", alto);
                cmd.Parameters.AddWithValue("@letraEstante", letra);

                SqlDataReader reader = cmd.ExecuteReader();

                int filas = reader.RecordsAffected;

                if(filas != 0)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }

            return false;
        }

    }
}
