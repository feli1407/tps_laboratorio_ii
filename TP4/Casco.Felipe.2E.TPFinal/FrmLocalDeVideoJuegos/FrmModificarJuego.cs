using Entidades;
using Entidades.FuncionesForm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmLocalDeVideoJuegos
{
    public partial class FrmModificarJuego : Form
    {
        public VideoJuego videoJuego;
        public FrmModificarJuego(VideoJuego videoJuego)
        {
            InitializeComponent();
            this.videoJuego = videoJuego;   
        }

        /// <summary>
        /// Modifica el juego seleccionado con los nuevos datos ingresados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.txtNombre.Text) &&
               HerramientasForm.ValidarStringSoloNumeros(this.txtPrecioCompra.Text) != 0)
            {
                videoJuego.Nombre = this.txtNombre.Text;
                videoJuego.PrecioCompra = Convert.ToInt32(this.txtPrecioCompra.Text);
                videoJuego.Genero = (EGenero)this.cboGenero.SelectedIndex;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Verifique que todos los datos ingresados sean validos.", "Error");
            }
        }

        private void FrmModificarJuego_Load(object sender, EventArgs e)
        {
            this.cboGenero.Items.Add(EGenero.Estrategia);
            this.cboGenero.Items.Add(EGenero.Aventura);
            this.cboGenero.Items.Add(EGenero.Accion);
            this.cboGenero.Items.Add(EGenero.Deporte);
            this.cboGenero.Items.Add(EGenero.Musical);
            this.cboGenero.SelectedIndex = ((int)this.videoJuego.Genero);
            this.txtNombre.Text = this.videoJuego.Nombre;
            this.txtPrecioCompra.Text = this.videoJuego.PrecioCompra.ToString();
        }
    }
}
