using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Sistema.Datos;
using Sistema.Entidades;

namespace Sistema.Negocio
{
    public class NArticulo
    {
        public static DataTable Listar()
        {
            DArticulos Datos = new DArticulos();
            return Datos.Listar();
        }

        public static DataTable Buscar(string Valor)
        {
            DArticulos Datos = new DArticulos();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(int idcategoria, string Codigo, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {
            DArticulos Datos = new DArticulos();

            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                return "El articulo ya existe";
            }
            else
            {
                Articulo Obj = new Articulo();
                Obj.IdCategoria = idcategoria;
                Obj.Codigo = Codigo;
                Obj.Nombre = Nombre;
                Obj.PrecioVenta = PrecioVenta;
                Obj.Stock = Stock;
                Obj.Descripcion = Descripcion;
                Obj.Imagen = Imagen;
                return Datos.Insertar(Obj);
            }
        }

        public static string Actualizar(int idarticulo, int idcategoria, string Codigo, string Nombre, decimal PrecioVenta, int Stock, string Descripcion, string Imagen)
        {
            DArticulos Datos = new DArticulos();

            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals(1))
            {
                return "La articulo ya existe";
            }
            else
            {
                Articulo Obj = new Articulo();
                Obj.IdArticulo = idarticulo;
                Obj.IdCategoria = idcategoria;
                Obj.Codigo = Codigo;
                Obj.Nombre = Nombre;
                Obj.PrecioVenta = PrecioVenta;
                Obj.Descripcion = Descripcion;
                Obj.Stock = Stock;
                Obj.Imagen = Imagen;
                return Datos.Actualizar(Obj);
            }
        }

        public static string Eliminar(int Id)
        {
            DArticulos Datos = new DArticulos();
            return Datos.Eliminar(Id);
        }

        public static string Activar(int Id)
        {
            DArticulos Datos = new DArticulos();
            return Datos.Activar(Id);
        }

        public static string Desactivar(int Id)
        {
            DArticulos Datos = new DArticulos();
            return Datos.Desactivar(Id);
        }
    }
}
