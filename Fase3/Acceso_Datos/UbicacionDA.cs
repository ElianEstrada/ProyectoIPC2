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
    public class UbicacionDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;


        public LinkedList<Ubicacion> listaUbicaciones(int idUsuario, int idProducto)
        {
            LinkedList<Ubicacion> ubicaciones = new LinkedList<Ubicacion>();

            try
            {

                cmd = new SqlCommand("ubicaciones", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Ubicacion ubicacion = new Ubicacion();
                    ubicacion.bodega = reader["nombreBodega"].ToString();
                    ubicacion.pasillo = int.Parse(reader["idPasillo"].ToString());
                    ubicacion.estante = reader["letra"].ToString();
                    ubicacion.nivel = int.Parse(reader["idNivel"].ToString());
                    ubicacion.canidad = int.Parse(reader["cantidad"].ToString());

                    ubicaciones.AddLast(ubicacion);
                }

            }
            catch (Exception e)
            {
                return null;
            }

            return ubicaciones;
        }


    }
}
