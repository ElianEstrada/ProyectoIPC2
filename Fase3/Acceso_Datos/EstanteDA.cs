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

    }
}
