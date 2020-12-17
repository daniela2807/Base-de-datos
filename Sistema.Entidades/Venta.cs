using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sistema.Entidades
{
    public class Venta
    {
		public int IdVenta { get; set; }
		public int IdCliente { get; set; }
		public int IdUsuario { get; set; }
		public string TipoComprobante { get; set; }
		public string SerieComprobate { get; set; }
		public string NumComprobante { get; set; }
		public DateTime FechaLlegada { get; set; }
		public DateTime FechaEntrega { get; set; }
		public decimal Impuesto { get; set; }
		public decimal Total { get; set; }
		public decimal Anticipo { get; set; }
		public decimal Restante { get; set; }
		public string Estado { get; set; }
	}
}
