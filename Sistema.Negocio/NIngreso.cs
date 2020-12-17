using Sistema.Datos;
using Sistema.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Negocio
{
    public class NIngreso
    {
        public static DataTable Listar()
        {
            DIngreso Datos = new DIngreso();
            return Datos.Listar();
        }


        public static DataTable Buscar(string Valor)
        {
            DIngreso Datos = new DIngreso();
            return Datos.Buscar(Valor);
        }

        public static DataTable ListarDetalle(int Valor)
        {
            DIngreso Datos = new DIngreso();
            return Datos.ListarDetalle(Valor);
        }

        public static string Insertar(int idproveedor, int idusuario, string tipo_comprobante, string serie_comprobante, string num_comprobante, decimal impuesto, decimal total)
        {
            DIngreso Datos = new DIngreso();
            Ingreso Obj = new Ingreso();
            Obj.IdProveedor = idproveedor;
            Obj.IdUsuario = idusuario;
            Obj.TipoComprobante = tipo_comprobante;
            Obj.SerieComprobate = serie_comprobante;
            Obj.NumComprobante = num_comprobante;
            Obj.Impuesto = impuesto;
            Obj.Total = total;
            return Datos.Insertar(Obj);
        } 

        public static string InsertarDetalle(int idIngreso, int idarticulo, int cantidad, double precio)
        {
            DIngreso Datos = new DIngreso();
            DetalleIngreso Obj = new DetalleIngreso();
            Obj.IdIngreso = idIngreso;
            Obj.IdArticulo = idarticulo;
            Obj.Cantidad =cantidad;
            Obj.precio = precio;
            return Datos.InsertarDetalle(Obj);
        }

        public static string Anular(int Id)
        {
            DIngreso Datos = new DIngreso();
            return Datos.Anular(Id);
        }
    }
}
