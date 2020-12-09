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
using System.Drawing.Imaging;
using System.IO;

namespace Sistema.Presentacion
{
    public partial class FrmArticulo : Form
    {
        private string RutaOrigen;
        private string RutaDestino;
        private string Directorio = "D:\\Sistema\\";
        private string NombreAnt;


        public FrmArticulo()
        {
            InitializeComponent();
        }

        private void Listar()
        {
            try
            {
                DgbListado.DataSource = NArticulo.Listar();
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
            DgbListado.Columns[2].Visible = false;
            DgbListado.Columns[0].Width = 100;
            DgbListado.Columns[1].Width = 50;
            DgbListado.Columns[3].Width = 100;
            DgbListado.Columns[3].HeaderText = "Categoria";
            DgbListado.Columns[4].Width = 100;
            DgbListado.Columns[4].HeaderText = "Codigo";
            DgbListado.Columns[5].Width = 150;
            DgbListado.Columns[6].Width = 100;
            DgbListado.Columns[6].HeaderText = "Precio Venta";
            DgbListado.Columns[7].Width = 60;
            DgbListado.Columns[8].Width = 200;
            DgbListado.Columns[8].HeaderText = "Descripcion";
            DgbListado.Columns[8].Width = 100;

        }

        private void Buscar()
        {
            try
            {
                DgbListado.DataSource = NArticulo.Buscar(TxtBuscar.Text);
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
            TxtDescripcion.Clear();
            TxtId.Clear();
            TxtCodigo.Clear();
            TxtPrecioVenta.Clear();
            TxtStock.Clear();
            TxtImagen.Clear();
            PanelCodigo.BackgroundImage = null;
            btnGuardarCodigo.Enabled = true;
            PicImagen.Image = null;
            this.RutaDestino = "";
            this.RutaOrigen = "";
            TxtNombre.Clear();
            BtnInsertar.Visible = true;
            btnActualizar.Visible = false;
            ErrorIcono.Clear();
            DgbListado.Columns[0].Visible = false;
            btnActivar.Visible = false;
            btnDesactivar.Visible = false;
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

        private void CargarCategoria()
        {
            try
            {
                CboCategoria.DataSource = NCategoria.Seleccionar();
                CboCategoria.ValueMember = "idcategoria";
                CboCategoria.DisplayMember = "nombre";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.CargarCategoria();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void BtnCargarImagen_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            if (file.ShowDialog() == DialogResult.OK)
            {
                PicImagen.Image = Image.FromFile(file.FileName);
                TxtImagen.Text = file.FileName.Substring(file.FileName.LastIndexOf("\\")+1);
                this.RutaOrigen = file.FileName;
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void BtnGenerar_Click(object sender, EventArgs e)
        {
            BarcodeLib.Barcode codigo = new BarcodeLib.Barcode();
            codigo.IncludeLabel = true;
            PanelCodigo.BackgroundImage = codigo.Encode(BarcodeLib.TYPE.CODE128, TxtCodigo.Text, Color.Black, Color.White, 350,110);
            btnGuardarCodigo.Enabled = true;
        }

        private void btnGuardarCodigo_Click(object sender, EventArgs e)
        {
            Image imgFinal = (Image)PanelCodigo.BackgroundImage.Clone();

            SaveFileDialog DialogoGuardar = new SaveFileDialog();
            DialogoGuardar.AddExtension = true;
            DialogoGuardar.Filter = "Image PNG (*.png)|*.png";
            DialogoGuardar.ShowDialog();
            if(!string.IsNullOrEmpty(DialogoGuardar.FileName))
            {
                imgFinal.Save(DialogoGuardar.FileName, ImageFormat.Png);
            }
            imgFinal.Dispose();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabControl1.SelectedIndex = 0;
        }

        private void CboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if(CboCategoria.Text == string.Empty || TxtNombre.Text == string.Empty || TxtPrecioVenta.Text == string.Empty || TxtStock.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, seran remarcados.");
                    ErrorIcono.SetError(CboCategoria, "Seleccione una categoria");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(TxtPrecioVenta, "Ingrese un precio.");
                    ErrorIcono.SetError(TxtStock, "Ingrese un stock inicial.");
                }
                else
                {
                    Rpta = NArticulo.Insertar(Convert.ToInt16(CboCategoria.SelectedValue), TxtCodigo.Text.Trim(), TxtNombre.Text.Trim(),Convert.ToDecimal(TxtPrecioVenta.Text), Convert.ToInt16(TxtStock.Text), TxtDescripcion.Text.Trim(), TxtImagen.Text.Trim());
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeoOk("Se inserto de forma correcta el registro");
                        if(TxtImagen.Text != string.Empty)
                        {
                            this.RutaDestino = this.Directorio + TxtImagen.Text;
                            File.Copy(this.RutaOrigen, this.RutaDestino);
                        }
                        this.Listar();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void DgbListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.Limpiar();
                btnActualizar.Visible = true;
                BtnInsertar.Visible = false;
                TxtId.Text = Convert.ToString(DgbListado.CurrentRow.Cells["ID"].Value);
                CboCategoria.SelectedValue = Convert.ToString(DgbListado.CurrentRow.Cells["idcategoria"].Value);
                TxtCodigo.Text = Convert.ToString(DgbListado.CurrentRow.Cells["Codigo"].Value);
                this.NombreAnt = Convert.ToString(DgbListado.CurrentRow.Cells["Nombre"].Value);
                TxtNombre.Text = Convert.ToString(DgbListado.CurrentRow.Cells["Nombre"].Value);
                TxtPrecioVenta.Text = Convert.ToString(DgbListado.CurrentRow.Cells["Precio_Venta"].Value);
                TxtStock.Text = Convert.ToString(DgbListado.CurrentRow.Cells["Stock"].Value);
                TxtDescripcion.Text = Convert.ToString(DgbListado.CurrentRow.Cells["Descripcion"].Value);
                string imagen;
                imagen = TxtImagen.Text = Convert.ToString(DgbListado.CurrentRow.Cells["Imagen"].Value);
                if(imagen != String.Empty)
                {
                    PicImagen.Image = Image.FromFile(this.Directorio + imagen);
                    TxtImagen.Text = imagen;
                }
                else
                {
                    PicImagen.Image = null;
                    TxtImagen.Text = "";
                }
                tabControl1.SelectedIndex = 1;
            }
            catch(Exception ex)
            {
                MessageBox.Show("Selecciona desde la celda nombre." + "|Error: "+ ex.Message);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                if (TxtId.Text == string.Empty || CboCategoria.Text == string.Empty || TxtNombre.Text == string.Empty || TxtPrecioVenta.Text == string.Empty || TxtStock.Text == string.Empty)
                {
                    this.MensajeError("Falta ingresar algunos datos, seran remarcados.");
                    ErrorIcono.SetError(CboCategoria, "Seleccione una categoria");
                    ErrorIcono.SetError(TxtNombre, "Ingrese un nombre.");
                    ErrorIcono.SetError(TxtPrecioVenta, "Ingrese un precio.");
                    ErrorIcono.SetError(TxtStock, "Ingrese un stock inicial.");
                }
                else
                {
                    Rpta = NArticulo.Actualizar(Convert.ToInt16(TxtId.Text), Convert.ToInt16(CboCategoria.SelectedValue), TxtCodigo.Text.Trim(), TxtNombre.Text.Trim(), Convert.ToDecimal(TxtPrecioVenta.Text), Convert.ToInt16(TxtStock.Text), TxtDescripcion.Text.Trim(), TxtImagen.Text.Trim());
                 
                    if (Rpta.Equals("OK"))
                    {
                        this.MensajeoOk("Se actualizo de forma correcta el registro");
                        if (TxtImagen.Text != string.Empty && this.RutaOrigen != string.Empty)
                        {
                            this.RutaDestino = this.Directorio + TxtImagen.Text;
                            File.Copy(this.RutaOrigen, this.RutaDestino);
                        }
                        this.Listar();
                        tabControl1.SelectedIndex = 0;
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

        private void DgbListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DgbListado.Columns["Seleccionar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)DgbListado.Rows[e.RowIndex].Cells["Seleccionar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }

        private void ChkSeleccionar_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeleccionar.Checked)
            {
                DgbListado.Columns[0].Visible = true;
                btnActivar.Visible = true;
                btnDesactivar.Visible = true;
                btnEliminar.Visible = true;
            }
            else
            {
                DgbListado.Columns[0].Visible = false;
                btnActivar.Visible = false;
                btnDesactivar.Visible = false;
                btnEliminar.Visible = false;
            }
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
                    string imagen = "";
                    foreach (DataGridViewRow row in DgbListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt16(row.Cells[1].Value);
                            imagen = Convert.ToString(row.Cells[9].Value);
                            Rpta = NArticulo.Eliminar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeoOk("Se elimino el registo " + Convert.ToString(row.Cells[5].Value));
                                File.Delete(this.Directorio + imagen);
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

        private void btnDesactivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente deseas desactivar el(los) registro?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in DgbListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt16(row.Cells[1].Value);
                            Rpta = NArticulo.Desactivar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeoOk("Se desactivo el registo " + Convert.ToString(row.Cells[5].Value));
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

        private void btnActivar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente deseas activar el(los) registro?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in DgbListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt16(row.Cells[1].Value);
                            Rpta = NArticulo.Activar(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeoOk("Se activo el registo " + Convert.ToString(row.Cells[5].Value));
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
    }
}
