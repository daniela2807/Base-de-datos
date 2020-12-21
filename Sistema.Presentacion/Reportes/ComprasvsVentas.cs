using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion.Reportes
{
    public partial class ComprasvsVentas : Form
    {
        public ComprasvsVentas()
        {
            InitializeComponent();
        }

        private void ComprasvsVentas_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.VentasvsCompras' Puede moverla o quitarla según sea necesario.
            this.VentasvsComprasTableAdapter.Fill(this.DsSistema.VentasvsCompras);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
