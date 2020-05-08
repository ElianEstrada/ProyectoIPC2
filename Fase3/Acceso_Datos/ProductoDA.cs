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


        public LinkedList<InformeBodega> informeBodegas(int idUsuario, int idbodega)
        {

            LinkedList<InformeBodega> productos = new LinkedList<InformeBodega>();

            try
            {

                cmd = new SqlCommand("invetarioBodega", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idBodega", idbodega);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InformeBodega informe = new InformeBodega();

                    informe.nombre = reader[0].ToString();
                    informe.precio = double.Parse(reader[1].ToString());
                    informe.pasillo = int.Parse(reader[2].ToString());
                    informe.letra = reader[3].ToString();
                    informe.nivel = int.Parse(reader[4].ToString());
                    informe.costeo = reader[5].ToString();
                    informe.logica = reader[6].ToString();

                    productos.AddLast(informe);
                }

            }
            catch (Exception e)
            {
                return null;
            }


            return productos;

        }


        public LinkedList<InventarioProducto> inventarioProductos(int idUsuario, int codigoProducto)
        {
            LinkedList<InventarioProducto> productos = new LinkedList<InventarioProducto>();

            try
            {
                cmd = new SqlCommand("inventarioProducto", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@codigoProducto", codigoProducto);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    InventarioProducto inventario = new InventarioProducto();
                    inventario.codigoProducto = int.Parse(reader[0].ToString());
                    inventario.codigoBarras = int.Parse(reader[1].ToString());
                    inventario.nombreProducto = reader[2].ToString();
                    inventario.cantidad = int.Parse(reader[3].ToString());
                    inventario.precio = double.Parse(reader[4].ToString());
                    inventario.bodega = int.Parse(reader[5].ToString());
                    inventario.pasillo = int.Parse(reader[6].ToString());
                    inventario.letra = reader[7].ToString();
                    inventario.nivel = int.Parse(reader[8].ToString());
                    inventario.costeo = reader[9].ToString();
                    inventario.logica = reader[10].ToString();

                    productos.AddLast(inventario);
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
