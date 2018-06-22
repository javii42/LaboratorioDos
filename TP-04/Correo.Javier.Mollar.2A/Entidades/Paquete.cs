using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Entidades
{
    public enum EEstado
    {
        Ingresado,
        EnViaje,
        Entregado
    }
    public delegate void DelegadoEstado(object sender, EventArgs e);
    public class Paquete : IMostrar<Paquete>
    {
        private string _direccionEntrega;
        private EEstado _estado;
        private string _trackingID;

        public event DelegadoEstado InformaEstado ;

        #region propiedades
        public string DireccionEntrega
        {
            get
            {
                return this._direccionEntrega;
            }
            set
            {
                this._direccionEntrega = value;
            }
        }
        public EEstado Estado
        {
            get
            {
                return this._estado;
            }
            set
            {
                this._estado = value;
            }
        }
        public string TrackingID
        {
            get
            {
                return this._trackingID;
            }
            set
            {
                this._trackingID = value;
            }
        }
        #endregion

        public Paquete(string direccionEntrega, string trackindID)
        {
            this._direccionEntrega = direccionEntrega;
            this._trackingID = trackindID;}
        public void MockCicloDeVida()
        {
            while (Estado != EEstado.Entregado)
            {
                Thread.Sleep(10000);
                switch (Estado)
                {
                    case EEstado.Ingresado:
                        Estado = EEstado.EnViaje;
                        break;
                    case EEstado.EnViaje:
                    default:
                        Estado = EEstado.Entregado;
                        break;
                }
                this.InformaEstado(this, EventArgs.Empty);
            }
            try
            {
                PaqueteDAO.Insertar(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
              //  throw new Exception(ex.Message);
              
            }
        }

        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}, estado: {2}\n", TrackingID, DireccionEntrega, Estado);
        }

        public override string ToString()
        {
            return string.Format("{0} para {1}\n", TrackingID, DireccionEntrega);
        }

        public static bool operator ==(Paquete p1, Paquete p2)
        {
            bool retorno = false;
            if (p1.TrackingID == p2.TrackingID)
            {
                retorno = true;
            }
            return retorno;
        }

        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }

    }
}
