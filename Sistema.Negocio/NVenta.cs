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
    public class NVenta
    {
        public static DataTable Listar()
        {
            DVenta Datos = new DVenta();
            return Datos.Listar();
        }


        public static DataTable Buscar(string Valor)
        {
            DVenta Datos = new DVenta();
            return Datos.Buscar(Valor);
        }

        public static DataTable ListarDetalle(int Valor)
        {
            DVenta Datos = new DVenta();
            return Datos.ListarDetalle(Valor);
        }

        public static string Insertar(int idcliente, int idusuario, string tipo_comprobante, string serie_comprobante, string num_comprobante, DateTime fechaentega, decimal impuesto, decimal total, decimal anticipo)
        {
            DVenta Datos = new DVenta();
            Venta Obj = new Venta();
            Obj.IdCliente = idcliente;
            Obj.IdUsuario = idusuario;
            Obj.TipoComprobante = tipo_comprobante;
            Obj.SerieComprobate = serie_comprobante;
            Obj.NumComprobante = num_comprobante;
            Obj.FechaEntrega = fechaentega;
            Obj.Impuesto = impuesto;
            Obj.Total = total;
            Obj.Anticipo = anticipo;
            return Datos.Insertar(Obj);
        }

        public static string InsertarDetalleVenta(int idVenta, int idarticulo, int cantidad, double precio, double descuento)
        {
            DVenta Datos = new DVenta();
            DetalleVenta Obj = new DetalleVenta();
            Obj.IdVenta = idVenta;
            Obj.IdArticulo = idarticulo;
            Obj.Cantidad = cantidad;
            Obj.precio = precio;
            Obj.Descuento = descuento;
            return Datos.InsertarDetalleVenta(Obj);
        }

        public static string Anular(int Id)
        {
            DVenta Datos = new DVenta();
            return Datos.Anular(Id);
        }
    }
}
