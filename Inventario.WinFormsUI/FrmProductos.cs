using Inventario.Datos;
using Inventario.Entidades;
using Inventario.Negocio;

namespace Inventario.WinFormsUI
{
    public partial class FrmProductos : Form
    {
        private readonly ICategoriaBL _categoriaBL;
        private readonly IProductoBL _productoBL;
        private int _productoIdSeleccionado;

        public FrmProductos()
        {
            InitializeComponent();

            _categoriaBL = new CategoriaBL(new CategoriaDAL());
            _productoBL = new ProductoBL(new ProductoDAL());

            CargarProductosGrid();
            CargarCategoriasCombo();
        }

        private void ManejarError(Exception exception)
        {
            if (exception is BussinesException)
            {
                MessageBox.Show(
                    exception.Message,
                    "Validación",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
            else
            {
                MessageBox.Show(
                    "Ocurrión un error interno. Revise el log del sistema",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void CargarProductosGrid()
        {
            dgvProductos.DataSource = _productoBL.ListarConCategoria();
            if (dgvProductos.Columns["Id"] != null)
                dgvProductos.Columns["Id"].Visible = false;
            if (dgvProductos.Columns["CategoriaId"] != null)
                dgvProductos.Columns["CategoriaId"].Visible = false;
        }


        private void CargarCategoriasCombo()
        {
            cboCategoria.DataSource = _categoriaBL.Listar();
            cboCategoria.DisplayMember = "Nombre";
            cboCategoria.ValueMember = "Id";
            cboCategoria.SelectedIndex = -1;
        }

        private void LimpiarProducto()
        {
            _productoIdSeleccionado = 0;
            txtProducto.Clear();
            txtPrecio.Clear();
            txtStock.Clear();
            txtProducto.Focus();
            cboCategoria.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show(
                        "Precio inválido.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtPrecio.Focus();
                    return;
                }

                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    MessageBox.Show(
                        "Stock inválido.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtStock.Focus();
                    return;
                }

                if (cboCategoria.SelectedIndex < 0)
                {
                    MessageBox.Show(
                        "Seleccione una categoría.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cboCategoria.Focus();
                    return;
                }

                _productoBL.Guardar(new Producto
                {
                    Nombre = txtProducto.Text,
                    Precio = precio,
                    Stock = stock,
                    CategoriaId = Convert.ToInt32(cboCategoria.SelectedValue)
                });

                CargarProductosGrid();
                LimpiarProducto();

                MessageBox.Show(
                    "Producto guardado correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_productoIdSeleccionado <= 0)
                {
                    MessageBox.Show(
                        "Seleccione un producto para editar.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show(
                        "Precio inválido.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtPrecio.Focus();
                    return;
                }

                if (!int.TryParse(txtStock.Text, out int stock))
                {
                    MessageBox.Show(
                        "Stock inválido.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    txtStock.Focus();
                    return;
                }

                if (cboCategoria.SelectedIndex < 0)
                {
                    MessageBox.Show(
                        "Seleccione una categoría.",
                        "Validación",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    cboCategoria.Focus();
                    return;
                }

                _productoBL.Editar(new Producto
                {
                    Id = _productoIdSeleccionado,
                    Nombre = txtProducto.Text,
                    Precio = precio,
                    Stock = stock,
                    CategoriaId = Convert.ToInt32(cboCategoria.SelectedValue)
                });

                CargarProductosGrid();
                LimpiarProducto();

                MessageBox.Show(
                    "Producto actualizado correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (_productoIdSeleccionado <= 0)
                {
                    MessageBox.Show(
                        "Seleccione un producto para eliminar.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                DialogResult r = MessageBox.Show(
                    "¿Desea eliminar el producto seleccionado?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r != DialogResult.Yes)
                    return;

                _productoBL.Eliminar(_productoIdSeleccionado);

                CargarProductosGrid();
                LimpiarProducto();

                MessageBox.Show(
                    "Producto eliminado correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void btnNueva_Click(object sender, EventArgs e)
        {
            LimpiarProducto();
        }

        private void dgvProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow fila = dgvProductos.Rows[e.RowIndex];

                _productoIdSeleccionado = Convert.ToInt32(fila.Cells["Id"].Value);
                txtProducto.Text = fila.Cells["Nombre"].Value?.ToString() ?? string.Empty;
                txtPrecio.Text = fila.Cells["Precio"].Value?.ToString() ?? string.Empty;
                txtStock.Text = fila.Cells["Stock"].Value?.ToString() ?? string.Empty;

                if (fila.Cells["CategoriaId"].Value != null)
                    cboCategoria.SelectedValue = Convert.ToInt32(fila.Cells["CategoriaId"].Value);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }
    }
}
