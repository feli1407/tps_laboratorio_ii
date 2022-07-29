namespace FrmLocalDeVideoJuegos
{
    partial class FrmPrincipal
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
            this.dgvJuegos = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Genero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrecioVenta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Consola = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAgregarPlay = new System.Windows.Forms.Button();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.lblPorcentajeDeGananciaDeseado = new System.Windows.Forms.Label();
            this.txbPorcentajeGanancia = new System.Windows.Forms.TextBox();
            this.btnCargarDatosArchivos = new System.Windows.Forms.Button();
            this.btnGuardarDatosArchivos = new System.Windows.Forms.Button();
            this.btnVender = new System.Windows.Forms.Button();
            this.btnAgregarXbox = new System.Windows.Forms.Button();
            this.btnAgregarNintendo = new System.Windows.Forms.Button();
            this.btnAsignarGanancia = new System.Windows.Forms.Button();
            this.grbAgregar = new System.Windows.Forms.GroupBox();
            this.grbMostrar = new System.Windows.Forms.GroupBox();
            this.cboMostrar = new System.Windows.Forms.ComboBox();
            this.lblMostrar = new System.Windows.Forms.Label();
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnCargarDatosSQL = new System.Windows.Forms.Button();
            this.lblHoraYFecha = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvJuegos)).BeginInit();
            this.grbAgregar.SuspendLayout();
            this.grbMostrar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvJuegos
            // 
            this.dgvJuegos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvJuegos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Genero,
            this.PrecioCompra,
            this.PrecioVenta,
            this.Consola,
            this.Stock});
            this.dgvJuegos.Location = new System.Drawing.Point(357, 7);
            this.dgvJuegos.Name = "dgvJuegos";
            this.dgvJuegos.ReadOnly = true;
            this.dgvJuegos.RowTemplate.Height = 25;
            this.dgvJuegos.Size = new System.Drawing.Size(643, 411);
            this.dgvJuegos.TabIndex = 0;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Genero
            // 
            this.Genero.HeaderText = "Genero";
            this.Genero.Name = "Genero";
            this.Genero.ReadOnly = true;
            // 
            // PrecioCompra
            // 
            this.PrecioCompra.HeaderText = "Precio Compra";
            this.PrecioCompra.Name = "PrecioCompra";
            this.PrecioCompra.ReadOnly = true;
            // 
            // PrecioVenta
            // 
            this.PrecioVenta.HeaderText = "Precio Venta";
            this.PrecioVenta.Name = "PrecioVenta";
            this.PrecioVenta.ReadOnly = true;
            // 
            // Consola
            // 
            this.Consola.HeaderText = "Consola";
            this.Consola.Name = "Consola";
            this.Consola.ReadOnly = true;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Stock";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // btnAgregarPlay
            // 
            this.btnAgregarPlay.Location = new System.Drawing.Point(6, 22);
            this.btnAgregarPlay.Name = "btnAgregarPlay";
            this.btnAgregarPlay.Size = new System.Drawing.Size(158, 34);
            this.btnAgregarPlay.TabIndex = 1;
            this.btnAgregarPlay.Text = "Agregar Juego Play";
            this.btnAgregarPlay.UseVisualStyleBackColor = true;
            this.btnAgregarPlay.Click += new System.EventHandler(this.btnAgregarPlay_Click);
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(7, 175);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(158, 34);
            this.btnBorrar.TabIndex = 2;
            this.btnBorrar.Text = "Borrar Juego";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(176, 175);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(158, 34);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar Juego";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // lblPorcentajeDeGananciaDeseado
            // 
            this.lblPorcentajeDeGananciaDeseado.AutoSize = true;
            this.lblPorcentajeDeGananciaDeseado.Location = new System.Drawing.Point(7, 347);
            this.lblPorcentajeDeGananciaDeseado.Name = "lblPorcentajeDeGananciaDeseado";
            this.lblPorcentajeDeGananciaDeseado.Size = new System.Drawing.Size(182, 15);
            this.lblPorcentajeDeGananciaDeseado.TabIndex = 8;
            this.lblPorcentajeDeGananciaDeseado.Text = "Porcentaje de Ganancia Deseado:";
            // 
            // txbPorcentajeGanancia
            // 
            this.txbPorcentajeGanancia.Location = new System.Drawing.Point(193, 344);
            this.txbPorcentajeGanancia.Name = "txbPorcentajeGanancia";
            this.txbPorcentajeGanancia.Size = new System.Drawing.Size(30, 23);
            this.txbPorcentajeGanancia.TabIndex = 9;
            this.txbPorcentajeGanancia.Text = "30";
            this.txbPorcentajeGanancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnCargarDatosArchivos
            // 
            this.btnCargarDatosArchivos.Location = new System.Drawing.Point(7, 255);
            this.btnCargarDatosArchivos.Name = "btnCargarDatosArchivos";
            this.btnCargarDatosArchivos.Size = new System.Drawing.Size(158, 34);
            this.btnCargarDatosArchivos.TabIndex = 10;
            this.btnCargarDatosArchivos.Text = "Cargar Datos Archivos";
            this.btnCargarDatosArchivos.UseVisualStyleBackColor = true;
            this.btnCargarDatosArchivos.Click += new System.EventHandler(this.btnCargarDatosArchivos_Click);
            // 
            // btnGuardarDatosArchivos
            // 
            this.btnGuardarDatosArchivos.Location = new System.Drawing.Point(176, 255);
            this.btnGuardarDatosArchivos.Name = "btnGuardarDatosArchivos";
            this.btnGuardarDatosArchivos.Size = new System.Drawing.Size(158, 34);
            this.btnGuardarDatosArchivos.TabIndex = 11;
            this.btnGuardarDatosArchivos.Text = "Guardar Datos Archivos";
            this.btnGuardarDatosArchivos.UseVisualStyleBackColor = true;
            this.btnGuardarDatosArchivos.Click += new System.EventHandler(this.btnGuardarDatosArchivos_Click);
            // 
            // btnVender
            // 
            this.btnVender.Location = new System.Drawing.Point(176, 215);
            this.btnVender.Name = "btnVender";
            this.btnVender.Size = new System.Drawing.Size(158, 34);
            this.btnVender.TabIndex = 12;
            this.btnVender.Text = "Vender VideoJuego";
            this.btnVender.UseVisualStyleBackColor = true;
            this.btnVender.Click += new System.EventHandler(this.btnVender_Click);
            // 
            // btnAgregarXbox
            // 
            this.btnAgregarXbox.Location = new System.Drawing.Point(6, 62);
            this.btnAgregarXbox.Name = "btnAgregarXbox";
            this.btnAgregarXbox.Size = new System.Drawing.Size(158, 34);
            this.btnAgregarXbox.TabIndex = 13;
            this.btnAgregarXbox.Text = "Agregar Juego Xbox";
            this.btnAgregarXbox.UseVisualStyleBackColor = true;
            this.btnAgregarXbox.Click += new System.EventHandler(this.btnAgregarXbox_Click);
            // 
            // btnAgregarNintendo
            // 
            this.btnAgregarNintendo.Location = new System.Drawing.Point(6, 102);
            this.btnAgregarNintendo.Name = "btnAgregarNintendo";
            this.btnAgregarNintendo.Size = new System.Drawing.Size(158, 34);
            this.btnAgregarNintendo.TabIndex = 14;
            this.btnAgregarNintendo.Text = "Agregar Juego Nintendo";
            this.btnAgregarNintendo.UseVisualStyleBackColor = true;
            this.btnAgregarNintendo.Click += new System.EventHandler(this.btnAgregarNintendo_Click);
            // 
            // btnAsignarGanancia
            // 
            this.btnAsignarGanancia.Location = new System.Drawing.Point(176, 295);
            this.btnAsignarGanancia.Name = "btnAsignarGanancia";
            this.btnAsignarGanancia.Size = new System.Drawing.Size(158, 34);
            this.btnAsignarGanancia.TabIndex = 15;
            this.btnAsignarGanancia.Text = "Asignar Ganancia";
            this.btnAsignarGanancia.UseVisualStyleBackColor = true;
            this.btnAsignarGanancia.Click += new System.EventHandler(this.btnAsignarGanancia_Click);
            // 
            // grbAgregar
            // 
            this.grbAgregar.Controls.Add(this.btnAgregarPlay);
            this.grbAgregar.Controls.Add(this.btnAgregarXbox);
            this.grbAgregar.Controls.Add(this.btnAgregarNintendo);
            this.grbAgregar.Location = new System.Drawing.Point(12, 12);
            this.grbAgregar.Name = "grbAgregar";
            this.grbAgregar.Size = new System.Drawing.Size(175, 143);
            this.grbAgregar.TabIndex = 16;
            this.grbAgregar.TabStop = false;
            this.grbAgregar.Text = "Agregar";
            // 
            // grbMostrar
            // 
            this.grbMostrar.Controls.Add(this.cboMostrar);
            this.grbMostrar.Controls.Add(this.lblMostrar);
            this.grbMostrar.Location = new System.Drawing.Point(193, 12);
            this.grbMostrar.Name = "grbMostrar";
            this.grbMostrar.Size = new System.Drawing.Size(141, 143);
            this.grbMostrar.TabIndex = 17;
            this.grbMostrar.TabStop = false;
            this.grbMostrar.Text = "Mostrar";
            // 
            // cboMostrar
            // 
            this.cboMostrar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMostrar.FormattingEnabled = true;
            this.cboMostrar.Location = new System.Drawing.Point(10, 73);
            this.cboMostrar.Name = "cboMostrar";
            this.cboMostrar.Size = new System.Drawing.Size(121, 23);
            this.cboMostrar.TabIndex = 18;
            this.cboMostrar.SelectedIndexChanged += new System.EventHandler(this.cboMostrar_SelectedIndexChanged);
            // 
            // lblMostrar
            // 
            this.lblMostrar.AutoSize = true;
            this.lblMostrar.Location = new System.Drawing.Point(10, 41);
            this.lblMostrar.Name = "lblMostrar";
            this.lblMostrar.Size = new System.Drawing.Size(123, 15);
            this.lblMostrar.TabIndex = 18;
            this.lblMostrar.Text = "Mostrar VideoJuegos: ";
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(7, 215);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(158, 34);
            this.btnClientes.TabIndex = 18;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnCargarDatosSQL
            // 
            this.btnCargarDatosSQL.Location = new System.Drawing.Point(7, 295);
            this.btnCargarDatosSQL.Name = "btnCargarDatosSQL";
            this.btnCargarDatosSQL.Size = new System.Drawing.Size(158, 34);
            this.btnCargarDatosSQL.TabIndex = 19;
            this.btnCargarDatosSQL.Text = "Cargar Datos SQL";
            this.btnCargarDatosSQL.UseVisualStyleBackColor = true;
            this.btnCargarDatosSQL.Click += new System.EventHandler(this.btnCargarDatosSQL_Click);
            // 
            // lblHoraYFecha
            // 
            this.lblHoraYFecha.AutoSize = true;
            this.lblHoraYFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHoraYFecha.Location = new System.Drawing.Point(7, 372);
            this.lblHoraYFecha.Name = "lblHoraYFecha";
            this.lblHoraYFecha.Size = new System.Drawing.Size(52, 21);
            this.lblHoraYFecha.TabIndex = 21;
            this.lblHoraYFecha.Text = "label1";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 432);
            this.Controls.Add(this.lblHoraYFecha);
            this.Controls.Add(this.btnCargarDatosSQL);
            this.Controls.Add(this.btnClientes);
            this.Controls.Add(this.grbMostrar);
            this.Controls.Add(this.grbAgregar);
            this.Controls.Add(this.btnAsignarGanancia);
            this.Controls.Add(this.btnVender);
            this.Controls.Add(this.btnGuardarDatosArchivos);
            this.Controls.Add(this.btnCargarDatosArchivos);
            this.Controls.Add(this.txbPorcentajeGanancia);
            this.Controls.Add(this.lblPorcentajeDeGananciaDeseado);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnBorrar);
            this.Controls.Add(this.dgvJuegos);
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Next Level Video Juegos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvJuegos)).EndInit();
            this.grbAgregar.ResumeLayout(false);
            this.grbMostrar.ResumeLayout(false);
            this.grbMostrar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvJuegos;
        private System.Windows.Forms.Button btnAgregarPlay;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Label lblPorcentajeDeGananciaDeseado;
        private System.Windows.Forms.TextBox txbPorcentajeGanancia;
        private System.Windows.Forms.Button btnCargarDatosArchivos;
        private System.Windows.Forms.Button btnGuardarDatosArchivos;
        private System.Windows.Forms.Button btnVender;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Genero;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrecioVenta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Consola;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.Button btnAgregarXbox;
        private System.Windows.Forms.Button btnAgregarNintendo;
        private System.Windows.Forms.Button btnAsignarGanancia;
        private System.Windows.Forms.GroupBox grbAgregar;
        private System.Windows.Forms.GroupBox grbMostrar;
        private System.Windows.Forms.ComboBox cboMostrar;
        private System.Windows.Forms.Label lblMostrar;
        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnCargarDatosSQL;
        private System.Windows.Forms.Label lblHoraYFecha;
    }
}
