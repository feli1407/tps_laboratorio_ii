using Entidades;
using Entidades.Clases;
using Entidades.Gestor_De_Archivos;
using Entidades.SQL;
using Entidades.Metodo_De_Extencion;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FrmLocalDeVideoJuegos
{
    public partial class FrmPrincipal : Form
    {
        LocalDeVideoJuegos local;
        int numeroDeVenta = 1;
        Reloj reloj;
        public FrmPrincipal()
        {
            InitializeComponent();
            this.local = new LocalDeVideoJuegos(30);
        }

        /// <summary>
        /// Agrego los items al combobox, inicializo el reloj, le asigno al evento la funcion AsignarHora y llamo a Iniciar
        /// , y llamo a la funcion ActualizarDGV.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            this.cboMostrar.Items.Add("Todos");
            this.cboMostrar.Items.Add("Play Station");
            this.cboMostrar.Items.Add("Xbox");
            this.cboMostrar.Items.Add("Nintendo");
            this.cboMostrar.SelectedIndex = 0;
            reloj = new Reloj();
            reloj.OnNotificarCambio += AsignarHora;
            reloj.Iniciar();
            ActualizarDGV();
        }

        /// <summary>
        /// Creo un delegado de tipo Action donde le asigno la funcion Asignar hora e hago un invoke del label donde
        /// va a mostrar la hora para que me permita trabajar con un hilo secundario al del programa principal.
        /// </summary>
        /// <param name="reloj"></param>
        private void AsignarHora(Reloj reloj)
        {
            if (lblHoraYFecha.InvokeRequired)
            {
                Action<Reloj> delegado = AsignarHora;
                lblHoraYFecha.Invoke(delegado, reloj);
            }
            else
            {
                lblHoraYFecha.Text = reloj.ToString();
            }
        }

        /// <summary>
        /// Acualizo el DGV agregando los videojuegos de la lista de videojuegos del local. Segun la opcion seleccionada
        /// en el combobox muestro todos, o los videojuegos separados por playstation, xbox, nintendo.
        /// </summary>
        private void ActualizarDGV()
        {
            List<JuegoPlay> juegosPlay = new List<JuegoPlay>();
            List<JuegoXbox> juegosXbox = new List<JuegoXbox>();
            List<JuegoNintendo> juegosNintendo = new List<JuegoNintendo>();
            local.AsignarPrecioVenta();
            this.dgvJuegos.Rows.Clear();
            local.VideoJuegos.Sort((x, y) => string.Compare(x.Nombre, y.Nombre));//Lambda

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

        /// <summary>
        /// Guarda todos los datos del local en un archivo XML en una carpeta en el escritorio y las listas de juegosplay, 
        /// juegosxbox y juegos nintendo en diferentes archivos JSON en otra carpeta en el escritorio.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarDatosArchivos_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Carga los archivos que tengamos en las carpetas creadas en el escritorio con la funcion guardar datos archivos
        /// en caso de no existir o que ocurra un error lanza una excepcion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarDatosArchivos_Click(object sender, EventArgs e)
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

        /// <summary>
        /// Agrega un juego de play a la lista de videojuegos del local y llama a la funcion ActualizarDVG.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Agrega un juego de xbox a la lista de videojuegos del local y llama a la funcion ActualizarDVG.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Agrega un juego de nintendo a la lista de videojuegos del local y llama a la funcion ActualizarDVG.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Le pregunta al usuario mediante un mensaje emergente si desea cerrar la aplicacion y en caso de que su 
        /// respuesta sea si, termina la aplicacion.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Elimina el videojuego seleccionado del DGV de la lista del local, de la DGV y de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

                            if (v is JuegoPlay)
                            {
                                VideoJuegoDAO.BorrarJuegoPlay(v.Nombre);
                            }
                            else if (v is JuegoXbox)
                            {
                                VideoJuegoDAO.BorrarJuegoXbox(v.Nombre);
                            }
                            else
                            {
                                VideoJuegoDAO.BorrarJuegoNintendo(v.Nombre);
                            }
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

        /// <summary>
        /// Abre un formulario para poder modificar el videojuego seleccionado del DGV, lo modifica en la lista de juegos del
        /// local y llama a la funcion ActualizarDVG.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Asigna el porcentaje de ganancia deseado al local y llama a la funcion ActualizarDVG.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        /// <summary>
        /// Valida que haya videojuegos ingresados en el local.
        /// </summary>
        /// <param name="local"></param>
        /// <returns></returns>
        private bool ValidarJuegosIngresados(LocalDeVideoJuegos local)
        {
            bool retorno = false;
            if (local.VideoJuegos.Count != 0)
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Cuando cambia la opcion seleccionada del combobox llama a la funcion ActualizarDVG para mostrar solo la opcion
        /// seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMostrar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.ActualizarDGV();
        }

        /// <summary>
        /// Abre un formulario para elegir el cliente que esta realizando la venta, y si hay stock del videojuego realiza la venta
        /// y guarda la factura en la carpeta TXT del escritorio con todos los datos del jeugo y del cliente. Tambien llama a la
        /// funcion ActualizarDVG para que se actualize el stock.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVender_Click(object sender, EventArgs e)
        {
            Cliente auxCliente = null;
            if (ValidarJuegosIngresados(local))
            {
                DialogResult r = MessageBox.Show("¿Está seguro que desea realizar la venta de este VideoJuego?", "Vender Juego", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (r == DialogResult.Yes)
                {
                    foreach (VideoJuego v in local.VideoJuegos)
                    {
                        FrmClienteVenta frmClienteVenta = new FrmClienteVenta();
                        frmClienteVenta.ShowDialog();
                        if (frmClienteVenta.DialogResult == DialogResult.Yes)
                        {
                            auxCliente = frmClienteVenta.cliente;
                        }

                        if (v.Nombre == this.dgvJuegos.CurrentRow.Cells[0].Value.ToString() &&
                            this.dgvJuegos.CurrentRow.Cells[4].Value.ToString() == VideoJuego.TipodDeVideoJuego(v))
                        {
                            if (v.Stock > 0)
                            {
                                v.Stock = v.Stock - 1;
                                try
                                {
                                    string factura = numeroDeVenta.CrearNombreFactura();
                                    numeroDeVenta++;
                                    ArchivoTexto archivoTexto = new ArchivoTexto();
                                    archivoTexto.Escribir(factura, v.DatosVenta() + auxCliente.ToString() + reloj.ToString());
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

        /// <summary>
        /// Abre un formulario de FrmClientes donde se cargan estos mismos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClientes_Click(object sender, EventArgs e)
        {
            FrmClientes frmClientes = new FrmClientes();
            frmClientes.ShowDialog();
            if (frmClientes.DialogResult == DialogResult.Yes)
            {
                MessageBox.Show("Se actualizaron los clientes correctamente.", "Clientes");
            }
        }

        /// <summary>
        /// Guarda los datos de los videojuegos en la base de datos, en 3 tablas diferentes segun corresponda el tipo de juego.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarDatosSQL_Click(object sender, EventArgs e)
        {
            List<JuegoPlay> juegosPlay = new List<JuegoPlay>();
            List<JuegoXbox> juegosXbox = new List<JuegoXbox>();
            List<JuegoNintendo> juegosNintendo = new List<JuegoNintendo>();

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

            try
            {
                foreach (JuegoPlay juegoPlay in juegosPlay)
                {
                    VideoJuegoDAO.GuardarJuegoPlay(juegoPlay);
                }

                foreach (JuegoXbox juegoXbox in juegosXbox)
                {
                    VideoJuegoDAO.GuardarJuegoXbox(juegoXbox);
                }

                foreach (JuegoNintendo juegoNintendo in juegosNintendo)
                {
                    VideoJuegoDAO.GuardarJuegoNintendo(juegoNintendo);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }

        }

        /// <summary>
        /// Levanta todos los juegos cargados de la base de datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCargarDatosSQL_Click(object sender, EventArgs e)
        {
            List<JuegoPlay> juegosPlay = new List<JuegoPlay>();
            List<JuegoXbox> juegosXbox = new List<JuegoXbox>();
            List<JuegoNintendo> juegosNintendo = new List<JuegoNintendo>();

            try
            {
                juegosPlay = VideoJuegoDAO.LeerJuegosPlay();
                juegosXbox = VideoJuegoDAO.LeerJuegosXbox();
                juegosNintendo = VideoJuegoDAO.LeerJuegosNintendo();
                foreach (JuegoPlay juegoPlay in juegosPlay)
                {
                    if (!LocalDeVideoJuegos.SeEncuentraEnLaLista(local.VideoJuegos, juegoPlay))
                    {
                        local.VideoJuegos.Add(juegoPlay);
                    }
                }
                foreach (JuegoXbox juegoXbox in juegosXbox)
                {
                    if (!LocalDeVideoJuegos.SeEncuentraEnLaLista(local.VideoJuegos, juegoXbox))
                    {
                        local.VideoJuegos.Add(juegoXbox);
                    }
                }
                foreach (JuegoNintendo juegoNintendo in juegosNintendo)
                {
                    if (!LocalDeVideoJuegos.SeEncuentraEnLaLista(local.VideoJuegos, juegoNintendo))
                    {
                        local.VideoJuegos.Add(juegoNintendo);
                    }
                }
                this.ActualizarDGV();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

    }
}
