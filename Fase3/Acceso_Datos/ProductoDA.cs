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
    public class ProductoDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;


        public LinkedList<Producto> listaProductos(int idUsuario)
        {
            LinkedList<Producto> productos = new LinkedList<Producto>();

            try
            {

                cmd = new SqlCommand("show_Producto", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Producto producto = new Producto();

                    producto.codigoProducto = int.Parse(reader["codigoProducto"].ToString());
                    producto.codigoBarras = int.Parse(reader["codigoBarra"].ToString());
                    producto.nombreProducto = reader["nombreProducto"].ToString();
                    producto.descripcion = reader["descripcion"].ToString();
                    producto.clasificacion = reader["nombreClasificacion"].ToString();
                    producto.presentacion = reader["nombrePresentacion"].ToString();
                    producto.usuario = int.Parse(reader["idUsuario"].ToString());

                    productos.AddLast(producto);
                }

            }
            catch (Exception e)
            {
                return null;
            }


            return productos;
        }


    }
}
