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

                    usuarioOperativo.cui = long.Parse(reader["cui"].ToString());
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

    }
}
