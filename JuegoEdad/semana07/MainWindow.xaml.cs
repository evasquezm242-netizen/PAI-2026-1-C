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

namespace semana07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int edadMinima;
        private int edadMaxima;
        private int edadAleatoria;
        private int contadorIntentos;
        Random random = new Random();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnPrimerIntento_Click(object sender, RoutedEventArgs e)
        {
            if (!int.TryParse(txtMinimo.Text, out edadMinima))
            {
                MessageBox.Show("Ingrese edad mínima válida", "Validar", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMinimo.Focus();
                return;
            }
            if (!int.TryParse(txtMaximo.Text, out edadMaxima))
            {
                MessageBox.Show("Ingrese edad máxima válida", "Validar", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMaximo.Focus();
                return;
            }

            if (edadMinima < 0)
            {
                MessageBox.Show("Edad mínima debe ser mayor a cero", "Validar", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMinimo.Focus();
                return;
            }

            if (edadMaxima < 0)
            {
                MessageBox.Show("Edad máxima debe ser mayor a cero", "Validar", MessageBoxButton.OK, MessageBoxImage.Error);
                txtMaximo.Focus();
                return;
            }

            if (edadMaxima < edadMinima)
            {
                MessageBox.Show("La edad Máxima debe ser mayor que la edad Mínima", "Validar", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            edadAleatoria = random.Next(edadMinima, edadMaxima + 1);
            contadorIntentos++;

            txtEdad.Text = edadAleatoria.ToString();
        }

        private void btnCorrecto_Click(object sender, RoutedEventArgs e)
        {
            if (contadorIntentos == 0)
            {
                MessageBox.Show("Primero debe hacer click en el boton Primer Intento", "Intentos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            MessageBox.Show($"Número de Intentos: {contadorIntentos}", "Intentos", MessageBoxButton.OK, MessageBoxImage.Information);
            reiniciar();
        }

        private void btnIncorrecto_Click(object sender, RoutedEventArgs e)
        {
            if (contadorIntentos == 0)
            {
                MessageBox.Show("Primero debe hacer click en el boton Primer Intento", "Intentos", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            contadorIntentos++;

            edadAleatoria = random.Next(edadMinima, edadMaxima + 1);
            txtEdad.Text = edadAleatoria.ToString();
        }

        private void reiniciar()
        {
            contadorIntentos = 0;
            txtEdad.Clear();
            txtMaximo.Clear();
            txtMinimo.Clear();
        }
    }
}