using Sistema.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sistema.Presentacion
{
    public partial class Vista_ProveedorIngreso : Form
    {
        public Vista_ProveedorIngreso()
        {
            InitializeComponent();
        }

        private void Vista_ProveedorIngreso_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
        private void Listar()
        {
            try
            {
                DgbListado.DataSource = NProveedor.Listar();
                this.Formato();
                LblTotal.Text = "Total Registros :" + Convert.ToString(DgbListado.Rows.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Formato()
        {
            DgbListado.Columns[0].Visible = false;
            DgbListado.Columns[1].Width = 150;
            DgbListado.Columns[2].Width = 150;
            DgbListado.Columns[3].Width = 150;
            DgbListado.Columns[4].Width = 150;
        }

        private void Buscar()
        {
            try
            {
                DgbListado.DataSource = NProveedor.Buscar(TxtBuscar.Text);
                this.Formato();
                LblTotal.Text = "Total Registros :" + Convert.ToString(DgbListado.Rows.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void DgbListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Variables.IdProveedor =Convert.ToInt16(DgbListado.CurrentRow.Cells["ID"].Value);
            Variables.NombreProveedor = Convert.ToString(DgbListado.CurrentRow.Cells["Nombre"].Value);
            this.Close();
        }
    }
}
