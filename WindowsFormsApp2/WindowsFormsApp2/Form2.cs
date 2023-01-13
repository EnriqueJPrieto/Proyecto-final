using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form2 : Form
    {
        public static Form2 instance;
        public Label l1;
        public Label l2;
        public Label l3;
        public Label l4;
        public Label l5;
        public Label l6;
        public Label l7;
        public Label l8;
        public TextBox tB;
        public static string J1;
        public static string J2;
        public static string J3;
        public static string J4;
        public Form2()
        {
            InitializeComponent();//esto es el chat
            instance = this;
            l1 = label6;// J2
            l2 = label8;// J3
            l3 = label7;// J4
            l4 = label1;
            l5 = label2;
            l6 = label3;
            l7 = label4;
            l8 = label5;// J1
            tB = textBox1;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void button1_Click(object sender, EventArgs e)//boton de enviar
        {
            Form1.instance.enviarMensaje();
            textBox1.Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)//boton de empezar el game
        {
            startGame();
        }
        public void startGame()
        {
            this.Hide();
            Form3 f3 = new Form3();
            //esto hace que el cliente reconozca cual es su rectangulo
            J1 = label5.Text;
            J2 = label6.Text;
            J3 = label8.Text;
            J4 = label7.Text;
            f3.ShowDialog();
            Form1.instance.empezarPartida();
        }

    }
}
