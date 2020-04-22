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
    public class BodegaDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;


        public LinkedList<Bodega> listaBodegas(int idUsuario)
        {
            LinkedList<Bodega> bodegas = new LinkedList<Bodega>();

            try
            {
                cmd = new SqlCommand("show_Bodegas", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    Bodega bodega = new Bodega();

                    bodega.idBodega = int.Parse(reader["idBodega"].ToString());
                    bodega.nombreBodega = reader["nombreBodega"].ToString();
                    bodega.descripcion = reader["descripcion"].ToString();
                    bodega.direccionFisica = reader["direccionFisica"].ToString();
                    bodega.usuarioOperativo = int.Parse(reader["fk_usuarioOperativo"].ToString());

                    bodegas.AddLast(bodega);
                }
            }
            catch (SqlException e)
            {
                return null;
            }

            return bodegas;
        }

        public int usuarioOperativo(string email)
        {
            try
            {
                cmd = new SqlCommand("search_UsuarioOperativo_email", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return int.Parse(reader["fk_usuario"].ToString());
                }
                else
                {
                    return 0;
                }
                
            }
            catch (Exception e)
            {
                return 0;
            }
        }

    }
}
