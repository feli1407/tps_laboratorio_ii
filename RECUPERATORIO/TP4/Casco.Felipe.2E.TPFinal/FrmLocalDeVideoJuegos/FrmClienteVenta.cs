using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.SQL;
using Entidades.Clases;

namespace FrmLocalDeVideoJuegos
{
    public partial class FrmClienteVenta : Form
    {
        public Cliente cliente = null;

        public FrmClienteVenta()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cargo el data grid view con la lista de clientes de la base de datos.
        /// </summary>
        private void ActualizarDGVClientesVenta()
        {
            try
            {
                int n;
                List<Cliente> listaClientes = VideoJuegoDAO.LeerCliente();
                this.dgvClientes.Rows.Clear();

                foreach (Cliente cliente in listaClientes)
                {
                    n = this.dgvClientes.Rows.Add();

                    this.dgvClientes.Rows[n].Cells[0].Value = cliente.Id;
                    this.dgvClientes.Rows[n].Cells[1].Value = cliente.Nombre;
                    this.dgvClientes.Rows[n].Cells[2].Value = cliente.Apellido;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Llama a la funcion que actualiza el data grid view
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClienteVenta_Load(object sender, EventArgs e)
        {
            this.ActualizarDGVClientesVenta();
        }

        /// <summary>
        /// Busca por id el cliente deseado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarPorID_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtBuscarID.Text is not null)
                {
                    int auxId = Convert.ToInt32(this.txtBuscarID.Text);
                    Cliente auxCliente = VideoJuegoDAO.LeerDatosPorIDCliente(auxId);
                    this.dgvClientes.Rows.Clear();
                    this.dgvClientes.Rows.Add();
                    this.dgvClientes.Rows[0].Cells[0].Value = auxCliente.Id;
                    this.dgvClientes.Rows[0].Cells[1].Value = auxCliente.Nombre;
                    this.dgvClientes.Rows[0].Cells[2].Value = auxCliente.Apellido;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Carga el cliente seleccionado en la variable cliente y cierra el form.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvClientes_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Cliente aux = new Cliente(Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value),
                this.dgvClientes.CurrentRow.Cells[1].Value.ToString(), this.dgvClientes.CurrentRow.Cells[2].Value.ToString());
                if (aux != null)
                {
                    this.cliente = aux;
                    this.DialogResult = DialogResult.Yes;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmClienteVenta_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.Yes)
            {
                DialogResult r = MessageBox.Show("¿Está seguro de querer salir? La venta no se llevara a cabo", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.No)
                {
                    e.Cancel = true;
                }
                if (r == DialogResult.Yes)
                {
                    e.Cancel = false;
                }
            }
        }

        private void BtnAgregarCliente_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
            if (frmClientes.DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Se actualizaron los clientes correctamente.", "Clientes");
            }
            this.ActualizarDGVClientesVenta();
        }
    }
}
