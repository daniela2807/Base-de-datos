﻿using System;
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
    public partial class FrmReporteArticulos : Form
    {
        public FrmReporteArticulos()
        {
            InitializeComponent();
        }

        private void FrmReporteArticulos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'DsSistema.articulo_listarreporte' Puede moverla o quitarla según sea necesario.
            this.articulo_listarreporteTableAdapter.Fill(this.DsSistema.articulo_listarreporte);

            this.reportViewer1.RefreshReport();
        }
    }
}
