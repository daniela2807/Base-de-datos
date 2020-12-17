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
    public class NCliente
    {
        public static DataTable Listar()
        {
            DCliente Datos = new DCliente();
            return Datos.Listar();
        }



        public static DataTable Buscar(string Valor)
        {
            DCliente Datos = new DCliente();
            return Datos.Buscar(Valor);
        }

        public static string Insertar(string Nombre, string Telefono, string Email)
        {
            DCliente Datos = new DCliente();

            string Existe = Datos.Existe(Nombre);
            if (Existe.Equals("1"))
            {
                return "El proveedor ya existe";
            }
            else
            {
                Cliente Obj = new Cliente();
                Obj.Nombre = Nombre;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                return Datos.Insertar(Obj);
            }
        }

        public static string Actualizar(int IdCliente, string Nombre,string nombreAnt, string Telefono, string Email)
        {
            DCliente Datos = new DCliente();

            string Existe = Datos.Existe(Nombre);
            if (Nombre.Equals(nombreAnt))
            {
                Cliente Obj = new Cliente();
                Obj.IdCliente = IdCliente;
                Obj.Nombre = Nombre;
                Obj.Telefono = Telefono;
                Obj.Email = Email;
                return Datos.Actualizar(Obj);
            }
            else
            {
                if (Existe.Equals("1"))
                {
                    return "El cliente ya existe";
                }
                else
                {
                    Cliente Obj = new Cliente();
                    Obj.IdCliente = IdCliente;
                    Obj.Nombre = Nombre;
                    Obj.Telefono = Telefono;
                    Obj.Email = Email;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        public static string Eliminar(int Id)
        {
            DCliente Datos = new DCliente();
            return Datos.Eliminar(Id);
        }
    }
}
