using MySql.Data.MySqlClient;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Datos
{
    public class DIngreso
    {
        public DataTable Listar()
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection Con = new MySqlConnection();
            try
            {
                Con = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("ingreso_listar", Con);
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
        public DataTable Buscar(string Valor)
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("ingreso_buscar", SqlCon);
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

        public DataTable ListarDetalle(int Valor)
        {
            MySqlDataReader Resultado;
            DataTable Tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("ingreso_lista_detalle", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("idingreso2", MySqlDbType.Int16).Value = Valor;
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

        public string InsertarDetalle(DetalleIngreso Obj)
        {

            string Rpta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("detalleingreso_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("idingreso2", MySqlDbType.Int16).Value = Obj.IdIngreso;
                Comando.Parameters.Add("idarticulo2", MySqlDbType.Int16).Value = Obj.IdArticulo;
                Comando.Parameters.Add("cantidad2", MySqlDbType.Int16).Value = Obj.Cantidad;
                Comando.Parameters.Add("precio2", MySqlDbType.Double).Value = Obj.precio;
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

        public string Insertar(Ingreso Obj)
        {
            string Rpta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("ingreso_insertar", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("idproveedor2", MySqlDbType.Int16).Value = Obj.IdProveedor;
                Comando.Parameters.Add("idusuario2", MySqlDbType.Int16).Value = Obj.IdUsuario;
                Comando.Parameters.Add("tipo_comprobante2", MySqlDbType.VarChar).Value = Obj.TipoComprobante;
                Comando.Parameters.Add("serie_comprobante2", MySqlDbType.VarChar).Value = Obj.SerieComprobate;
                Comando.Parameters.Add("num_comprobante2", MySqlDbType.VarChar).Value = Obj.NumComprobante;
                Comando.Parameters.Add("impuesto2", MySqlDbType.Decimal).Value = Obj.Impuesto;
                Comando.Parameters.Add("total2", MySqlDbType.Decimal).Value = Obj.Total;
                MySqlParameter Indice = new MySqlParameter();
                Indice.ParameterName = "indice";
                Indice.MySqlDbType = MySqlDbType.Int16;
                Indice.Direction = ParameterDirection.Output;
                Comando.Parameters.Add(Indice);
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = Convert.ToString(Indice.Value);
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

        public string Anular(int Id)
        {
            string Rpta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.getInstancia().CrearConexion();
                MySqlCommand Comando = new MySqlCommand("ingreso_anular", SqlCon);
                Comando.CommandType = CommandType.StoredProcedure;
                Comando.Parameters.Add("valor2", MySqlDbType.Int16).Value = Id;
                SqlCon.Open();
                Comando.ExecuteNonQuery();
                Rpta = "OK";
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
