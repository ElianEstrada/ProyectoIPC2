using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_Datos
{
    public class EntradaBodegaDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;


        public bool agregarEntradaBodega(int idEntrada, string fecha, int proveedor, int usuarioOperativo, int usuario)
        {

            try
            {

                cmd = new SqlCommand("add_Entrada", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEntrada", idEntrada);
                cmd.Parameters.AddWithValue("@proveedor", proveedor);
                cmd.Parameters.AddWithValue("@fecha", fecha);
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
