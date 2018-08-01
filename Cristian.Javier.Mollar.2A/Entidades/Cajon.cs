using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
  
    public delegate void DelegadoPrecio(string rutaArchivo, float precio);

    [Serializable]public class Cajon<T> : ISerializable
    {
        private int _capacidad;
        private List<T> _frutas;
        private float _precioUnitario;
        private string _rutaArchivo;
        public event DelegadoPrecio EventoPrecio;

        public List<T> Frutas { get { return this._frutas; } }
        public float PrecioTotal { 
            get {
                float precio = 0;
                foreach (T item in this._frutas) {
                    precio = this._precioUnitario + precio;
                }
                if (precio > 25) {
                    this.EventoPrecio(this.RutaArchivo,precio);
                }
                return precio;
            } 
        }
        public string RutaArchivo {
            get { return this._rutaArchivo; }
            set { this._rutaArchivo = value; }
        }

        public Cajon() {
            this._frutas = new List<T>();
            this._rutaArchivo = "archivo.txt";
            this._capacidad = 0;
            this._precioUnitario = 0;
        }

        public Cajon(int capacidad) : this() {
            this._capacidad = capacidad;
        }

        public Cajon(int capacidad, float precio):this(capacidad) {
            this._precioUnitario = precio;
        }

        public static Cajon<T> operator +(Cajon<T> c, T f) {
            if (c._frutas.Count < c._capacidad)
            {
                c._frutas.Add(f);
            }
            else {
                throw new CajonLlenoException("El cajon esta lleno, no se pueden agregar frutas");
            }
            return c;
        }

        public override string ToString()
        {
            string retorno = "Capacidad del cajon: " + this._capacidad + "\nCantidad de futas: "
                +  this._frutas.Count + "\nPrecio Total: " + this.PrecioTotal + "\n";
            foreach (T item in this._frutas) {
                retorno += item.ToString() + "\n";
            }
            return retorno;
        }

       public bool SerializarXML()
        {
            bool retorno = false;
            try
            {
                string strPath = Environment.GetFolderPath(
                       System.Environment.SpecialFolder.DesktopDirectory);
                XmlTextWriter xml = new XmlTextWriter(strPath + "\\" + this.RutaArchivo, Encoding.UTF8);
                XmlSerializer xmlSerializado = new XmlSerializer(typeof(Cajon<T>));
                xmlSerializado.Serialize(xml,this);
                xml.Close();
                retorno = true;
            }
            catch (Exception e) {
                Console.WriteLine(e.Message);
            }
            return retorno;
        }
        public bool Deserealizar()
        {
            bool retorno = false;
            try
            {
                string strPath = Environment.GetFolderPath(
                       System.Environment.SpecialFolder.DesktopDirectory);
                Cajon<T> c = new Cajon<T>();
                XmlTextReader xml = new XmlTextReader(strPath + "\\" + this.RutaArchivo);
                XmlSerializer xmlSerializado = new XmlSerializer(typeof(Cajon<T>));
                c = (Cajon<T>)(xmlSerializado.Deserialize(xml));
                xml.Close();
                retorno = true;
            }
            catch (Exception e) { 
            
            }
            return retorno;
        }
        
    }
}
