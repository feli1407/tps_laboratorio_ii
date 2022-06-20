namespace FrmLocalDeVideoJuegos
{
    partial class FrmClienteVenta
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
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Apellido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSeleccionarCliente = new System.Windows.Forms.Label();
            this.grbBuscar = new System.Windows.Forms.GroupBox();
            this.btnBuscarPorID = new System.Windows.Forms.Button();
            this.txtBuscarID = new System.Windows.Forms.TextBox();
            this.lblBuscarPorID = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).BeginInit();
            this.grbBuscar.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvClientes
            // 
            this.dgvClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Nombre,
            this.Apellido});
            this.dgvClientes.Location = new System.Drawing.Point(12, 37);
            this.dgvClientes.Name = "dgvClientes";
            this.dgvClientes.RowTemplate.Height = 25;
            this.dgvClientes.Size = new System.Drawing.Size(344, 346);
            this.dgvClientes.TabIndex = 0;
            this.dgvClientes.DoubleClick += new System.EventHandler(this.dgvClientes_DoubleClick);
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            // 
            // Apellido
            // 
            this.Apellido.HeaderText = "Apellido";
            this.Apellido.Name = "Apellido";
            // 
            // lblSeleccionarCliente
            // 
            this.lblSeleccionarCliente.AutoSize = true;
            this.lblSeleccionarCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccionarCliente.Location = new System.Drawing.Point(12, 13);
            this.lblSeleccionarCliente.Name = "lblSeleccionarCliente";
            this.lblSeleccionarCliente.Size = new System.Drawing.Size(306, 21);
            this.lblSeleccionarCliente.TabIndex = 1;
            this.lblSeleccionarCliente.Text = "Seleccione el Cliente que realiza la compra:";
            // 
            // grbBuscar
            // 
            this.grbBuscar.Controls.Add(this.btnBuscarPorID);
            this.grbBuscar.Controls.Add(this.txtBuscarID);
            this.grbBuscar.Controls.Add(this.lblBuscarPorID);
            this.grbBuscar.Location = new System.Drawing.Point(12, 393);
            this.grbBuscar.Name = "grbBuscar";
            this.grbBuscar.Size = new System.Drawing.Size(344, 100);
            this.grbBuscar.TabIndex = 12;
            this.grbBuscar.TabStop = false;
            this.grbBuscar.Text = "Búsqueda";
            // 
            // btnBuscarPorID
            // 
            this.btnBuscarPorID.Location = new System.Drawing.Point(90, 51);
            this.btnBuscarPorID.Name = "btnBuscarPorID";
            this.btnBuscarPorID.Size = new System.Drawing.Size(160, 35);
            this.btnBuscarPorID.TabIndex = 10;
            this.btnBuscarPorID.Text = "Buscar";
            this.btnBuscarPorID.UseVisualStyleBackColor = true;
            this.btnBuscarPorID.Click += new System.EventHandler(this.btnBuscarPorID_Click);
            // 
            // txtBuscarID
            // 
            this.txtBuscarID.Location = new System.Drawing.Point(176, 22);
            this.txtBuscarID.Name = "txtBuscarID";
            this.txtBuscarID.Size = new System.Drawing.Size(74, 23);
            this.txtBuscarID.TabIndex = 8;
            // 
            // lblBuscarPorID
            // 
            this.lblBuscarPorID.AutoSize = true;
            this.lblBuscarPorID.Location = new System.Drawing.Point(90, 25);
            this.lblBuscarPorID.Name = "lblBuscarPorID";
            this.lblBuscarPorID.Size = new System.Drawing.Size(80, 15);
            this.lblBuscarPorID.TabIndex = 9;
            this.lblBuscarPorID.Text = "Buscar por ID:";
            // 
            // FrmClienteVenta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 505);
            this.ControlBox = false;
            this.Controls.Add(this.grbBuscar);
            this.Controls.Add(this.lblSeleccionarCliente);
            this.Controls.Add(this.dgvClientes);
            this.Name = "FrmClienteVenta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmClienteVenta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClientes)).EndInit();
            this.grbBuscar.ResumeLayout(false);
            this.grbBuscar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Apellido;
        private System.Windows.Forms.Label lblSeleccionarCliente;
        private System.Windows.Forms.GroupBox grbBuscar;
        private System.Windows.Forms.Button btnBuscarPorID;
        private System.Windows.Forms.TextBox txtBuscarID;
        private System.Windows.Forms.Label lblBuscarPorID;
    }
}