using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Tragamonedas
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer timerReloj = new DispatcherTimer();
        DispatcherTimer timerJuego = new DispatcherTimer();

        Random random = new Random();

        int contadorJuego = 0;
        public MainWindow()
        {
            InitializeComponent();

            timerReloj.Interval = TimeSpan.FromSeconds(1);
            timerReloj.Tick += timerReloj_Tick;
            timerReloj.Start();

            timerJuego.Interval = TimeSpan.FromMilliseconds(100);
            timerJuego.Tick += timerJuego_Tick;

            lbResultadoJuego.Visibility = Visibility.Hidden;
        }

        private void timerReloj_Tick(object sender, EventArgs e)
        {
            tblReloj.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void btnJugar_Click(object sender, RoutedEventArgs e)
        {
            contadorJuego = 0;

            lbResultadoJuego.Visibility = Visibility.Hidden;

            txtNumero1.Clear();
            txtJugada2.Clear();
            txtJugada3.Clear();

            btnJugar.IsEnabled = false;

            timerJuego.Start();
        }

        private void timerJuego_Tick(object sender, EventArgs e)
        {
            txtNumero1.Text = random.Next(0, 10).ToString();
            txtJugada2.Text = random.Next(0, 10).ToString();
            txtJugada3.Text = random.Next(0, 10).ToString();

            contadorJuego++;

            //60 x 100 ms = 6 segundos
            if (contadorJuego == 60)
            {
                timerJuego.Stop();

                if (txtNumero1.Text == txtJugada2.Text &&
                    txtJugada2.Text == txtJugada3.Text)
                {
                    lbResultadoJuego.Content = "¡¡GANASTE!!";
                }
                else
                {
                    lbResultadoJuego.Content = "PERDISTE";
                }

                lbResultadoJuego.Visibility = Visibility.Visible;

                btnJugar.IsEnabled = true;
            }
        }

        private void reiniciar()
        {
            txtNumero1.Clear();
            txtJugada2.Clear();
            txtJugada3.Clear();

            lbResultadoJuego.Visibility = Visibility.Hidden;

            contadorJuego = 0;
        }
    }
}