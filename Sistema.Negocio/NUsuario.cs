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
    public class NUsuario
    {
        public static DataTable Listar()
        {
            DUsuario Datos = new DUsuario();
            return Datos.Listar();
        }



        public static DataTable Buscar(string Valor)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Buscar(Valor);
        }

        public static DataTable Login(string email, string contrasena)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Login(email,contrasena);
        }


        public static string Insertar(int idrol,string nombre, string direccion ,string telefono,string email, string contrasena)
        {
            DUsuario Datos = new DUsuario();

            string Existe = Datos.Existe(email);
            if (Existe.Equals("1"))
            {
                return "El usuario ya existe";
            }
            else
            {
                Usuario Obj = new Usuario();
                Obj.IdRol = idrol;
                Obj.Nombre = nombre;
                Obj.Direccion = direccion;
                Obj.Telefono = telefono;
                Obj.Email = email;
                Obj.Contrasena = contrasena;
                return Datos.Insertar(Obj);
            }
        }

        public static string Actualizar(int idusuario,int idrol, string nombre, string direccion, string telefono, string emailant, string email, string contrasena)
        {
            DUsuario Datos = new DUsuario();

            string Existe = Datos.Existe(emailant);
            if (email.Equals(emailant))
            {
                Usuario Obj = new Usuario();
                Obj.IdUsuario = idusuario;
                Obj.IdRol = idrol;
                Obj.Nombre = nombre;
                Obj.Direccion = direccion;
                Obj.Telefono = telefono;
                Obj.Email = email;
                Obj.Contrasena = contrasena;
                return Datos.Actualizar(Obj);
            }
            else
            {
                if (Existe.Equals("1"))
                {
                    return "El usuario ya existe";
                }
                else
                {
                    Usuario Obj = new Usuario();
                    Obj.IdUsuario = idusuario;
                    Obj.IdRol = idrol;
                    Obj.Nombre = nombre;
                    Obj.Direccion = direccion;
                    Obj.Telefono = telefono;
                    Obj.Email = email;
                    Obj.Contrasena = contrasena;
                    return Datos.Actualizar(Obj);
                }
            }
        }

        public static string Eliminar(int Id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Eliminar(Id);
        }

        public static string Activar(int Id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Activar(Id);
        }

        public static string Desactivar(int Id)
        {
            DUsuario Datos = new DUsuario();
            return Datos.Desactivar(Id);
        }
    }
}
