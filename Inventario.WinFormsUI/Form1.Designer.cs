namespace Inventario.WinFormsUI
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtNombreCategoria = new TextBox();
            btnGuardarCategoria = new Button();
            btnModificarCategoria = new Button();
            btnEliminarCategoria = new Button();
            btnNuevaCategoria = new Button();
            dgvCategorias = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(38, 27);
            label1.Name = "label1";
            label1.Size = new Size(159, 25);
            label1.TabIndex = 0;
            label1.Text = "Nombre Categoría";
            // 
            // txtNombreCategoria
            // 
            txtNombreCategoria.Location = new Point(38, 64);
            txtNombreCategoria.Name = "txtNombreCategoria";
            txtNombreCategoria.Size = new Size(441, 31);
            txtNombreCategoria.TabIndex = 1;
            // 
            // btnGuardarCategoria
            // 
            btnGuardarCategoria.Location = new Point(38, 121);
            btnGuardarCategoria.Name = "btnGuardarCategoria";
            btnGuardarCategoria.Size = new Size(82, 34);
            btnGuardarCategoria.TabIndex = 2;
            btnGuardarCategoria.Text = "Guardar";
            btnGuardarCategoria.UseVisualStyleBackColor = true;
            btnGuardarCategoria.Click += btnGuardarCategoria_Click;
            // 
            // btnModificarCategoria
            // 
            btnModificarCategoria.Location = new Point(126, 121);
            btnModificarCategoria.Name = "btnModificarCategoria";
            btnModificarCategoria.Size = new Size(112, 34);
            btnModificarCategoria.TabIndex = 3;
            btnModificarCategoria.Text = "Modificar";
            btnModificarCategoria.UseVisualStyleBackColor = true;
            btnModificarCategoria.Click += btnModificarCategoria_Click;
            // 
            // btnEliminarCategoria
            // 
            btnEliminarCategoria.Location = new Point(246, 121);
            btnEliminarCategoria.Name = "btnEliminarCategoria";
            btnEliminarCategoria.Size = new Size(112, 34);
            btnEliminarCategoria.TabIndex = 4;
            btnEliminarCategoria.Text = "Eliminar";
            btnEliminarCategoria.UseVisualStyleBackColor = true;
            btnEliminarCategoria.Click += btnEliminarCategoria_Click;
            // 
            // btnNuevaCategoria
            // 
            btnNuevaCategoria.Location = new Point(367, 121);
            btnNuevaCategoria.Name = "btnNuevaCategoria";
            btnNuevaCategoria.Size = new Size(112, 34);
            btnNuevaCategoria.TabIndex = 5;
            btnNuevaCategoria.Text = "Nueva";
            btnNuevaCategoria.UseVisualStyleBackColor = true;
            btnNuevaCategoria.Click += btnNuevaCategoria_Click;
            // 
            // dgvCategorias
            // 
            dgvCategorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategorias.Location = new Point(38, 194);
            dgvCategorias.Name = "dgvCategorias";
            dgvCategorias.RowHeadersWidth = 62;
            dgvCategorias.Size = new Size(441, 225);
            dgvCategorias.TabIndex = 6;
            dgvCategorias.CellClick += dgvCategorias_CellClick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvCategorias);
            Controls.Add(btnNuevaCategoria);
            Controls.Add(btnEliminarCategoria);
            Controls.Add(btnModificarCategoria);
            Controls.Add(btnGuardarCategoria);
            Controls.Add(txtNombreCategoria);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvCategorias).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtNombreCategoria;
        private Button btnGuardarCategoria;
        private Button btnModificarCategoria;
        private Button btnEliminarCategoria;
        private Button btnNuevaCategoria;
        private DataGridView dgvCategorias;
    }
}
