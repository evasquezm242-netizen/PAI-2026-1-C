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

namespace EncritarClave
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEncriptar_Click(object sender, RoutedEventArgs e)
        {
            string clave = txtClave.Text;

            if (clave == "")
            {
                MessageBox.Show("Ingrese una clave");
                return;
            }

            string encriptada = "";

            for (int i = 0; i < clave.Length; i++)
            {
                char letra = clave[i];

                letra = (char)(letra + 3);

                encriptada = encriptada + letra;
            }

            txtResultado.Text = encriptada;
        }
    }
}