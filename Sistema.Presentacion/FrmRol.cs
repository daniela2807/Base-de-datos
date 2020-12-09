using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sistema.Negocio;


namespace Sistema.Presentacion
{
    public partial class FrmRol : Form
    {
        public FrmRol()
        {
            InitializeComponent();
        }
        private void Listar()
        {
            try
            {
                DgbListado.DataSource = NRol.Listar();
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
            DgbListado.Columns[0].Width = 100;
            DgbListado.Columns[0].HeaderText = "ID";
            DgbListado.Columns[1].Width = 200;
            DgbListado.Columns[1].HeaderText = "Nombre";
        }

        private void Roles_Load(object sender, EventArgs e)
        {
            this.Listar();
        }
    }
}
