using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entidades;
using System;

namespace Testing
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ListaPaquetesInstanciada()
        {
            int count;
            Correo correo = new Correo();
            count = correo.Paquetes.Count;
        }
        [TestMethod]
        public void PaquetesConMismoTrackingID()
        {
            Correo correo = new Correo();
            Paquete p1 = new Paquete("Calle falsa 123", "xxx");
            Paquete p2 = new Paquete("Sarasa 123", "xxx");
            try
            {
                correo = correo + p1;
                correo = correo + p2;
            }
            catch (Exception e) {
                
            }
        }
    }
}
