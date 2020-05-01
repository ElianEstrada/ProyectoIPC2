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
    public class ProveedorDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;


        public LinkedList<Proveedor> listaProveedores(int idUsuario)
        {

            LinkedList<Proveedor> proveedores = new LinkedList<Proveedor>();

            try
            {

                cmd = new SqlCommand("show_Proveedor", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read()){

                    Proveedor proveedor = new Proveedor();

                    proveedor.nit = int.Parse(reader["nit"].ToString());
                    proveedor.nombre = reader["nombre"].ToString();
                    proveedor.direccion = reader["direccion"].ToString();
                    proveedor.celular = int.Parse(reader["celular"].ToString());
                    proveedor.contacto = reader["contacto"].ToString();
                    proveedor.correo = reader["correoElectronico"].ToString();
                    proveedor.limiteCredito = double.Parse(reader["limiteCredito"].ToString());
                    proveedor.usuarioOperativo = int.Parse(reader["fk_UsuarioOperativo"].ToString());
                    proveedor.usuario = int.Parse(reader["pk_usuario"].ToString());

                    proveedores.AddLast(proveedor);

                }

            }
            catch (Exception e)
            {
                return null;
            }

            return proveedores;
        }

    }
}
