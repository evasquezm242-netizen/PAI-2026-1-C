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

namespace EjercicioProp._1
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
            if(Ingreso.Text.Length == 0)
            {
                MessageBox.Show("Ingrese una cantidad valida:");
                    return;
            }
            double ingreso = double.Parse(Ingreso.Text);
            double total = 0;
            double total1 = 0;
            double total2 = 0;
            if(Fonavi.IsChecked == true)
            {
                total += ingreso * 0.08;
                RespFonavi.Text = "s/. " + total;
            }
            if(Imp_Renta.IsChecked == true)
            {
                total1 += ingreso * 0.05;
                RespI_Rent.Text = "S/. " + total1;
            }
            if (A_F_P.IsChecked == true)
            {
                total2 += ingreso * 0.12;
                Total.Text = "S/. " + total2;
            }
            double totalPagar = total + total1 + total2;
            Total.Text = "S/. " + totalPagar;
        }
    }
}