using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Entidades
{
    [Serializable]
    public class DepositoHeredado: Deposito,ISerializar,IDeserializar
    {
        public DepositoHeredado():base() {

        }

        public bool serializar()
        {
            bool retorno = true;
            try {
                XmlTextWriter xml = new XmlTextWriter(@"E:\javii\Documents\Facultad\serializado.xml", Encoding.UTF8);
                XmlSerializer xmlSerializado = new XmlSerializer(typeof(DepositoHeredado));
                xmlSerializado.Serialize(xml, this);
                xml.Close();
            } catch (Exception e) {
                retorno = false;
            }
            return retorno;
        }

        bool IDeserializar.deserializar(out DepositoHeredado dh)
        {
            dh = new DepositoHeredado();
            bool retorno = true;
            try
            {
                XmlTextReader xml = new XmlTextReader(@"E:\javii\Documents\Facultad\serializado.xml");
                XmlSerializer xmlSerializado = new XmlSerializer(typeof(DepositoHeredado));
                dh = (DepositoHeredado)(xmlSerializado.Deserialize(xml));
                xml.Close();
            }
            catch (Exception e) {
                retorno = false;
            }
            return retorno;
        }
    }
}
