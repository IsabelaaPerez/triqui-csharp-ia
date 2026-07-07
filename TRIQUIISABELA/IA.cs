using System;
using System.Windows.Forms;
using TRIQUIISABELA;


namespace TRIQUIia
{
    public partial class IA : Form
    {
        TresEnRaya iA = new TresEnRaya();
        private int[,] matriz = new int[2,2];
        private int ganador = -1;
        //Matriz para las medidad del tablero (en mi caso los botones)
        //-1 no hay ganador todavia , la inicializacion de la variable ganador
        
        public IA()
        {
            InitializeComponent();
            iA.inicializarPartida();
            matriz = iA.Matriz;

        }

        private void comprobarGanador()
        {
            int[] ultMov = iA.UltimoMovimientoMaquina;

            //Mira el ultimo movimiento de la ia

            if (ultMov[0] == 0 && ultMov[1] == 0)
                button1.Text = "0";
            if (ultMov[0] == 0 && ultMov[1] == 1)
                button2.Text = "0";
            if (ultMov[0] == 0 && ultMov[1] == 2)
                button3.Text = "0";

            if (ultMov[0] == 1 && ultMov[1] == 0)
                button4.Text = "0";
            if (ultMov[0] == 1 && ultMov[1] == 1)
                button5.Text = "0";
            if (ultMov[0] == 1 && ultMov[1] == 2)
                button6.Text = "0";

            if (ultMov[0] == 2 && ultMov[1] == 0)
                button7.Text = "0";
            if (ultMov[0] == 2 && ultMov[1] == 1)
                button8.Text = "0";
            if (ultMov[0] == 2 && ultMov[1] == 2)
                button9.Text = "0";

            if (ganador == 0) MessageBox.Show("GANASTE");
            if (ganador == 1) MessageBox.Show("PERDISTE");
            if (ganador == -1 && iA.tableroLleno())
                MessageBox.Show("EMPATE");
        }
        private void eventoBotones(int x, int y, Button boton)
        {
            if (matriz[x, y] == -1)
            {

                iA.seleccionarPosicion(x, y);
                ganador = iA.ganaPartida();
                comprobarGanador();
                boton.Text = "x";
            }
        }
       // private void IA_Load(object sender, EventArgs e)
        //{

        //}

      
        
        //Se les da la posiscion a los botones, cordenadas de la matriz
        private void button1_Click(object sender, EventArgs e)
        {
            eventoBotones(0, 0, button1);
        }

       
        private void button2_Click(object sender, EventArgs e)
        {
            eventoBotones(0, 1, button2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            eventoBotones(0, 2, button3);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            eventoBotones(1,0 , button4);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            eventoBotones(1,1, button5);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            eventoBotones(1, 2, button6);

        }
        private void button7_Click(object sender, EventArgs e)
        {
            eventoBotones(2,0, button7);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            eventoBotones(2, 1, button8);

        }

        private void button9_Click(object sender, EventArgs e)
        {
            eventoBotones(2, 2, button9);

        }

        private void button10_Click(object sender, EventArgs e)
        {
            //Inicializar las cosas
            iA = new TresEnRaya();
            iA.inicializarPartida();
            matriz = iA.Matriz;
            ganador = -1;
            button1.Text = button2.Text = button3.Text = button4.Text = button5.Text = button6.Text = button7.Text = button8.Text = button9.Text = String.Empty;

        }
    }

    
}
