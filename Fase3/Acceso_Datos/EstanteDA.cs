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
    public class EstanteDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;

        public LinkedList<Estante> listaEstantes(int idUsuario)
        {
            LinkedList<Estante> estantes = new LinkedList<Estante>();

            try
            {
                cmd = new SqlCommand("show_Estante", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Estante estante = new Estante();

                    estante.letra = reader["letra"].ToString();
                    estante.alto = double.Parse(reader["alto"].ToString());
                    estante.largo = double.Parse(reader["largo"].ToString());
                    estante.ancho = double.Parse(reader["ancho"].ToString());
                    estante.idPasillo = int.Parse(reader["fk_pasillo"].ToString());

                    estantes.AddLast(estante);
                }

                conexion.cerrarConexion();
            }
            catch (Exception e)
            {
                return null;
            }

            return estantes;
        }

        public bool addEstante(string letra, double largo, double ancho, double alto, int idPasillo)
        {

            try
            {
                cmd = new SqlCommand("add_Estante", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@letra", letra);
                cmd.Parameters.AddWithValue("@largo", largo);
                cmd.Parameters.AddWithValue("@ancho", ancho);
                cmd.Parameters.AddWithValue("@alto", alto);
                cmd.Parameters.AddWithValue("@idPasillo", idPasillo);

                SqlDataReader reader = cmd.ExecuteReader();

                int fila = reader.RecordsAffected;

                if(fila != 0)
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
