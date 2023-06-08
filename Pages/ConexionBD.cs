using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;

namespace CRUD.Pages
{
    public class ConexionBD
    {
        private static ConexionBD instance;
        private readonly SqlConnection con; 

        private ConexionBD()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["conexion"].ConnectionString);
        }


        public static ConexionBD Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ConexionBD();
                }
                return instance;
            }
        }

        public SqlConnection GetConnection()
        {
            return con;
        }

        public void abrir()
        {
            try
            {
                con.Open();
                Console.WriteLine("Conexion abierta");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al abrir la BD " + ex.Message);
            };
        }

        public void cerrar()
        {
            con.Close();
        }
    }

}
