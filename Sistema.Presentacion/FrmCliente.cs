﻿using Sistema.Negocio;
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
    public partial class FrmCliente : Form
    {
        public string nombreAnt;
        public FrmCliente()
        {
            InitializeComponent();
        }

        private void FrmCliente_Load(object sender, EventArgs e)
        {
            this.Listar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtNombre.Text == string.Empty || TxtTelefono.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, seran remarcados.");
                    ErrorIcono.SetError(TxtNombre, "Ingresa un nombre");
                    ErrorIcono.SetError(TxtEmail, "Ingresa un telefono");
                }
                else
                {
                    Rpta = NCliente.Actualizar(Convert.ToInt16(TxtId.Text), TxtNombre.Text.Trim(),this.nombreAnt, TxtTelefono.Text.Trim(), TxtEmail.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeoOk("Se actualizo de forma correcta el registro");
                        this.Listar();
                    }
                    else
                    {
                        MessageBox.Show(Rpta);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void Listar()
        {
            try
            {
                DgbListado.DataSource = NCliente.Listar();
                this.Formato();
                this.Limpiar();
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
        }

        private void Buscar()
        {
            try
            {
                DgbListado.DataSource = NCliente.Buscar(TxtBuscar.Text);
                this.Formato();
                LblTotal.Text = "Total Registros :" + Convert.ToString(DgbListado.Rows.Count);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void Limpiar()
        {
            TxtBuscar.Clear();
            TxtNombre.Clear();
            TxtId.Clear();
            TxtTelefono.Clear();
            TxtEmail.Clear();
            btnInsertar.Visible = true;
            btnActualizar.Visible = false;
            ErrorIcono.Clear();
            DgbListado.Columns[0].Visible = false;
            btnEliminar.Visible = false;
            ChkSeleccionar.Checked = false;
        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeoOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtNombre.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, seran remarcados.");
                    ErrorIcono.SetError(TxtNombre, "Ingresa un nombre");
                }
                else
                {
                    Rpta = NCliente.Insertar(TxtNombre.Text.Trim(), TxtTelefono.Text.Trim(), TxtEmail.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeoOk("Se inserto de forma correcta el registro");
                        this.Listar();
                    }
                    else
                    {
                        MessageBox.Show(Rpta);
                    }
                }
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente deseas eliminar el(los) registro?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in DgbListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt16(row.Cells[1].Value);
                            Rpta = NCliente.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeoOk("Se elimino el registo " + Convert.ToString(row.Cells[2].Value));
                            }
                            else
                            {
                                this.MensajeError(Rpta);
                            }
                        }
                    }
                    this.Listar();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }



        private void ChkSeleccionar_CheckedChanged_1(object sender, EventArgs e)
        {
            if (ChkSeleccionar.Checked)
            {
                DgbListado.Columns[0].Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                DgbListado.Columns[0].Visible = false;
                btnEliminar.Visible = false;
            }

        }

        private void DgbListado_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgbListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgbListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void DgbListado_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                btnInsertar.Visible = false;
                TxtId.Text = Convert.ToString(DgbListado.CurrentRow.Cells["ID"].Value);
                TxtNombre.Text = Convert.ToString(DgbListado.CurrentRow.Cells["Nombre"].Value);
                this.nombreAnt = Convert.ToString(DgbListado.CurrentRow.Cells["Nombre"].Value);
                TxtTelefono.Text = Convert.ToString(DgbListado.CurrentRow.Cells["Telefono"].Value);
                TxtEmail.Text = Convert.ToString(DgbListado.CurrentRow.Cells["Email"].Value);
                tabControl1.SelectedIndex = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Selecciona desde la celda nombre." + "|Error: " + ex.Message);
            }
        }
    }
}