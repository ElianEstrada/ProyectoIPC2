using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_Datos
{
    public class SalidaBodegaDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;

        public bool addSalidaBodega(int idsalidaBodega, string fecha, int cliente, int usuarioOperativo, int usuario)
        {
            try
            {
                cmd = new SqlCommand("add_SalidaBodega", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idSalidaBodega", idsalidaBodega);
                cmd.Parameters.AddWithValue("@fecha", fecha);
                cmd.Parameters.AddWithValue("@cliente", cliente);
                cmd.Parameters.AddWithValue("@usuarioOperativo", usuarioOperativo);
                cmd.Parameters.AddWithValue("@usuario", usuario);

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
