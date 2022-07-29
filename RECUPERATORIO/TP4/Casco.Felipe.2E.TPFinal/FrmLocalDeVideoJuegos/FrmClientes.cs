using Entidades.Clases;
using Entidades.SQL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrmLocalDeVideoJuegos
{
    public partial class FrmClientes : Form
    {
        public FrmClientes()
        {
            InitializeComponent();
        }

        
        private void Clientes_Load(object sender, EventArgs e)
        {
            this.ActualizarDGVClientes();
        }

        /// <summary>
        /// Actualiza el Data Grid View de clientes con la lista de clientes de la base de datos.
        /// </summary>
        private void ActualizarDGVClientes()
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
        /// Carga en los text box los datos del cliente seleccionado con doble click.
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
                    this.txtNombre.Text = aux.Nombre;
                    this.txtApellido.Text = aux.Apellido;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Modifica al cliente seleccionado con los nuevos datos ingresados en el textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente aux = new Cliente(Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value),
                this.dgvClientes.CurrentRow.Cells[1].Value.ToString(), this.dgvClientes.CurrentRow.Cells[2].Value.ToString());
                aux.Nombre = this.txtNombre.Text;
                aux.Apellido = this.txtApellido.Text;
                VideoJuegoDAO.ModificarCliente(aux, aux.Id);
                this.ActualizarDGVClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Guarda todos los datos de clientes en la base de datos y llama a la funcion actualizardvgclientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarCliente_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente aux = new Cliente(this.txtNombre.Text, this.txtApellido.Text);
                VideoJuegoDAO.GuardarCliente(aux);
                this.ActualizarDGVClientes();
                MessageBox.Show("El cliente se añadio a la lista exitosamente.", "Clientes");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Elimina al cliente de la base de datos y llama a actualizardvgclientes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente aux = new Cliente(Convert.ToInt32(this.dgvClientes.CurrentRow.Cells[0].Value), this.dgvClientes.CurrentRow.Cells[1].Value.ToString(), this.dgvClientes.CurrentRow.Cells[2].Value.ToString());
                VideoJuegoDAO.BorrarCliente(aux.Id);
                this.ActualizarDGVClientes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        /// <summary>
        /// Busca un cliente por el id ingresado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnBuscarPorID_Click(object sender, EventArgs e)
        {
            if (this.txtBuscarID.Text is not null)
            {
                try
                {
                    int auxId = Convert.ToInt32(this.txtBuscarID.Text);
                    Cliente auxCliente = VideoJuegoDAO.LeerDatosPorIDCliente(auxId);
                    this.dgvClientes.Rows.Clear();
                    this.dgvClientes.Rows.Add();
                    this.dgvClientes.Rows[0].Cells[0].Value = auxCliente.Id;
                    this.dgvClientes.Rows[0].Cells[1].Value = auxCliente.Nombre;
                    this.dgvClientes.Rows[0].Cells[2].Value = auxCliente.Apellido;
                }
                catch (NullReferenceException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        /// <summary>
        /// Pregunta al usuario si desea cerrar este form y valida la respuesta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmClientes_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
            if (r == DialogResult.Yes)
            {
                this.DialogResult = DialogResult.Yes;
                e.Cancel = false;
            }
        }
    }
}
