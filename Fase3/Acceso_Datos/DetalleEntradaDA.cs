using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Entidad;

namespace Acceso_Datos
{
    public class DetalleEntradaDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;

        public LinkedList<DetalleEntrada> listaDetalleEntrada(int idEntrada)
        {
            LinkedList<DetalleEntrada> detalleEntradas = new LinkedList<DetalleEntrada>();

            try
            {
                cmd = new SqlCommand("show_DetalleEntrada", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idEntrada", idEntrada);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    DetalleEntrada detalleEntrada = new DetalleEntrada();
                    detalleEntrada.idDetalleEntrada = int.Parse(reader["idDetalleEntrada"].ToString());
                    detalleEntrada.precio = double.Parse(reader["precio"].ToString())/int.Parse(reader["conteo"].ToString());
                    detalleEntrada.cantidad = int.Parse(reader["cantidad"].ToString());
                    detalleEntrada.producto = reader["nombre"].ToString();
                    detalleEntrada.costeo = reader["nombreCosteo"].ToString();
                    detalleEntrada.logica = reader["nombreLogica"].ToString();

                    detalleEntradas.AddLast(detalleEntrada);
                }

            }
            catch (Exception e)
            {
                return null;
            }

            return detalleEntradas;
        }

        public int existeProducto(int idProducto, int idUsuario, int costeo)
        {

            try
            {
                cmd = new SqlCommand("existeProducto", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idProducto", idProducto);
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                cmd.Parameters.AddWithValue("@idCosteo", costeo);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return int.Parse(reader["idDetalleEntrada"].ToString());
                }
            }
            catch (Exception e)
            {
                return 0;
            }

            return 0;
        }


        public bool addDetalleEntrada(double precio, int cantidad, int producto, int entrada, int costeo, int? logica, int idUsuario)
        {

            try
            {
                int detalle = existeProducto(producto, idUsuario, costeo);

                if (detalle == 0){

                    cmd = new SqlCommand("add_detalleEntrada", conexion.abrirConexion());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@producto", producto);
                    cmd.Parameters.AddWithValue("@entrdad", entrada);
                    cmd.Parameters.AddWithValue("@costeo", costeo);
                    if(logica != null)
                    {
                        cmd.Parameters.AddWithValue("@logica", logica);
                    }
                    else
                    {
                        cmd.Parameters.Add("@logica", SqlDbType.Int).Value = SqlInt32.Null;
                    }

                    SqlDataReader reader = cmd.ExecuteReader();

                    int filas = reader.RecordsAffected;

                    if(filas != 0)
                    {
                        return true;
                    }
                }
                else
                {
                    cmd = new SqlCommand("modificarPrecio", conexion.abrirConexion());
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@precio", precio);
                    cmd.Parameters.AddWithValue("@idDetalle", detalle);
                    cmd.Parameters.AddWithValue("@cantidad", cantidad);

                    SqlDataReader reader = cmd.ExecuteReader();


                    int filas = reader.RecordsAffected;

                    if(filas != 0)
                    {
                        return true;
                    }
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
