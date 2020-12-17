using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    public class DetalleIngreso
    {
        public int Id_DetalleIngreso;
        public int IdIngreso;
        public int IdArticulo;
        public int Cantidad;
        public double precio;
    }
}
