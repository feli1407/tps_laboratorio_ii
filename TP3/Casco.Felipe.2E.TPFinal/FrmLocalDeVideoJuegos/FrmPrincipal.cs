using Entidades;
using Entidades.Gestor_De_Archivos;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrmLocalDeVideoJuegos
{
    public partial class FrmPrincipal : Form
    {
        LocalDeVideoJuegos local;
        int numeroDeVenta = 1;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.local = new LocalDeVideoJuegos(30);

        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.cboMostrar.Items.Add("Todos");
            this.cboMostrar.Items.Add("Play Station");
            this.cboMostrar.Items.Add("Xbox");
            this.cboMostrar.Items.Add("Nintendo");
            this.cboMostrar.SelectedIndex = 0;
            ActualizarDGV();
        }

        private void ActualizarDGV()
        {
            List<JuegoPlay> juegosPlay = new List<JuegoPlay>();
            List<JuegoXbox> juegosXbox = new List<JuegoXbox>();
            List<JuegoNintendo> juegosNintendo = new List<JuegoNintendo>();
            local.AsignarPrecioVenta();
            this.dgvJuegos.Rows.Clear();
            local.VideoJuegos.Sort((x, y) => string.Compare(x.Nombre, y.Nombre));

            foreach (var juego in local.VideoJuegos)
            {
                if (juego is JuegoPlay)
                {
                    juegosPlay.Add((JuegoPlay)juego);
                }
                else if (juego is JuegoXbox)
                {
                    juegosXbox.Add((JuegoXbox)juego);
                }
                else
                {
                    juegosNintendo.Add((JuegoNintendo)juego);
                }
            }

            int n;

            switch (this.cboMostrar.SelectedIndex)
            {
                case 0:
                    foreach (VideoJuego juego in local.VideoJuegos)
                    {
                        n = this.dgvJuegos.Rows.Add();

                        this.dgvJuegos.Rows[n].Cells[0].Value = juego.Nombre;
                        this.dgvJuegos.Rows[n].Cells[1].Value = juego.Genero;
                        this.dgvJuegos.Rows[n].Cells[2].Value = juego.PrecioCompra;
                        this.dgvJuegos.Rows[n].Cells[3].Value = juego.PrecioVenta;
                        this.dgvJuegos.Rows[n].Cells[4].Value = VideoJuego.TipodDeVideoJuego(juego);
                        this.dgvJuegos.Rows[n].Cells[5].Value = juego.Stock;
                    }
                    break;
                case 1:
                    foreach (JuegoPlay juego in juegosPlay)
                    {
                        n = this.dgvJuegos.Rows.Add();

                        this.dgvJuegos.Rows[n].Cells[0].Value = juego.Nombre;
                        this.dgvJuegos.Rows[n].Cells[1].Value = juego.Genero;
                        this.dgvJuegos.Rows[n].Cells[2].Value = juego.PrecioCompra;
                        this.dgvJuegos.Rows[n].Cells[3].Value = juego.PrecioVenta;
                        this.dgvJuegos.Rows[n].Cells[4].Value = VideoJuego.TipodDeVideoJuego(juego);
                        this.dgvJuegos.Rows[n].Cells[5].Value = juego.Stock;
                    }
                    break;
                case 2:
                    foreach (JuegoXbox juego in juegosXbox)
                    {
                        n = this.dgvJuegos.Rows.Add();

                        this.dgvJuegos.Rows[n].Cells[0].Value = juego.Nombre;
                        this.dgvJuegos.Rows[n].Cells[1].Value = juego.Genero;
                        this.dgvJuegos.Rows[n].Cells[2].Value = juego.PrecioCompra;
                        this.dgvJuegos.Rows[n].Cells[3].Value = juego.PrecioVenta;
                        this.dgvJuegos.Rows[n].Cells[4].Value = VideoJuego.TipodDeVideoJuego(juego);
                        this.dgvJuegos.Rows[n].Cells[5].Value = juego.Stock;
                    }
                    break;
                case 3:
                    foreach (JuegoNintendo juego in juegosNintendo)
                    {
                        n = this.dgvJuegos.Rows.Add();

                        this.dgvJuegos.Rows[n].Cells[0].Value = juego.Nombre;
                        this.dgvJuegos.Rows[n].Cells[1].Value = juego.Genero;
                        this.dgvJuegos.Rows[n].Cells[2].Value = juego.PrecioCompra;
                        this.dgvJuegos.Rows[n].Cells[3].Value = juego.PrecioVenta;
                        this.dgvJuegos.Rows[n].Cells[4].Value = VideoJuego.TipodDeVideoJuego(juego);
                        this.dgvJuegos.Rows[n].Cells[5].Value = juego.Stock;
                    }
                    break;
            }
        }

        private void btnGuardarDatos_Click(object sender, EventArgs e)
        {
            int valorTotalJuegos = 0;
            List<JuegoPlay> juegosPlay = new List<JuegoPlay>();
            List<JuegoXbox> juegosXbox = new List<JuegoXbox>();
            List<JuegoNintendo> juegosNintendo = new List<JuegoNintendo>();

            if (ValidarJuegosIngresados(local))
            {
                DialogResult r = MessageBox.Show("¿Está seguro que desea guardar los datos de esta lista? Tenga en cuenta que se sobreescribiran los datos guardados anteriormente", "Guardar Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (r == DialogResult.Yes)
                {
                    try
                    {
                        Serializer<LocalDeVideoJuegos> serializadorXML = new Serializer<LocalDeVideoJuegos>(GestorDeArchivo.ETipo.XML);
                        serializadorXML.Escribir("localdevideojuegos.xml", local);

                        foreach (var juego in local.VideoJuegos)
                        {
                            if (juego is JuegoPlay)
                            {
                                juegosPlay.Add((JuegoPlay)juego);
                            }
                            else if (juego is JuegoXbox)
                            {
                                juegosXbox.Add((JuegoXbox)juego);
                            }
                            else
                            {
                                juegosNintendo.Add((JuegoNintendo)juego);
                            }
                        }

                        Serializer<List<JuegoPlay>> serializadorPlayJSON = new Serializer<List<JuegoPlay>>(GestorDeArchivo.ETipo.JSON);
                        serializadorPlayJSON.Escribir("juegosPlay.json", juegosPlay);

                        Serializer<List<JuegoXbox>> serializadorXboxJSON = new Serializer<List<JuegoXbox>>(GestorDeArchivo.ETipo.JSON);
                        serializadorXboxJSON.Escribir("juegosXbox.json", juegosXbox);

                        Serializer<List<JuegoNintendo>> serializadorNintendoJSON = new Serializer<List<JuegoNintendo>>(GestorDeArchivo.ETipo.JSON);
                        serializadorNintendoJSON.Escribir("juegosNintendo.json", juegosNintendo);

                        foreach (VideoJuego v in local.VideoJuegos)
                        {
                            valorTotalJuegos += v.PrecioCompra * v.Stock;
                        }
                        ArchivoTexto archivoTexto = new ArchivoTexto();
                        archivoTexto.Escribir("StockLocalVideoJuegos.txt", local.Mostrar() + $"\nEl costo total de los videojuegos es: {valorTotalJuegos}");

                        MessageBox.Show("Los datos se guardaron correctamente.", "Guardar Datos");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error");
                    }
                }
                else
                {
                    MessageBox.Show("Primero debe cargar Video Juegos para poder utilizar esta opcion.", "Error");
                }
            }
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            try
            {
                Serializer<LocalDeVideoJuegos> serializadorXML = new Serializer<LocalDeVideoJuegos>(GestorDeArchivo.ETipo.XML);
                this.local = serializadorXML.Leer("localdevideojuegos.xml");
                this.ActualizarDGV();
                MessageBox.Show("Los datos se cargaron correctamente.", "Cargar Datos");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private void btnAgregarPlay_Click(object sender, EventArgs e)
        {
            FrmAgregarJuegoPlay frmAgregarJuegoPlay = new FrmAgregarJuegoPlay();
            if (frmAgregarJuegoPlay.ShowDialog() == DialogResult.OK)
            {
                local.VideoJuegos.Add(frmAgregarJuegoPlay.juegoPlay);
                this.ActualizarDGV();
                MessageBox.Show("El juego se agrego correctamente.", "Agregar Juego de Play Station");
            }
        }

        private void btnAgregarXbox_Click(object sender, EventArgs e)
        {
            FrmAgregarJuegoXbox frmAgregarJuegoXbox = new FrmAgregarJuegoXbox();
            if (frmAgregarJuegoXbox.ShowDialog() == DialogResult.OK)
            {
                local.VideoJuegos.Add(frmAgregarJuegoXbox.juegoXbox);
                this.ActualizarDGV();
                MessageBox.Show("El juego se agrego correctamente.", "Agregar Juego de Xbox");
            }
        }

        private void btnAgregarNintendo_Click(object sender, EventArgs e)
        {
            FrmAgregarJuegoNintendo frmAgregarJuegoNintendo = new FrmAgregarJuegoNintendo();
            if (frmAgregarJuegoNintendo.ShowDialog() == DialogResult.OK)
            {
                local.VideoJuegos.Add(frmAgregarJuegoNintendo.juegoNintendo);
                this.ActualizarDGV();
                MessageBox.Show("El juego se agrego correctamente.", "Agregar Juego de Nintendo");
            }
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
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

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (ValidarJuegosIngresados(local))
            {
                DialogResult r = MessageBox.Show("¿Está seguro que desea eliminar este juego de la lista?", "Eliminar Juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    foreach (VideoJuego v in local.VideoJuegos)
                    {
                        if (v.Nombre == this.dgvJuegos.CurrentRow.Cells[0].Value.ToString() &&
                            this.dgvJuegos.CurrentRow.Cells[4].Value.ToString() == VideoJuego.TipodDeVideoJuego(v))
                        {
                            local.VideoJuegos.Remove(v);
                            break;
                        }
                    }
                    dgvJuegos.Rows.RemoveAt(dgvJuegos.CurrentRow.Index);
                }
            }
            else
            {
                MessageBox.Show("Primero debe cargar Video Juegos para poder utilizar esta opcion.", "Error");
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidarJuegosIngresados(local))
            {
                DialogResult r = MessageBox.Show("¿Está seguro que desea modificar este juego de la lista?", "Modificar Juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    foreach (VideoJuego v in local.VideoJuegos)
                    {
                        if (v.Nombre == this.dgvJuegos.CurrentRow.Cells[0].Value.ToString() &&
                            this.dgvJuegos.CurrentRow.Cells[4].Value.ToString() == VideoJuego.TipodDeVideoJuego(v))
                        {
                            FrmModificarJuego frmModificar = new FrmModificarJuego(v);
                            if (frmModificar.ShowDialog() == DialogResult.OK)
                            {
                                v.Nombre = frmModificar.videoJuego.Nombre;
                                v.PrecioCompra = frmModificar.videoJuego.PrecioCompra;
                                v.Genero = frmModificar.videoJuego.Genero;

                                this.ActualizarDGV();
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero debe cargar Video Juegos para poder utilizar esta opcion.", "Error");
            }

        }

        private void btnAsignarGanancia_Click(object sender, EventArgs e)
        {
            if (ValidarJuegosIngresados(local))
            {
                try
                {
                    this.local.PorcentajeGanancia = Convert.ToInt32(this.txbPorcentajeGanancia.Text);
                    this.ActualizarDGV();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error");
                }
            }
            else
            {
                MessageBox.Show("Primero debe cargar Video Juegos para poder utilizar esta opcion.", "Error");
            }

        }

        private bool ValidarJuegosIngresados(LocalDeVideoJuegos local)
        {
            bool retorno = false;
            if (local.VideoJuegos.Count != 0)
            {
                retorno = true;
            }
            return retorno;
        }

        private void cboMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActualizarDGV();
        }

        private void btnVender_Click(object sender, EventArgs e)
        {
            if (ValidarJuegosIngresados(local))
            {
                DialogResult r = MessageBox.Show("¿Está seguro que desea realizar la venta de este VideoJuego?", "Eliminar Juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    foreach (VideoJuego v in local.VideoJuegos)
                    {
                        if (v.Nombre == this.dgvJuegos.CurrentRow.Cells[0].Value.ToString() &&
                            this.dgvJuegos.CurrentRow.Cells[4].Value.ToString() == VideoJuego.TipodDeVideoJuego(v))
                        {
                            if (v.Stock > 0)
                            {
                                v.Stock = v.Stock - 1;
                                try
                                {
                                    string factura = "factura" + numeroDeVenta + ".txt";
                                    numeroDeVenta++;
                                    ArchivoTexto archivoTexto = new ArchivoTexto();
                                    archivoTexto.Escribir(factura, v.DatosVenta());
                                    this.ActualizarDGV();

                                    MessageBox.Show("Venta realizada correctamente, se guardo la factura en la carpeta TXT del escritorio.", "Venta");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message, "Error");
                                }
                                break;
                            }
                            else
                            {
                                MessageBox.Show("No hay stock de este VideoJuego para vender en este momento.", "Error");
                                break;
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Primero debe cargar Video Juegos para poder utilizar esta opcion.", "Error");
            }
        }
    }
}
