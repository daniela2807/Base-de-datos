using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    public class DetalleVenta
    {
        public int Id_DetalleVenta;
        public int IdVenta;
        public int IdArticulo;
        public int Cantidad;
        public double precio;
        public double Descuento;
    }
}
