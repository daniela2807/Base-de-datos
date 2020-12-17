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
    public partial class FrmIngreso : Form
    {
        private DataTable DtDetalle = new DataTable();
        public FrmIngreso()
        {
            InitializeComponent();
        }

        public void crearTabla()
        {
            this.DtDetalle.Columns.Add("idarticulo", System.Type.GetType("System.Int16"));
            this.DtDetalle.Columns.Add("codigo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("articulo", System.Type.GetType("System.String"));
            this.DtDetalle.Columns.Add("cantidad", System.Type.GetType("System.Int16"));
            this.DtDetalle.Columns.Add("precio", System.Type.GetType("System.Decimal"));
            this.DtDetalle.Columns.Add("importe", System.Type.GetType("System.Decimal"));

            DgbDetalle.DataSource = this.DtDetalle;
            DgbDetalle.Columns[0].Visible = false;
            DgbDetalle.Columns[1].HeaderText = "CODIGO";
            DgbDetalle.Columns[1].Width= 100;
            DgbDetalle.Columns[2].HeaderText = "ARTICULO";
            DgbDetalle.Columns[2].Width = 200;
            DgbDetalle.Columns[3].HeaderText = "CANTIDAD";
            DgbDetalle.Columns[3].Width = 70;
            DgbDetalle.Columns[4].HeaderText = "PRECIO";
            DgbDetalle.Columns[4].Width = 70;
            DgbDetalle.Columns[5].HeaderText = "IMPORTE";
            DgbDetalle.Columns[5].Width = 80;

            DgbDetalle.Columns[1].ReadOnly = true;
            DgbDetalle.Columns[2].ReadOnly = true;
            DgbDetalle.Columns[5].ReadOnly = true;
        }

        private void FrmIngreso_Load(object sender, EventArgs e)
        {
            this.Listar();
            this.crearTabla();
        }

        private void Listar()
        {
            try
            {
                DgbListado.DataSource = NIngreso.Listar();
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
            DgbListado.Columns[1].Visible = false;
            DgbListado.Columns[2].Visible = false;
            DgbListado.Columns[0].Width = 100;
            DgbListado.Columns[1].Width = 60;
            DgbListado.Columns[3].Width = 150;
            DgbListado.Columns[4].Width = 150;
            DgbListado.Columns[5].Width = 100;
            DgbListado.Columns[5].HeaderText = "Documento";
            DgbListado.Columns[6].Width = 70;
            DgbListado.Columns[6].HeaderText = "Serie";
            DgbListado.Columns[7].Width = 70;
            DgbListado.Columns[7].HeaderText = "Numero";
            DgbListado.Columns[8].Width = 60;
            DgbListado.Columns[9].Width = 100;
            DgbListado.Columns[10].Width = 100;
            DgbListado.Columns[11].Width = 100;

        }

        private void Buscar()
        {
            try
            {
                DgbListado.DataSource = NIngreso.Buscar(TxtBuscar.Text);
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
            TxtId.Clear();
            TxtCodigo.Clear();
            TxtIdProveedor.Clear();
            TxtNombreProveedor.Clear();
            TxtSerieComprobante.Clear();
            TxtNumeroComprobante.Clear();
            DtDetalle.Clear();
            TxtSubtotal.Text = "0.00";
            TxtTotal.Text = "0.00";
            TxtTotalImpuesto.Text = "0.00";

            DgbListado.Columns[0].Visible = false;
            btnAnular.Visible = false;
            ChkSeleccionar.Checked = false;
        }

        public void FormatoArticulos()
        {
            DgbArticulos.Columns[1].Visible = false;
            DgbArticulos.Columns[2].Width = 100;
            DgbArticulos.Columns[2].HeaderText = "Categoria";
            DgbArticulos.Columns[3].Width = 100;
            DgbArticulos.Columns[3].HeaderText = "Codigo";
            DgbArticulos.Columns[4].Width = 150;
            DgbArticulos.Columns[5].Width = 100;
            DgbArticulos.Columns[5].HeaderText = "Precio Venta";
            DgbArticulos.Columns[6].Width = 60;
            DgbArticulos.Columns[7].Width = 200;
            DgbArticulos.Columns[7].HeaderText = "Descripcion";
            DgbArticulos.Columns[8].Width = 100;

        }

        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MensajeoOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Sistema de Ventas", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            try
            {
                string Rpta = "";
                string Segunda = "";
                if (TxtIdProveedor.Text == string.Empty || TxtImpuesto.Text == string.Empty || TxtNumeroComprobante.Text == string.Empty || DtDetalle.Rows.Count <= 0)
                {
                    this.MensajeError("Falta ingresar algunos datos, seran remarcados");
                    ErrorIcono.SetError(TxtIdProveedor, "Ingrese un Proveedor");
                    ErrorIcono.SetError(TxtImpuesto, "Ingrese un Impuesto");
                    ErrorIcono.SetError(TxtNumeroComprobante, "Ingrese un Numero de Comprobante");
                    ErrorIcono.SetError(DgbDetalle, "Ingrese un Detalle");
                }
                else
                {
                    Rpta = NIngreso.Insertar(Convert.ToInt16(TxtIdProveedor.Text), Variables.IdUsuario, CboComprobante.Text, TxtSerieComprobante.Text, TxtNumeroComprobante.Text, Convert.ToDecimal(TxtImpuesto.Text), Convert.ToDecimal(TxtTotal.Text));
                    foreach (DataRow FilaTemp in DtDetalle.Rows)
                    {
                        Segunda = NIngreso.InsertarDetalle(Convert.ToInt16(Rpta), Convert.ToInt16(FilaTemp["idarticulo"]), Convert.ToInt16(FilaTemp["cantidad"]), Convert.ToDouble(FilaTemp["precio"]));
                    }
                    if (Segunda.Equals("OK"))
                    {
                        this.MensajeoOk("Se inserto de forma correcta el registro");
                        Limpiar();
                        this.Listar();
                    }
                    else
                    {
                        this.MensajeError(Rpta);
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }

        private void buscarProveedor_Click(object sender, EventArgs e)
        {
            Vista_ProveedorIngreso vista = new Vista_ProveedorIngreso();
            vista.ShowDialog();
            TxtIdProveedor.Text = Convert.ToString(Variables.IdProveedor);
            TxtNombreProveedor.Text = Variables.NombreProveedor;
        }

        private void TxtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if(e.KeyCode == Keys.Enter)
                {
                    DataTable Tabla = new DataTable();
                    Tabla = NArticulo.BuscarCodigo(TxtCodigo.Text.Trim());
                    if (Tabla.Rows.Count <= 0 )
                    {
                        this.MensajeError("No existe articulo con ese codigo de barras");
                    }
                    else
                    {
                        this.AgregarDetalle(Convert.ToInt16(Tabla.Rows[0][0]), Convert.ToString(Tabla.Rows[0][1]), Convert.ToString(Tabla.Rows[0][2]), Convert.ToDecimal(Tabla.Rows[0][3]));
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AgregarDetalle(int IdArticulo, string Codigo, string Nombre, decimal Precio)
        {
            bool Agregar = true;


            foreach (DataRow FilaTemp in DtDetalle.Rows)
            {
                if(Convert.ToInt16(FilaTemp["idarticulo"]) == IdArticulo)
                {
                    Agregar = false;
                    this.MensajeError("El articulo ya se a agregado");
                }
            }
            if (Agregar)
            {
                DataRow fila = DtDetalle.NewRow();
                fila["idarticulo"] = IdArticulo;
                fila["codigo"] = Codigo;
                fila["articulo"] = Nombre;
                fila["cantidad"] = 1;
                fila["precio"] = Precio;
                fila["importe"] = Precio;
                this.DtDetalle.Rows.Add(fila);
                this.CalcularTotales();
            }
        }

        private void CalcularTotales()
        {
            decimal total = 0;
            decimal subtotal;

            if (DgbDetalle.Rows.Count == 0)
            {
                total = 0;
            }
            else
            {
                foreach (DataRow FilaTemp in DtDetalle.Rows)
                {
                    total = total + Convert.ToDecimal(FilaTemp["importe"]);
                }
            }
            subtotal = total / (1 + Convert.ToDecimal(TxtImpuesto.Text));
            TxtTotal.Text = total.ToString("#0.00#");
            TxtSubtotal.Text= subtotal.ToString("#0.00#");
            TxtTotalImpuesto.Text = (total - subtotal).ToString("0.00#");
           

        }

        private void BtnVerArticulo_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = true;
        }

        private void BtnCerrarArticulos_Click(object sender, EventArgs e)
        {
            PanelArticulos.Visible = false;
        }

        private void BtnFiltrar_Click(object sender, EventArgs e)
        {
            try
            {
                DgbArticulos.DataSource = NArticulo.Buscar(TxtBuscarArticulo.Text);
                this.FormatoArticulos();
                LblTotalArticulos.Text = "Total registros" + Convert.ToInt16(DgbArticulos.Rows.Count);

            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DgbArticulos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int IdArticulo;
            string Codigo;
            string Nombre;
            decimal Precio;
            IdArticulo = Convert.ToInt16(DgbArticulos.CurrentRow.Cells["ID"].Value);
            Codigo = Convert.ToString(DgbArticulos.CurrentRow.Cells["Codigo"].Value);
            Nombre = Convert.ToString(DgbArticulos.CurrentRow.Cells["Nombre"].Value);
            Precio = Convert.ToDecimal(DgbArticulos.CurrentRow.Cells["Precio_Venta"].Value);
            this.AgregarDetalle(IdArticulo,Codigo,Nombre,Precio);
        }

        private void DgbDetalle_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DataRow Fila = (DataRow)DtDetalle.Rows[e.RowIndex];
            decimal Precio = Convert.ToDecimal(Fila["precio"]);
            decimal cantidad = Convert.ToInt16(Fila["cantidad"]);
            Fila["importe"] = Precio * cantidad;
            this.CalcularTotales();
        }

        private void DgbDetalle_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            this.CalcularTotales();
        }

        private void DgbListado_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DgbMostrarDetalle.DataSource = NIngreso.ListarDetalle(Convert.ToInt16(DgbListado.CurrentRow.Cells["ID"].Value));
                decimal Total;
                decimal SubTotal;
                decimal Impuesto = Convert.ToDecimal(DgbListado.CurrentRow.Cells["Impuesto"].Value);
                Total = Convert.ToDecimal(DgbListado.CurrentRow.Cells["Total"].Value);
                SubTotal = Total / (1 + Impuesto);
                TxtTotalD.Text = Total.ToString("#0.00");
                TxtImpuestoD.Text = (Total - SubTotal).ToString("0.00");
                TxtSubTotalD.Text = SubTotal.ToString("#0.00");
                PanelDetalleIngreso.Visible = true;

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnCerrarDetalle_Click(object sender, EventArgs e)
        {
            PanelDetalleIngreso.Visible = false;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
            tabControl1.SelectedIndex = 0;
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
                btnAnular.Visible = true;
            }
            else
            {
                DgbListado.Columns[0].Visible = false;
                btnAnular.Visible = false;
            }
        }

        private void btnAnular_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("¿Realmente deseas anular el(los) registro?", "Sistema de Ventas", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    int Codigo;
                    string Rpta = "";
                    foreach (DataGridViewRow row in DgbListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToInt16(row.Cells[1].Value);
                            Rpta = NIngreso.Anular(Codigo);

                            if (Rpta.Equals("OK"))
                            {
                                this.MensajeoOk("Se activo el registo " + Convert.ToString(row.Cells[6].Value) +"-" + Convert.ToString(row.Cells[7].Value));
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
