using System;
using System.Collections.Generic;
using System.Linq;
using MySql.Data;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Sistema.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;

        private static Conexion Con = null;

        private Conexion()
        {
            this.Base = "art_vinil";
            this.Servidor = "localhost";
            this.Usuario = "root";
            this.Clave = "dany";
        }

        public MySqlConnection CrearConexion()
        {
            MySqlConnection Cadena = new MySqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor + "; Database=" + this.Base + "; Uid=" +this.Usuario +"; Pwd="+this.Clave;
               
            }
            catch(Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion getInstancia()
        {
            if(Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
