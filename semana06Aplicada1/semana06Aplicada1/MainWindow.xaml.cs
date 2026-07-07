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

namespace semana06Aplicada1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            calCita.SelectedDate = DateTime.Today;
        }

        private void btnCronograma_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPaciente.Text))
            {
                MessageBox.Show("Ingrese un paciente válido", "Validar Paciente", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            string paciente = txtPaciente.Text;

            string tratamiento = ((ComboBoxItem)cbxTratamiento.SelectedItem).Content.ToString();
            string pieza = ((ComboBoxItem)cbxPiezaDental.SelectedItem).Content.ToString();

            DateTime fechaCita = calCita.SelectedDate.Value;

            DateTime citaProxima = fechaCita.AddDays(15);

            string reporte = $"Reporte de Cita\n" +
                "========================\n" +
                $"Paciente: {paciente}\n" +
                $"Tratamiento: {tratamiento}\n" +
                $"Pieza Dental: {pieza}\n" +
                $"Fecha de Cita: {fechaCita.ToLongDateString()}\n" +
                "------------------------\n" +
                $"Fecha Proxima cita: {citaProxima.ToShortDateString()}";

            txtReporte.Text = reporte;
        }
    }
}