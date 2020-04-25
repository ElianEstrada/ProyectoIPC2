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
    public class PasilloDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;

        public LinkedList<Pasillo> listaPasillos(int idUsuario)
        {
            LinkedList<Pasillo> pasillos = new LinkedList<Pasillo>();

            try
            {
                cmd = new SqlCommand("show_Pasillo", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Pasillo pasillo = new Pasillo();

                    pasillo.idPasillo = int.Parse(reader["idPasillo"].ToString());
                    pasillo.largo = double.Parse(reader["largo"].ToString());
                    pasillo.ancho = double.Parse(reader["ancho"].ToString());
                    pasillo.idBodega = int.Parse(reader["fk_bodega"].ToString());

                    pasillos.AddLast(pasillo);
                }

                conexion.cerrarConexion();
            }
            catch (Exception e)
            {
                return null;
            }

            return pasillos;
        }

        public bool addPasillo(int idPasillo, double largo, double ancho, int idBodega)
        {

            try
            {
                cmd = new SqlCommand("add_Pasillo", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idPasillo", idPasillo);
                cmd.Parameters.AddWithValue("@largo", largo);
                cmd.Parameters.AddWithValue("@ancho", ancho);
                cmd.Parameters.AddWithValue("@idBodega", idBodega);

                SqlDataReader reader = cmd.ExecuteReader();

                int fila = reader.RecordsAffected;

                if(fila != 0)
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
