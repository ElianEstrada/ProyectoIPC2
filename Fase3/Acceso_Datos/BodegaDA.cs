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

        
        public bool addBodega(int idBodega, string nombre, string descripcion, string direccion, int usuarioOperativo)
        {

            try
            {
                cmd = new SqlCommand("add_Bodega", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idBodega", idBodega);
                cmd.Parameters.AddWithValue("@nombre", nombre);
                if(descripcion != null || descripcion != "")
                {
                    cmd.Parameters.AddWithValue("@descripcion", descripcion);
                }
                else
                {
                    cmd.Parameters.Add("@descripcion", SqlDbType.Text).Value = System.Data.SqlTypes.SqlString.Null;
                }
                cmd.Parameters.AddWithValue("@direccion", direccion);
                cmd.Parameters.AddWithValue("@usuarioOperativo", usuarioOperativo);

                SqlDataReader reader = cmd.ExecuteReader();

                int filas = reader.RecordsAffected;

                if(filas != 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}
