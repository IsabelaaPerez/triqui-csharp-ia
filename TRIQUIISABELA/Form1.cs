using System;
using System.Windows.Forms;
using Triqui;
using TRIQUIia;
 


namespace TRIQUIISABELA
{
    public partial class Form1 : Form
    {
        triqui3 Triquisito;
        IA TRIQUIia;
        public Form1()
        {
            InitializeComponent();
            Triquisito = new triqui3();
            TRIQUIia = new IA();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Triquisito.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TRIQUIia.ShowDialog();
        }
    }
}
