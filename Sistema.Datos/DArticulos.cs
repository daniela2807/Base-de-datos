using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema.Entidades;
using MySql.Data.MySqlClient;

namespace Sistema.Datos
{
    public class DArticulos
    {
        public DataTable Listar()
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection Con = new MySqlConnection();
            try
            {
                Con = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("articulo_listar", Con);
                Comando.CommandType = CommandType.StoredProcedure;
                Con.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (Con.State == ConnectionState.Open) Con.Close();
            }
        }

        public string Existe(string Valor)
        {
            string Rpta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion(); 
                MySqlCommand Comando = new MySqlCommand("articulo_existe", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("valor2", MySqlDbType.VarChar).Value = Valor;
                MySqlParameter ParExiste = new MySqlParameter();
                ParExiste.ParameterName = "existe";
                ParExiste.MySqlDbType = MySqlDbType.Int16;
                ParExiste.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(ParExiste);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(ParExiste.Value);
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public DataTable Buscar(string Valor)
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("articulo_buscar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("valor2", MySqlDbType.VarChar).Value = Valor;
                SqlCon.Open();
                Resultado = Comando.ExecuteReader();
                Tabla.Load(Resultado);
                return Tabla;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public string Insertar(Articulo Obj)
        {
            string Rpta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("articulo_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("idcategoria2", MySqlDbType.Int16).Value = Obj.IdCategoria;
                Comando.Parameters.Add("codigo2", MySqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("nombre2", MySqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("precio_venta2", MySqlDbType.Decimal).Value = Obj.PrecioVenta;
                Comando.Parameters.Add("stock2", MySqlDbType.Int16).Value = Obj.Stock;
                Comando.Parameters.Add("descripcion2", MySqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("imagen2", MySqlDbType.VarChar).Value = Obj.Imagen;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo ingresar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Actualizar(Articulo Obj)
        {
            string Rpta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("articulo_actualizar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("idarticulo2", MySqlDbType.Int16).Value = Obj.IdArticulo;
                Comando.Parameters.Add("idcategoria2", MySqlDbType.Int16).Value = Obj.IdCategoria;
                Comando.Parameters.Add("codigo2", MySqlDbType.VarChar).Value = Obj.Codigo;
                Comando.Parameters.Add("nombre2", MySqlDbType.VarChar).Value = Obj.Nombre;
                Comando.Parameters.Add("precio_venta2", MySqlDbType.Decimal).Value = Obj.PrecioVenta;
                Comando.Parameters.Add("stock2", MySqlDbType.Int16).Value = Obj.Stock;
                Comando.Parameters.Add("descripcion2", MySqlDbType.VarChar).Value = Obj.Descripcion;
                Comando.Parameters.Add("imagen2", MySqlDbType.VarChar).Value = Obj.Imagen;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo actualizar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Eliminar(int Id)
        {
            string Rpta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("articulo_eliminar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("idarticulo2", MySqlDbType.Int16).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo eliminar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Activar(int Id)
        {
            string Rpta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("articulo_activar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("idarticulo2", MySqlDbType.Int16).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo activar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }

        public string Desactivar(int Id)
        {
            string Rpta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("articulo_desactivar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("idarticulo2", MySqlDbType.Int16).Value = Id;
                SqlCon.Open();
                Rpta = Comando.ExecuteNonQuery() == 1 ? "OK" : "No se pudo desactivar el registro";
            }
            catch (Exception ex)
            {
                Rpta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return Rpta;
        }
    }
}
