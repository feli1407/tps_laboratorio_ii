using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();
        }

        private void FormCalculadora_Load(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        /// <summary>
        /// Establece en null los valores de los textbox 1 y 2, el del combobox de operadores y el label de resultados.
        /// </summary>
        private void Limpiar()
        {
            this.txtNumero1.Text = null;
            this.txtNumero2.Text = null;
            this.cboOperador.SelectedItem = null;
            this.lblResultado.Text = "0";
        }

        /// <summary>
        /// Realiza la operacion del numero 1 y 2 segun el operador.
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns>El resultado de la operacion</returns>
        static private double Operar(string numero1, string numero2, string operador)
        {
            double resultado = 0;
            char operadorChar;
            //se utiliza el operando(string)
            Operando num1 = new Operando(numero1);
            Operando num2 = new Operando(numero2);
            char.TryParse(operador, out operadorChar);
            resultado = Calculadora.Operar(num1, num2, operadorChar);

            return resultado;
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Convert.ToString(Operar(this.txtNumero1.Text, this.txtNumero2.Text, this.cboOperador.Text));

            StringBuilder sb = new StringBuilder();

            if (this.cboOperador.Text != "+" && this.cboOperador.Text != "-" && this.cboOperador.Text != "/" && this.cboOperador.Text != "*")
            {
                sb.AppendFormat($"{this.txtNumero1.Text}  +  {this.txtNumero2.Text} = {this.lblResultado.Text}");
                sb.AppendLine();
            }
            else
            {
                sb.AppendFormat($"{this.txtNumero1.Text}  {this.cboOperador.Text}  {this.txtNumero2.Text} = {this.lblResultado.Text}");
                sb.AppendLine();
            }


            this.lstOperaciones.Items.Add(sb.ToString());
        }

        private void FormCalculadora_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r = MessageBox.Show("¿Está seguro de querer salir?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (r == DialogResult.No)
            {
                e.Cancel = true;
            }
            if (r == DialogResult.Yes)
            {
                e.Cancel = false;
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.BinarioDecimal(this.lblResultado.Text);
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = Operando.DecimalBinario(this.lblResultado.Text);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }
    }
}
