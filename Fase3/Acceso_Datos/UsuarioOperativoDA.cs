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
    public class UsuarioOperativoDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;

        public LinkedList<UsuarioOperativo> listaUsuariosOperativos()
        {
            LinkedList<UsuarioOperativo> usuariosOperativos = new LinkedList<UsuarioOperativo>();

            try
            {

                cmd = new SqlCommand("listaUsuariosOperativos", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UsuarioOperativo usuarioOperativo = new UsuarioOperativo();

                    usuarioOperativo.cui = int.Parse(reader["cui"].ToString());
                    usuarioOperativo.nombreUsuarioOperativo = reader["nombre"].ToString();
                    usuarioOperativo.correoElectronico = reader["correoElectronico"].ToString();
                    usuarioOperativo.contraseña = reader["contraseña"].ToString();
                    usuarioOperativo.celular = int.Parse(reader["celular"].ToString());
                    usuarioOperativo.usuario = int.Parse(reader["idUsuario"].ToString());

                    usuariosOperativos.AddLast(usuarioOperativo);
                }

                conexion.cerrarConexion();
            }
            catch (Exception e)
            {
                return null;
            }

            return usuariosOperativos;
        }

        public UsuarioOperativo usuarioOperativo(string email)
        {
            UsuarioOperativo usuario = new UsuarioOperativo();
            try
            {
                cmd = new SqlCommand("search_UsuarioOperativo_email", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@email", email);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario.cui = int.Parse(reader["cui"].ToString());
                    usuario.nombreUsuarioOperativo = reader["nombre"].ToString();
                    usuario.correoElectronico = reader["correoElectronico"].ToString();
                    usuario.celular = int.Parse(reader["celular"].ToString());
                    usuario.contraseña = reader["contraseña"].ToString();
                    usuario.puesto = reader["puesto"].ToString();
                    usuario.descripcion = reader["descripcin"].ToString();
                    usuario.usuario =  int.Parse(reader["fk_usuario"].ToString());
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                return null;
            }

            return usuario;
        }

        public bool updatePassword(string password, string email)
        {

            try
            {
                cmd = new SqlCommand("updatePassword", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@email", email);

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
