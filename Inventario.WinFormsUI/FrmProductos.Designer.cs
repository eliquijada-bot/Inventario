namespace Inventario.WinFormsUI
{
    partial class FrmProductos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            cboCategoria = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            txtProducto = new TextBox();
            label3 = new Label();
            txtPrecio = new TextBox();
            label4 = new Label();
            txtStock = new TextBox();
            btnNueva = new Button();
            btnEliminar = new Button();
            btnModificar = new Button();
            btnGuardar = new Button();
            dgvProductos = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            SuspendLayout();
            // 
            // cboCategoria
            // 
            cboCategoria.FormattingEnabled = true;
            cboCategoria.Location = new Point(28, 73);
            cboCategoria.Name = "cboCategoria";
            cboCategoria.Size = new Size(182, 33);
            cboCategoria.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(28, 32);
            label1.Name = "label1";
            label1.Size = new Size(88, 25);
            label1.TabIndex = 1;
            label1.Text = "Categoria";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 32);
            label2.Name = "label2";
            label2.Size = new Size(78, 25);
            label2.TabIndex = 2;
            label2.Text = "Nombre";
            // 
            // txtProducto
            // 
            txtProducto.Location = new Point(246, 75);
            txtProducto.Name = "txtProducto";
            txtProducto.Size = new Size(223, 31);
            txtProducto.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(28, 130);
            label3.Name = "label3";
            label3.Size = new Size(60, 25);
            label3.TabIndex = 4;
            label3.Text = "Precio";
            // 
            // txtPrecio
            // 
            txtPrecio.Location = new Point(28, 168);
            txtPrecio.Name = "txtPrecio";
            txtPrecio.Size = new Size(182, 31);
            txtPrecio.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(246, 130);
            label4.Name = "label4";
            label4.Size = new Size(55, 25);
            label4.TabIndex = 6;
            label4.Text = "Stock";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(246, 168);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(150, 31);
            txtStock.TabIndex = 7;
            // 
            // btnNueva
            // 
            btnNueva.Location = new Point(357, 228);
            btnNueva.Name = "btnNueva";
            btnNueva.Size = new Size(112, 34);
            btnNueva.TabIndex = 11;
            btnNueva.Text = "Nueva";
            btnNueva.UseVisualStyleBackColor = true;
            btnNueva.Click += btnNueva_Click;
            // 
            // btnEliminar
            // 
            btnEliminar.Location = new Point(236, 228);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(112, 34);
            btnEliminar.TabIndex = 10;
            btnEliminar.Text = "Eliminar";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(116, 228);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(112, 34);
            btnModificar.TabIndex = 9;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(28, 228);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(82, 34);
            btnGuardar.TabIndex = 8;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // dgvProductos
            // 
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Location = new Point(36, 287);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.Size = new Size(433, 263);
            dgvProductos.TabIndex = 12;
            dgvProductos.CellClick += dgvProductos_CellClick;
            // 
            // FrmProductos
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 584);
            Controls.Add(dgvProductos);
            Controls.Add(btnNueva);
            Controls.Add(btnEliminar);
            Controls.Add(btnModificar);
            Controls.Add(btnGuardar);
            Controls.Add(txtStock);
            Controls.Add(label4);
            Controls.Add(txtPrecio);
            Controls.Add(label3);
            Controls.Add(txtProducto);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cboCategoria);
            Name = "FrmProductos";
            Text = "FrmProductos";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cboCategoria;
        private Label label1;
        private Label label2;
        private TextBox txtProducto;
        private Label label3;
        private TextBox txtPrecio;
        private Label label4;
        private TextBox txtStock;
        private Button btnNueva;
        private Button btnEliminar;
        private Button btnModificar;
        private Button btnGuardar;
        private DataGridView dgvProductos;
    }
}