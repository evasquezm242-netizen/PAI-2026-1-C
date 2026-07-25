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

namespace T_BINGO._8
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TextBox[,] txtCartilla;
        private int[,] numerosCartilla = new int[5, 5];
        private bool[,] marcados = new bool[5, 5];

        private List<int> numerosSorteados = new List<int>();
        Random random = new Random();

        private bool juegoIniciado = false;
        private bool cartillaGenerada = false;

        public MainWindow()
        {
            InitializeComponent();
            CrearMatriz();
            tbEstado.Text = "Estado: Esperando generar cartilla...";
        }


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            txtCartilla = new TextBox[,]
            {
                { txt00, txt01, txt02, txt03, txt04 },
                { txt10, txt11, txt12, txt13, txt14 },
                { txt20, txt21, txt22, txt23, txt24 },
                { txt30, txt31, txt32, txt33, txt34 },
                { txt40, txt41, txt42, txt43, txt44 }
            };

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    txtCartilla[i, j].Clear();
                    txtCartilla[i, j].Background = Brushes.White;
                    txtCartilla[i, j].IsReadOnly = true;
                }
            }


            txt22.Text = "FREE";
            txt22.Background = Brushes.LightGray;
            marcados[2, 2] = true;

            tbEstado.Text = "Esperando...";
            tbResultado.Text = "";

            tbNumeroActual.Text = "-";
            lbNumeros.Items.Clear();

            btnSiguiente.IsEnabled = false;
        }

        private void btnGenerarCartilla_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            List<int> numeros = new List<int>();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    txtCartilla[i, j].Clear();
                    txtCartilla[i, j].Background = Brushes.White;

                    marcados[i, j] = false;
                }
            }

            txtCartilla[2, 2].Text = "FREE";
            txtCartilla[2, 2].Background = Brushes.LightGray;

            marcados[2, 2] = true;

            while (numeros.Count < 24)
            {
                int numero = random.Next(1, 76);

                if (!numeros.Contains(numero))
                {
                    numeros.Add(numero);
                }
            }

            int k = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (i == 2 && j == 2)
                    {
                        numerosCartilla[i, j] = 0;
                        continue;
                    }
                    numerosCartilla[i, j] = numeros[k];
                    txtCartilla[i, j].Text = numeros[k].ToString();
                    k++;
                }
            }

            numerosSorteados.Clear();
            lbNumeros.Items.Clear();
            tbNumeroActual.Text = "-";
            tbResultado.Text = "";
            tbEstado.Text = "Cartilla Generada";
            juegoIniciado = false;
            cartillaGenerada = true;
            btnSiguiente.IsEnabled = false;
        }

        private void btnIniciarJuego_Click(object sender, RoutedEventArgs e)
        {
            if (!cartillaGenerada)
            {
                MessageBox.Show("Primero debe generar la cartilla.", "BINGO", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (juegoIniciado)
            {
                MessageBox.Show("El juego ya fue iniciado.", "BINGO", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            juegoIniciado = true;
            btnSiguiente.IsEnabled = true;
            tbEstado.Text = "Jugando...";
            tbResultado.Text = "";
        }

        private void btnSiguiente_Click(object sender, RoutedEventArgs e)
        {
            if (!juegoIniciado)
            {
                MessageBox.Show("Primero debe iniciar el juego.", "BINGO", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (numerosSorteados.Count == 75)
            {
                MessageBox.Show("Ya no existen más números.", "BINGO", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            int numero;

            do
            {
                numero = random.Next(1, 76);
            } while (numerosSorteados.Contains(numero));

            numerosSorteados.Add(numero);
            tbNumeroActual.Text = numero.ToString();
            lbNumeros.Items.Add(numero);

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (numerosCartilla[i, j] == numero)
                    {
                        marcados[i, j] = true;
                        txtCartilla[i, j].Background = Brushes.LightGreen;
                        txtCartilla[i, j].FontWeight = FontWeights.Bold;
                    }
                }
            }

            if (VerificarFila() ||
                VerificarColumna() ||
                VerificarDiagonalPrincipal() ||
                VerificarDiagonalSecundaria() ||
                VerificarL())
            {

                tbEstado.Text = "Juego Finalizado";
                tbResultado.Text = "¡¡ BINGO !!";
                btnSiguiente.IsEnabled = false;
                MessageBox.Show("¡Felicidades!\nHas conseguido BINGO.", "BINGO", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private bool VerificarFila()
        {
            for (int i = 0; i < 5; i++)
            {
                bool completa = true;
                for (int j = 0; j < 5; j++)
                {
                    if (!marcados[i, j])
                    {
                        completa = false;
                        break;
                    }
                }

                if (completa)
                    return true;
            }
            return false;
        }

        private bool VerificarColumna()
        {
            for (int j = 0; j < 5; j++)
            {
                bool completa = true;
                for (int i = 0; i < 5; i++)
                {
                    if (!marcados[i, j])
                    {
                        completa = false;
                        break;
                    }
                }
                if (completa)
                    return true;
            }
            return false;
        }

        private bool VerificarDiagonalPrincipal()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!marcados[i, i])
                    return false;
            }

            return true;
        }

        private bool VerificarDiagonalSecundaria()
        {
            for (int i = 0; i < 5; i++)
            {
                if (!marcados[i, 4 - i])
                    return false;
            }

            return true;
        }

        private bool VerificarL()
        {
            bool l1 = true;
            for (int i = 0; i < 5; i++)
            {
                if (!marcados[i, 0])
                    l1 = false;
            }
            for (int j = 0; j < 5; j++)
            {
                if (!marcados[4, j])
                    l1 = false;
            }
            if (l1) return true;
            bool l2 = true;

            for (int i = 0; i < 5; i++)
            {
                if (!marcados[i, 4])
                    l2 = false;
            }

            for (int j = 0; j < 5; j++)
            {
                if (!marcados[4, j])
                    l2 = false;
            }

            if (l2) return true;
            bool l3 = true;

            for (int i = 0; i < 5; i++)
            {
                if (!marcados[i, 0])
                    l3 = false;
            }

            for (int j = 0; j < 5; j++)
            {
                if (!marcados[0, j])
                    l3 = false;
            }

            if (l3) return true;
            bool l4 = true;

            for (int i = 0; i < 5; i++)
            {
                if (!marcados[i, 4])
                    l4 = false;
            }

            for (int j = 0; j < 5; j++)
            {
                if (!marcados[0, j])
                    l4 = false;
            }

            if (l4) 
                return true;

            return false;
        }

        private void btnReiniciar_Click(object sender, RoutedEventArgs e)
        {
            juegoIniciado = false;
            numerosSorteados.Clear();
            lbNumeros.Items.Clear();
            tbNumeroActual.Text = "-";
            tbResultado.Text = "-";
            tbEstado.Text = "Esperando...";
            btnSiguiente.IsEnabled = false;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    numerosCartilla[i, j] = 0;
                    marcados[i, j] = false;

                    txtCartilla[i, j].Text = "";
                    txtCartilla[i, j].Background = Brushes.White;
                }
            }
        }

        private void CrearMatriz()
        {
            txtCartilla = new TextBox[5, 5];

            txtCartilla[0, 0] = txt00;
            txtCartilla[0, 1] = txt01;
            txtCartilla[0, 2] = txt02;
            txtCartilla[0, 3] = txt03;
            txtCartilla[0, 4] = txt04;

            txtCartilla[1, 0] = txt10;
            txtCartilla[1, 1] = txt11;
            txtCartilla[1, 2] = txt12;
            txtCartilla[1, 3] = txt13;
            txtCartilla[1, 4] = txt14;

            txtCartilla[2, 0] = txt20;
            txtCartilla[2, 1] = txt21;
            txtCartilla[2, 2] = txt22;
            txtCartilla[2, 3] = txt23;
            txtCartilla[2, 4] = txt24;

            txtCartilla[3, 0] = txt30;
            txtCartilla[3, 1] = txt31;
            txtCartilla[3, 2] = txt32;
            txtCartilla[3, 3] = txt33;
            txtCartilla[3, 4] = txt34;

            txtCartilla[4, 0] = txt40;
            txtCartilla[4, 1] = txt41;
            txtCartilla[4, 2] = txt42;
            txtCartilla[4, 3] = txt43;
            txtCartilla[4, 4] = txt44;
        }
    }
}