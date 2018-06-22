using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        private static Correo correo;
        private static Paquete Paquete;
        public FrmPpal()
        {
            InitializeComponent();
            correo = new Correo();
            Application.ThreadException += new ThreadExceptionEventHandler(UIThreadException);
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += new UnhandledExceptionEventHandler(MyHandler);
            this.mTxtTrackingID.Focus();
           
        }

        private void ActualizarEstados() {
            lstEstadoEntregado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoIngresado.Items.Clear();
            foreach (Paquete item in correo.Paquetes) {
                switch (item.Estado) {
                    case EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;
                    case EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(item);
                        break;
                    case EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(item);
                        break;
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete = new Paquete(this.txtDireccion.Text,this.mTxtTrackingID.Text);
            Paquete.InformaEstado += paq_InformaEstado;
            try
            {
                correo = correo + Paquete;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (ThreadInterruptedException exc) {
                MessageBox.Show("Error DB", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }

            this.ActualizarEstados();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>) correo);
        }

        private void FrmPpal_FormClosing(object sendet, FormClosingEventArgs e) {
            correo.FinEntregas();
        }

        private void MostrarInformacion<T>(IMostrar<T> elemento) {
            if (elemento != null) {
                rtbMostar.Text = elemento.MostrarDatos(elemento);
                GuardaString.Guardar(rtbMostar.Text, "salida.txt");
            }
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {

            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }

        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
               DelegadoEstado d = new DelegadoEstado(paq_InformaEstado);
               this.Invoke(d, new object[] { sender, e });
            }
            else
            { this.ActualizarEstados(); }
        }
        static void MyHandler(object sender, UnhandledExceptionEventArgs args)
        {
            Exception e = (Exception)args.ExceptionObject;
            MessageBox.Show(e.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Application.ExitThread();
        }
        private static void UIThreadException(object sender, ThreadExceptionEventArgs t)
        {

     
            MessageBox.Show("ERROR!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
        

    }
}
