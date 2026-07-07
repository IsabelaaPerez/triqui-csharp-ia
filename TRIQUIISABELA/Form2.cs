using System;
using System.Windows.Forms;

namespace Triqui
{

    public partial class triqui3 : Form
    {
        bool cambio = true;

        int empate = 0;

        //   public TriquiMulti()
        int ganadasX = 0;
        int ganadasO = 0;
        public triqui3()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            Ingresar();
        }

        private void Ingresar()
        {
            if (rbtnUserRX.Checked && rbtnUserVO.Checked)
            {


                rbtnUserRO.Enabled = false;
                rbtnUserVX.Enabled = false;
                PlayGame();
            }
            if (rbtnUserRO.Checked && rbtnUserVX.Checked)
            {

                rbtnUserRX.Enabled = false;
                rbtnUserVO.Enabled = false;
                PlayGame();
            }
            if (rbtnUserRX.Checked && rbtnUserVX.Checked)
            {

                MessageBox.Show("DOS JUGADORES NO PUEDEN ELEJIR LA X");
            }
            if (rbtnUserRO.Checked && rbtnUserVO.Checked)
            {

                MessageBox.Show("DOS JUGADORES NO PUEDEN ELEJIR LA O");
            }
            if (rbtnUserRX.Checked == false && rbtnUserRO.Checked == false || rbtnUserVX.Checked == false && rbtnUserVO.Checked == false)
            {
                MessageBox.Show("CADA JUGADOR DEBE SELECCIONAR UNA LETRA");
            }
        }

        private void OnOffBtn(bool onoff)    // este es el metodo, en donde estamos desactivando la variable 
        {
            a1.Enabled = onoff;
            a2.Enabled = onoff;
            a3.Enabled = onoff;

            b1.Enabled = onoff;
            b2.Enabled = onoff;
            b3.Enabled = onoff;

            c1.Enabled = onoff;
            c2.Enabled = onoff;
            c3.Enabled = onoff;

        }

        private void PlayGame()
        {
            groupBox1.Text = "Marcador";

            btnReiniciar.Visible = true;

            btnIniciar.Visible = false;

            OnOffBtn(true);
        }

        private void triqui_Load(object sender, EventArgs e)
        {
            OnOffBtn(false); // con esto llamamos al metodo que nos ayudara a que no se inicien los botones al momento de ejecutar el programa
        }

        private void ButtonsClick(object sender, EventArgs e)
        {
            Button b = ((Button)sender);
            if (cambio)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }
            cambio = !cambio;
            b.Enabled = false;
            Partida();
        }

        private void Partida()
        {
            if ((a1.Text == a2.Text) & (a2.Text == a3.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((b1.Text == b2.Text) & (b2.Text == b3.Text) && (!b1.Enabled))
            {
                Validacion(b1);
            }
            else if ((c1.Text == c2.Text) & (c2.Text == c3.Text) && (!c1.Enabled))
            {
                Validacion(c1);
            }

            if ((a1.Text == b1.Text) & (b1.Text == c1.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }

            else if ((a2.Text == b2.Text) & (b2.Text == c2.Text) && (!a2.Enabled))
            {
                Validacion(a2);
            }
            else if ((a3.Text == b3.Text) & (b3.Text == c3.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }

            if ((a1.Text == b2.Text) & (b2.Text == c3.Text) && (!a1.Enabled))
            {
                Validacion(a1);
            }
            else if ((a3.Text == b2.Text) & (b2.Text == c1.Text) && (!a3.Enabled))
            {
                Validacion(a3);
            }

            empate++;

            if (empate == 9)
            {
                MessageBox.Show("Es un empate.", "Empate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                OnOffBtn(true);
                empate = 0;

            }

        }
        public void Validacion(Button b)
        {
            empate = -1;
            if (b.Text == "X")
            {
                MessageBox.Show("Ganador jugador X.", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasX++;
            }
            else if (b.Text == "O")
            {
                MessageBox.Show("Ganador jugador O.", "Felicidades", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ganadasO++;

            }

            if (rbtnUserRX.Checked && rbtnUserVO.Checked)
            {
                lblUserPuntos1.Text = ganadasX.ToString();
                lblUserPuntos2.Text = ganadasO.ToString();
            }
            if (rbtnUserRO.Checked && rbtnUserVX.Checked)
            {
                lblUserPuntos2.Text = ganadasX.ToString();
                lblUserPuntos1.Text = ganadasO.ToString();
            }
            Limpiar();
            OnOffBtn(true);

        }

        private void Limpiar()
        {
            a1.Text = "";
            a2.Text = "";
            a3.Text = "";

            b1.Text = "";
            b2.Text = "";
            b3.Text = "";

            c1.Text = "";
            c2.Text = "";
            c3.Text = "";


        }


        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            Limpiar();
            OnOffBtn(false);

            btnReiniciar.Visible = false;

            btnIniciar.Visible = true;
            ganadasO = 0;
            ganadasX = 0;
            cambio = true;
            lblUserPuntos1.Text = 0.ToString();
            lblUserPuntos2.Text = 0.ToString();


            rbtnUserRO.Enabled = true;
            rbtnUserVX.Enabled = true; // hanilitado el radiobutton
            rbtnUserRX.Enabled = true;
            rbtnUserVO.Enabled = true;

            rbtnUserRO.Checked = false;
            rbtnUserVX.Checked = false; // verificado el radiobutton
            rbtnUserRX.Checked = false;
            rbtnUserVO.Checked = false;

            groupBox1.Text = "ELIJA QUIÉN EMPIEZA";
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void lblUserPuntos2_Click(object sender, EventArgs e)
        {

        }

        
    }
}
