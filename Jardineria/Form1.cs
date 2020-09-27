using Entidades;
using Negocio;

using System;
using System.Windows.Forms;

namespace Jardineria
{
    public partial class Form1 : Form
    {
        Tienda tienda = new Tienda();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Pago p = new Pago(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, dateTimePicker1.Value, decimal.Parse(textBox4.Text));
            tienda.InsertarPago(p);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.DataSource = tienda.ObtenerPagos();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pago p = new Pago(int.Parse(textBox1.Text), textBox2.Text, textBox3.Text, dateTimePicker1.Value, decimal.Parse(textBox4.Text));
            listBox1.Items.Clear();
            listBox1.Items.Add(tienda.ActualizarPago(p));

        }
    }
}
