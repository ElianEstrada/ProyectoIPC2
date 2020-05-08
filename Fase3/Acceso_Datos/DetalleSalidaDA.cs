using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_Datos
{
    public class DetalleSalidaDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;


        public bool add_DetalleSalida(int cantidad, int salida, int asignacion)
        {

            try
            {

                cmd = new SqlCommand("add_DetalleSalida", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@salida", salida);
                cmd.Parameters.AddWithValue("@asignacionNivel", asignacion);

                SqlDataReader reader = cmd.ExecuteReader();

                int filas = reader.RecordsAffected;

                if (filas != 0)
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
