using Inventario.Datos;
using Inventario.Negocio;
using Inventario.Entidades;

namespace Inventario.WinFormsUI
{
    public partial class Form1 : Form
    {
        private readonly ICategoriaBL _categoriaBL;

        private int _categoriaIdSeleccionada;
        public Form1()
        {
            InitializeComponent();
            _categoriaBL = new CategoriaBL(new CategoriaDAL());

            CargarCategoriasGrid();
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
        private void CargarCategoriasGrid()
        {
            dgvCategorias.DataSource = _categoriaBL.Listar();
            if (dgvCategorias.Columns["Id"] != null)
                dgvCategorias.Columns["Id"].Visible = false;
        }

        private void LimpiarCategoria()
        {
            _categoriaIdSeleccionada = 0;
            txtNombreCategoria.Clear();
            txtNombreCategoria.Focus();
        }

        private void btnGuardarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                _categoriaBL.Guardar(new Categoria
                {
                    Nombre = txtNombreCategoria.Text
                });

                CargarCategoriasGrid();

                MessageBox.Show(
                    "Categoria guardad Correctamente",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void btnModificarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (_categoriaIdSeleccionada <= 0)
                {
                    MessageBox.Show(
                        "Seleccione una categoría para editar.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                _categoriaBL.Editar(new Categoria
                {
                    Id = _categoriaIdSeleccionada,
                    Nombre = txtNombreCategoria.Text
                });

                CargarCategoriasGrid();

                MessageBox.Show(
                    "Categoría actualizada correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void btnEliminarCategoria_Click(object sender, EventArgs e)
        {
            try
            {
                if (_categoriaIdSeleccionada <= 0)
                {
                    MessageBox.Show(
                        "Seleccione una categoría para eliminar.",
                        "Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                DialogResult r = MessageBox.Show(
                    "¿Desea eliminar la categoría seleccionada?",
                    "Confirmar eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (r != DialogResult.Yes)
                    return;

                _categoriaBL.Eliminar(_categoriaIdSeleccionada);

                CargarCategoriasGrid();

                MessageBox.Show(
                    "Categoría eliminada correctamente.",
                    "Información",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void dgvCategorias_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0) return;

                DataGridViewRow fila = dgvCategorias.Rows[e.RowIndex];

                _categoriaIdSeleccionada = Convert.ToInt32(fila.Cells["Id"].Value);
                txtNombreCategoria.Text = fila.Cells["Nombre"].Value?.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                ManejarError(ex);
            }
        }

        private void btnNuevaCategoria_Click(object sender, EventArgs e)
        {
            LimpiarCategoria();
        }
    }
}
