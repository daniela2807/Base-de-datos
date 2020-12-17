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
    public class NProveedor
    {
        public static DataTable Listar()
        {
            DProveedor Datos = new DProveedor();
            return Datos.Listar();
        }



        public static DataTable Buscar(string Valor)
        {
            DProveedor Datos = new DProveedor();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(string Nombre, string Direccion, string Telefono, string Email)
        {
            DProveedor Datos = new DProveedor();

            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                return "El proveedor ya existe";
            }
            else
            {
                Proveedor Obj = new Proveedor();
                Obj.Nombre = Nombre;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                return Datos.Insertar(Obj);
            }
        }

        public static string Actualizar(int IdProveedor, string Nombre,string nombreAnt,  string Direccion, string Telefono, string Email)
        {
            DProveedor Datos = new DProveedor();

            string Existe = Datos.Existe(Nombre);
            if (Nombre.Equals(nombreAnt))
            {
                Proveedor Obj = new Proveedor();
                Obj.IdProveedor = IdProveedor;
                Obj.Nombre = Nombre;
                Obj.Direccion = Direccion;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                return Datos.Actualizar(Obj);
            }
            else
            {
                if (Existe.Equals("1"))
                {
                    return "El proveedor ya existe";
                }
                else
                {
                    Proveedor Obj = new Proveedor();
                    Obj.IdProveedor = IdProveedor;
                    Obj.Nombre = Nombre;
                    Obj.Direccion = Direccion;
                    Obj.Telefono = Telefono;
                    Obj.Email = Email;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        public static string Eliminar(int Id)
        {
            DProveedor Datos = new DProveedor();
            return Datos.Eliminar(Id);
        }

    }
}
