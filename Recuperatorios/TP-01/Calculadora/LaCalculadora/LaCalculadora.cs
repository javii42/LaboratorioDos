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
namespace LaCalculadora
{
    public partial class LaCalculadora : Form
    {
        private static Calculadora calculadora;
        private static Numero num1;
        private static Numero num2;
        public LaCalculadora()
        {
            InitializeComponent();
            calculadora = new Calculadora();
            this.cmbOperador.SelectedIndex = 0;
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            DialogResult option = MessageBox.Show("Desea cerrar la calculadora?",
                "La Calculadora",MessageBoxButtons.YesNo);
            if (option == DialogResult.Yes) {
                this.Close();
            }
        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {

            string numero = lblResultado.Text;
            string nDecimal;
            try
            {
                num1 = new Numero(numero);
                nDecimal = num1.DecimalBinario(numero);
                lblResultado.Text = nDecimal;
            }
            catch (Exception ex)
            {
                MessageBox.Show("El número a convertir no es decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string numero = lblResultado.Text;
            string nDecimal;
            try
            {
                num1 = new Numero(numero);
                nDecimal = num1.BinarioDecimal(numero);
                lblResultado.Text = nDecimal;
            }
            catch (Exception ex) {
                MessageBox.Show("El número a convertir no es binario","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.Limpiar();
        }

        private void btnOperar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = (LaCalculadora.Operador(
                this.txtNumero1.Text,
                this.txtNumero2.Text, 
                this.cmbOperador.SelectedItem.ToString())).ToString();
        }

        private void Limpiar() {
            this.lblResultado.Text = "0";
            this.cmbOperador.SelectedIndex = 0;
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
        }

        private static double Operador(string numero1, string numero2, string operador) {
            double resultado;
            num1 = new Numero(numero1);
            num2 = new Numero(numero2);
            resultado = calculadora.Operar(num1, num2, operador);   
            return resultado;
        }
        
    }
}
