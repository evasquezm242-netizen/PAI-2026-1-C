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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ejercicio.sem._3
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {

        }

        private void btAplicar_click_1(object sender, RoutedEventArgs e)
        {
            lbTexto.FontFamily = new FontFamily("consolas");
            lbTexto.Foreground = Brushes.Black;
            lbTexto.Background = Brushes.Transparent;

            if (cbTipoLetra.IsChecked == true)
            {
                lbTexto.FontFamily = new FontFamily("consolas");
            }
            if (cbColorTexto.IsChecked == true)
            {
                lbTexto.Foreground = Brushes.BlueViolet;
            }
            if (cbColorFondo.IsChecked == true)
            {
                lbTexto.Background = Brushes.Aqua;
            }
        }

        private void btAplicarRadio_Click_1(object sender, RoutedEventArgs e)
        {
            lbTextoRadio.FontFamily = new FontFamily("Segoe UI");
            lbTextoRadio.Foreground = Brushes.Black;
            lbTextoRadio.Background = Brushes.Transparent;

            if (rbTipoLetra.IsChecked == true)
            {
                lbTextoRadio.FontFamily = new FontFamily("consolas");
            }
            if (rbColorTexto.IsChecked == true)
            {
                lbTextoRadio.Foreground = Brushes.BlueViolet;
            }
            if (rbColorFondo.IsChecked == true)
            {
                lbTextoRadio.Background = Brushes.Aqua;
            }
        }
    }
}