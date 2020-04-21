using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Acceso_Datos
{
    class Conexion
    {

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-R1QU47N;Initial Catalog=fase3_proyecto;Integrated Security=True");

        public SqlConnection abrirConexion()
        {
            if(connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                connection.Open();
            }
            else
            {
                connection.Open();
            }

            return connection;
        }


        public SqlConnection cerrarConexion()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }

            return connection;
        }


    }
}
