﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Acceso_Datos
{
    public class AsignarNivelDA
    {

        Conexion conexion = new Conexion();
        SqlCommand cmd;

        public bool asignarNivel(int cantidad, int nivel, int detalle)
        {

            try
            {
                cmd = new SqlCommand("add_AsigancionNivel", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@cantidad", cantidad);
                cmd.Parameters.AddWithValue("@nivel", nivel);
                cmd.Parameters.AddWithValue("@detalle", detalle);

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


        public int searchAsginacion(int nivel, int idProducto)
        {

            try
            {

                cmd = new SqlCommand("searchAsignacionNivel", conexion.abrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@nivel", nivel);
                cmd.Parameters.AddWithValue("@idProducto", idProducto);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    return int.Parse(reader["idAsignacionNivel"].ToString());
                }

            }
            catch (Exception e)
            {
                return 0;
            }

            return 0;
        }

    }
}
