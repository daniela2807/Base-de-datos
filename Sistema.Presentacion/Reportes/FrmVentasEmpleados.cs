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
    public partial class FrmVentasEmpleados : Form
    {
        public FrmVentasEmpleados()
        {
            InitializeComponent();
        }

        private void FrmVentasEmpleados_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.Reporte_Ventas' Puede moverla o quitarla según sea necesario.
            this.Reporte_VentasTableAdapter.Fill(this.DsSistema.Reporte_Ventas);

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }
    }
}
