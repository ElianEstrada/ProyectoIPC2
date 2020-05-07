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
    public class ClienteDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;


        public LinkedList<Cliente> listaClientes(int idUsuario)
        {

            LinkedList<Cliente> clientes = new LinkedList<Cliente>();

            try
            {

                cmd = new SqlCommand("show_Cliente", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.nit = long.Parse(reader["nit"].ToString());
                    cliente.nombre = reader["nombre"].ToString();

                    clientes.AddLast(cliente);
                }

            }
            catch (Exception e)
            {
                return null;
            }

            return clientes;
        }

    }
}
