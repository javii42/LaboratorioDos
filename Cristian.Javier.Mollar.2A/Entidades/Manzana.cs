using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable] public class Manzana: Fruta, ISerializable
    {
        public string paisOrigen;
        private string _rutaArchivo;
        public override bool TieneCarozo { get { return true; } }
        public string Tipo { get { return "Manzana"; } }

        public string RutaArchivo {
            get { return this._rutaArchivo; }
            set { this._rutaArchivo = value;}
        }

        protected override string FrutaToString()
        {
            return "Fruta:" + this.Tipo + "\nPais de Origen: "+ this.paisOrigen + "\n" + base.FrutaToString();
        }
        public Manzana() {
            this.paisOrigen = "Argentina";
        }
        public Manzana(float peso, ConsoleColor color, string pais) : base(peso, color) {
            this.paisOrigen = pais;
        }

        public override string ToString()
        {
            return this.FrutaToString();
        }

        public bool SerializarXML() {

            bool retorno = false;
            try
            {
                string strPath = Environment.GetFolderPath(
                       System.Environment.SpecialFolder.DesktopDirectory);
                XmlTextWriter xml = new XmlTextWriter(strPath + "\\" + this.RutaArchivo, Encoding.UTF8);
                XmlSerializer xmlSerializado = new XmlSerializer(typeof(Manzana));
                xmlSerializado.Serialize(xml, this);
                xml.Close();
                retorno = true;
            }
            catch (Exception e)
            {

            }
            return retorno;
        }
        public bool Deserealizar() {
            bool retorno = false;
            try
            {
                string strPath = Environment.GetFolderPath(
                       System.Environment.SpecialFolder.DesktopDirectory);
                Manzana m = new Manzana(0,ConsoleColor.Red,"");
               XmlTextReader xml = new XmlTextReader(strPath + "\\" +this.RutaArchivo);
                XmlSerializer xmlSerializado = new XmlSerializer(typeof(Manzana));
                m = (Manzana)(xmlSerializado.Deserialize(xml));
                xml.Close();
                retorno = true;
            }
            catch (Exception e)
            {

            }
            return retorno;
        }
    }
    }
