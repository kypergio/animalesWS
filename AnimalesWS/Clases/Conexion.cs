using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AnimalesWS.Clases
{
    public class Conexion
    {
        private string cadena = "Data Source=.\\SQL2012;Initial Catalog=Animales;User ID=sa;Password=.sal4s4d";
        private SqlConnection conexion;
        public Conexion()
        {
            conexion = new SqlConnection(cadena);
            try
            {
                conexion.Open();
            }catch(Exception ex)
            {

            }
        }
        public static SqlConnection Abrir()
        {
            return new Conexion().conexion;
        }
    }
}