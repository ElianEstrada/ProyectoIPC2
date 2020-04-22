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

    }
}
