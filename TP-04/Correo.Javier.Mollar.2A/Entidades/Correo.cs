using System;
using System.Collections.Generic;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        private List<Thread> _mockPaquetes;
        private List<Paquete> _paquetes;

        public List<Paquete> Paquetes
        {
            get
            {
                return this._paquetes;
            }
        }

        public Correo()
        {
            this._paquetes = new List<Paquete>();
            this._mockPaquetes = new List<Thread>();
        }

        public void FinEntregas()
        {
            foreach (Thread t in this._mockPaquetes)
            {
                t.Abort();
            }
        }

        public string MostrarDatos(IMostrar<List<Paquete>> elementos)
        {
            string retorno = "";
            foreach (Paquete p in this.Paquetes)
            {
                retorno += string.Format("{0} para {1} ({2})\n", p.TrackingID, p.DireccionEntrega, p.Estado.ToString());
            }
            return retorno;
        }

        public static Correo operator +(Correo c, Paquete p)
        {
            Exception exc = null;
            foreach (Paquete item in c.Paquetes)
            {
                if (item == p)
                {
                    throw new TrackingIdRepetidoException("El paquete ya existe");
                }
            }
            c.Paquetes.Add(p);
            try
            {
                Thread t = new Thread(new ThreadStart(p.MockCicloDeVida));
                // Thread t = new Thread(() => SafeExecute(() => p.MockCicloDeVida(), Handler));
                c._mockPaquetes.Add(t);
                t.Start();
            }
            catch (Exception ex) {
               
            }
            return c;
        }
    }
}
