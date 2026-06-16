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

namespace semana4
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

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxItem nuevoItem = new ComboBoxItem();
            nuevoItem.Content = txtNuevo.Text.ToUpper();

            cmbFrutas.Items.Add(nuevoItem);

            txtNuevo.Clear();
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            if (cmbFrutas.SelectedItem == null)
            {
                MessageBox.Show("Debe seleccionar un elemento");
                return;
            }
            ComboBoxItem seleccionado = (ComboBoxItem)cmbFrutas.SelectedItem;
            string valorseleccionado = seleccionado.Content.ToString();

            MessageBox.Show($"Fruta seleccionada: {valorseleccionado}");
        }
    }
}