﻿using Entidades;
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
    public partial class FrmAgregarJuegoPlay : Form
    {
        public JuegoPlay juegoPlay;
        public FrmAgregarJuegoPlay()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Crea y asigna un nuevo juego de Play con los datos de los textbox y combobox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.txtNombre.Text) &&
               HerramientasForm.ValidarStringSoloNumeros(this.txtPrecioCompra.Text) > 0 &&
               HerramientasForm.ValidarStringSoloNumeros(this.txtCantidad.Text) > 0)
            {
                juegoPlay = new JuegoPlay(this.txtNombre.Text, Convert.ToInt32(this.txtPrecioCompra.Text), (EGenero)this.cboGenero.SelectedItem, this.chbExclusivoPlay.Checked ,Convert.ToInt32(this.txtCantidad.Text));
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Verifique que todos los datos ingresados sean validos.", "Error");
            }
        }

        private void FrmAgregarJuegoPlay_Load(object sender, EventArgs e)
        {
            this.cboGenero.Items.Add(EGenero.Estrategia);
            this.cboGenero.Items.Add(EGenero.Aventura);
            this.cboGenero.Items.Add(EGenero.Accion);
            this.cboGenero.Items.Add(EGenero.Deporte);
            this.cboGenero.Items.Add(EGenero.Musical);
        }
    }
}
