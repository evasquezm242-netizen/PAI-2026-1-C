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

namespace EjercicioImpresiones.sem4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Impresion> impresiones = new List<Impresion>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            string cliente = txtCliente.Text;
            string celular = txtCelular.Text;

            int cantidad = Convert.ToInt32(txtCantidad.Text);

            string tarifa = "";
            double precio = 0;

            if (rbEscolar.IsChecked == true)
            {
                tarifa = "Escolar";
                precio = 0.10;
            }
            else if (rbUniversitario.IsChecked == true)
            {
                tarifa = "Universitario";
                precio = 0.15;
            }
            else if (rbOrganizacion.IsChecked == true)
            {
                tarifa = "Organizacion";
                precio = 0.20;
            }

            double importe = cantidad * precio;

            Impresion imp = new Impresion(
                cliente,
                celular,
                cantidad,
                tarifa,
                importe
            );

            impresiones.Add(imp);

            MostrarDatos();

            Limpiar();
        }

        private void MostrarDatos()
        {
            lstCliente.Items.Clear();
            lstCelular.Items.Clear();
            lstCantidad.Items.Clear();
            lstTarifa.Items.Clear();
            lstImporte.Items.Clear();

            for (int i = 0; i < impresiones.Count; i++)
            {
                lstCliente.Items.Add(impresiones[i].Cliente);
                lstCelular.Items.Add(impresiones[i].Celular);
                lstCantidad.Items.Add(impresiones[i].Cantidad);
                lstTarifa.Items.Add(impresiones[i].Tarifa);
                lstImporte.Items.Add(
                    impresiones[i].Importe.ToString("0.00"));
            }
        }

        private void btnEstadistica_Click(object sender, RoutedEventArgs e)
        {
            int escolares = 0;
            int universitarios = 0;
            int organizacionales = 0;

            for (int i = 0; i < impresiones.Count; i++)
            {
                if (impresiones[i].Tarifa == "Escolar")
                {
                    escolares++;
                }
                else if (impresiones[i].Tarifa == "Universitario")
                {
                    universitarios++;
                }
                else if (impresiones[i].Tarifa == "Organizacion")
                {
                    organizacionales++;
                }
            }

            txtEscolares.Text = escolares.ToString();
            txtUniversitarios.Text = universitarios.ToString();
            txtOrganizacionales.Text = organizacionales.ToString();
        }

        private void Limpiar()
        {
            txtCliente.Clear();
            txtCelular.Clear();
            txtCantidad.Clear();

            rbEscolar.IsChecked = false;
            rbUniversitario.IsChecked = false;
            rbOrganizacion.IsChecked = false;

            txtCliente.Focus();
        }
    }
}
