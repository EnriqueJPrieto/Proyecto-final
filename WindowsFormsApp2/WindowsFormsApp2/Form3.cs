using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
                            //este comentario es algo orientativo, algunas de las cosas pueden no ser exacatamente igual como se explican aqui.
namespace WindowsFormsApp2  //tengo que poner los tamaños, velocidades y posiciones de las cosas en funcion del tamaño de la ventana, para que se pueda jugar
                            //independientemente del tamaño de la pantalla, para ello deberia enviar la posicion de los jugadores en funcion del tamaño de la pantalla,
                            //de modo que: posicionJ1 = J1.top/ClientSize.Height, y en el receptor hacer posicionJ1*ClientSize.Height = J1.top
                            //y hacer lo mismo con J2, J3 y J4, tambien hay que configurar la velocidad de la bola para que este en funcion del tamaño de la pantalla,
                            //se podria hacer que el tamaño de la bola sea aprox 1/25 del cliente y la velocidad 1/100, ya que el clock funciona a 50hz la bola tardaria
                            //aprox 2s en llegar de lado a lado, con lo cual habria algo de tiempo para reaccionar, este valor puede cambiar y seguramente lo hara
{                           //para asegurarse de que todos los tamaños funcionan bien y se pueden actualizar durante la partida habria que ponerlo dentro del clock
                            //aunque esto probablemente traiga algun bug, el juego sera mucho mejor si se puede ajustar el tamaño de las cosas
                            //EL JUEGO NO FUNCIONA DEL TODO.
    public partial class Form3 : Form
    {
        public static Form3 instance;
        public static string posicion;
        bool Moveup;
        bool Movedown;
        int speed;
        float posicionBallX;//sinedo X la posicion de izq a dcha
        float posicionBallY;//siendo Y la posicion de arriba a abajo

        float ballx; //velocidad de la bola en x
        float bally; //velocidad de la bola en y
        int POALLY = 0;
        int POENEMY = 0;

        public Form3()
        {
            InitializeComponent();
            instance = this;

        }
        int cuentaTicks = 0;
        int segundos = 0;
        int minutos = 0;

        private void Form3_Load(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
            J1.Top =    2 * ClientSize.Height / 5;      //pone todos los elementos en la posicion debida al iniciar el juego
            J2.Top =    4 * ClientSize.Height / 5;
            J3.Top =    2 * ClientSize.Height / 5;
            J4.Top =    4 * ClientSize.Height / 5;
            BALL.Top = ClientSize.Height / 2;
            BALL.Left = ClientSize.Width / 2;
        }

        private void KeyisDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Moveup = true;
            }
            if (e.KeyCode == Keys.Down)
            {
                Movedown = true;
            }
        }

        private void KeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                Moveup = false;
            }
            if (e.KeyCode == Keys.Down)
            {
                Movedown = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            cuentaTicks++;

            if (cuentaTicks%50 == 0)//50 porque el clock tiene una frecuencia de 50hz
            {
                segundos++;
                if (segundos == 60)
                {
                    segundos = 0;
                    minutos++;
                }
            }
            if (segundos < 10)
            {
                RELOJ.Text = minutos + ":0" + segundos;
            }
            else
            {
                RELOJ.Text = minutos + ":" + segundos;
            }

            speed = ClientSize.Height / 100;


            J1.Width = ClientSize.Width / 21;
            J2.Width = ClientSize.Width / 21;
            J3.Width = ClientSize.Width / 21;
            J4.Width = ClientSize.Width / 21    ;

            J1.Height = ClientSize.Height / 5;
            J2.Height = ClientSize.Height / 5;
            J3.Height = ClientSize.Height / 5;
            J4.Height = ClientSize.Height / 5;

            BALL.Width = ClientSize.Width / 25;
            BALL.Height = BALL.Width;

            ballx = ClientSize.Width / 200;// velocidad de la bola en x
            bally = ClientSize.Width / 400;// en Y

            J1.Left = 1 * ClientSize.Width / 20;//esto mueve los bloques a donde deberian estar
            J2.Left = 2 * ClientSize.Width / 20;
            J3.Left = 18 * ClientSize.Width / 20;// 18 y 17 en lugar de 18 y 19 porque empieza a medir a partir de la esquina superior derecha, si 
            J4.Left = 17 * ClientSize.Width / 20;//estuviera configurado como 18 y 19 estairan tocando uno de ellos estaria tocando el borde, lo cual quedaria mal.

            PALLY.Text = ""  + POALLY;
            PENEMY.Text = "" + POENEMY;

            BALL.Top -= Convert.ToInt32(Math.Floor(bally));//direccion de la bola(y)
            BALL.Left -= Convert.ToInt32(Math.Floor(ballx));//direccion de la bola(x)



            if (BALL.Left < 0)//llega hasta el final(te marcan punto)
            {
                BALL.Left = ClientSize.Width / 2;//centro de la pantalla
                BALL.Top = ClientSize.Height / 2;
                ballx = -ballx;//direccion contraria

                POENEMY++;
            }
            if (BALL.Left + BALL.Width > ClientSize.Width)//llega hasta el final(marcas punto)
            {
                BALL.Left = ClientSize.Width/2;//centro de la pantalla
                ballx = -ballx;
                POALLY++;
            }
            if (BALL.Top < 0 || BALL.Top + BALL.Height > ClientSize.Height)//control de bola(y)
            {
                bally = -bally;
            }
            if (BALL.Left < 0 || BALL.Left + BALL.Width > ClientSize.Width)//control de bola(x)
            {
                ballx = -ballx;
            }

             if (BALL.Bounds.IntersectsWith(J1.Bounds) || BALL.Bounds.IntersectsWith(J2.Bounds) || BALL.Bounds.IntersectsWith(J3.Bounds) || BALL.Bounds.IntersectsWith(J4.Bounds))
            {//la bola colisiona con cualquiera de los players
                ballx = -ballx;//la bola va en sentido contrario
            }

            if (POENEMY > 10)
            {
                timer1.Stop();
                MessageBox.Show("Has perdido");
            }
            if (Form2.J1 == Form1.cliente)
            {
                J1.BackColor = Color.Green; J2.BackColor = Color.Yellow; J3.BackColor = Color.Yellow; J4.BackColor = Color.Yellow;
                if (Moveup == true && J1.Top > 0)
                    J1.Top -= speed;//ClientSize.Height/50 es la velocidad del player, puede cambiarse
                if (Movedown == true && J1.Top < ClientSize.Height)
                    J1.Top += speed / 50;

                double posicionJ1 = 1000 * J1.Top / ClientSize.Height;
                posicion = "J1-"+  posicionJ1;//este es el dato que se envia al servidor, los demas clientes haran tp del rectangulo J1 a esta posicion, igual para los demas

                if (Form1.posicionJ2 != null && Form1.posicionJ2 != "0.000000")// el servidor devuelve -1 si no recibe posicion de un jugador
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ2);
                    m = Math.Truncate(m) / 10000000m;
                    J2.Top = Convert.ToInt32(Math.Floor(m));
                }   
                if (Form1.posicionJ3 != null && Form1.posicionJ3 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ3);
                    m = Math.Truncate(m) / 10000000m;
                    J3.Top = Convert.ToInt32(Math.Floor(m));
                }
                if (Form1.posicionJ4 != null && Form1.posicionJ4 != "0.000000")
                {
  
                    decimal m = Convert.ToDecimal(Form1.posicionJ4);
                    m = Math.Truncate(m) / 10000000m;
                    J4.Top = Convert.ToInt32(Math.Floor(m)*ClientSize.Height);
                }

                if (POALLY > 10)
                {
                    timer1.Stop();
                    MessageBox.Show("Has Ganado");
                }

            }
            if (Form2.J2 == Form1.cliente)
            {
                J1.BackColor = Color.Yellow; J2.BackColor = Color.Green; J3.BackColor = Color.Yellow; J4.BackColor = Color.Yellow;
                if (Moveup == true && J2.Top > 0)
                    J2.Top -= speed;
                if (Movedown == true && J2.Top < ClientSize.Height)
                    J2.Top += speed;
                double posicionJ2 = 1000 * J2.Top / ClientSize.Height;
                posicion = "J2-"+ posicionJ2;

                if (Form1.posicionJ1 != null && Form1.posicionJ1 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ1);
                    m = Math.Truncate(m) / 10000000m;
                    J1.Top = Convert.ToInt32(Math.Floor(m));
                }
                if (Form1.posicionJ3 != null && Form1.posicionJ3 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ3);
                    m = Math.Truncate(m) / 10000000m;
                    J3.Top = Convert.ToInt32(Math.Floor(m));
                }
                if (Form1.posicionJ4 != null && Form1.posicionJ4 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ4);
                    m = Math.Truncate(m) / 10000000m;
                    J4.Top = Convert.ToInt32(Math.Floor(m));
                }

                if (POALLY > 10)
                {
                    timer1.Stop();
                    MessageBox.Show("Has Ganado");
                }

            }
            if (Form2.J3 == Form1.cliente)
            {
                J1.BackColor = Color.Yellow; J2.BackColor = Color.Yellow; J3.BackColor = Color.Green; J4.BackColor = Color.Yellow;
                if (Moveup == true && J3.Top > 0)
                    J3.Top -= speed;
                if (Movedown == true && J3.Top < ClientSize.Height)
                    J3.Top += speed;

                double posicionJ3 = 1000*J3.Top / ClientSize.Height;
                posicion = "J3-" + posicionJ3;

                if (Form1.posicionJ1 != null && Form1.posicionJ1 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ1);
                    m = Math.Truncate(m) / 10000000m;
                    J1.Top = Convert.ToInt32(Math.Floor(m));
                }
                if (Form1.posicionJ2 != null && Form1.posicionJ2 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ2);
                    m = Math.Truncate(m) / 10000000m;
                    J2.Top = Convert.ToInt32(Math.Floor(m));
                }
                if (Form1.posicionJ4 != null && Form1.posicionJ4 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ4);
                    m = Math.Truncate(m)/10000000m;
                    J4.Top = Convert.ToInt32(Math.Floor(m));
                }

                if (POENEMY > 10)
                {
                    timer1.Stop();
                    MessageBox.Show("Has perdido");
                }
            }
            if (Form2.J4 == Form1.cliente)
            {
                J1.BackColor = Color.Yellow; J2.BackColor = Color.Yellow; J3.BackColor = Color.Yellow; J4.BackColor = Color.Green;
                if (Moveup == true && J4.Top > 0)
                    J4.Top -= speed;
                if (Movedown == true && J4.Top < ClientSize.Height)
                    J4.Top += speed;

                double posicionJ4 = 1000 * J4.Top / ClientSize.Height;
                posicion = "J4-" + posicionJ4;

                if (Form1.posicionJ1 != null && Form1.posicionJ1 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ1);
                    m = Math.Truncate(m) / 10000000m;
                    J1.Top = Convert.ToInt32(Math.Floor(m));
                }
                if (Form1.posicionJ2 != null && Form1.posicionJ2 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ2);
                    m = Math.Truncate(m) / 10000000m;
                    J2.Top = Convert.ToInt32(Math.Floor(m));
                }
                if (Form1.posicionJ3 != null && Form1.posicionJ3 != "0.000000")
                {
                    decimal m = ClientSize.Height * Convert.ToDecimal(Form1.posicionJ3);
                    m = Math.Truncate(m) / 10000000m;
                    J3.Top = Convert.ToInt32(Math.Floor(m));
                }

                if (POENEMY > 10)
                {
                    timer1.Stop();
                    MessageBox.Show("Has perdido");
                }
            }
            Form1.instance.enviarPosiciones();
        }

        private void BALL_Click(object sender, EventArgs e)
        {

        }
    }
}
