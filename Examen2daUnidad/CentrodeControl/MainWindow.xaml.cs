using Microsoft.Data.SqlClient;
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

namespace CentrodeControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cadenaConexion =
         "Server=.;Database=Northwind;Integrated Security=True;TrustServerCertificate=True;";

        DispatcherTimer timer = new DispatcherTimer();
        public MainWindow()
        {
            InitializeComponent();
            timer.Interval = TimeSpan.FromSeconds(5);
            timer.Tick += Timer_Tick;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CargarPaises();
        }

        private void CargarPaises()
        {
            string query =
                "select distinct ShipCountry from Orders " +
                "where ShipCountry is not null order by ShipCountry";

            using (SqlConnection con =
                new SqlConnection(cadenaConexion))
            {
                con.Open();

                SqlCommand cmd =
                    new SqlCommand(query, con);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    cbxPais.Items.Clear();

                    while (reader.Read())
                    {
                        cbxPais.Items.Add(reader.GetString(0));
                    }
                }
            }
        }

      

        private void btnDetener_Click(object sender, RoutedEventArgs e)
        {
            timer.Stop();

            txtEstado.Text = "Detenido";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            CargarPedidos();
        }

        private void CargarPedidos()
        {
            string paisSeleccionado =
                cbxPais.SelectedItem.ToString();

            string query =
                "select o.OrderID, c.CompanyName, o.OrderDate, " +
                "o.Freight, o.ShipCountry " +
                "from Orders o inner join Customers c " +
                "on o.CustomerID = c.CustomerID " +
                "where o.ShipCountry = @Country " +
                "and o.ShippedDate is not null " +
                "order by o.OrderDate";

            using (SqlConnection con =
                new SqlConnection(cadenaConexion))
            {
                con.Open();

                SqlCommand command =
                    new SqlCommand(query, con);

                command.Parameters.AddWithValue(
                    "@Country",
                    paisSeleccionado);

                SqlDataReader reader =
                    command.ExecuteReader();

                List<Pedido> lstPedidos =
                    new List<Pedido>();

                while (reader.Read())
                {
                    Pedido pedido = new Pedido();

                    pedido.OrderID =
                        reader.GetInt32(0);

                    pedido.Cliente =
                        reader.GetString(1);

                    if (!reader.IsDBNull(2))
                    {
                        pedido.OrderDate =
                            reader.GetDateTime(2);
                    }

                    if (!reader.IsDBNull(3))
                    {
                        pedido.Freight =
                            reader.GetDecimal(3);
                    }

                    pedido.ShipCountry =
                        reader.GetString(4);

                    lstPedidos.Add(pedido);
                }

                lvPedidos.ItemsSource = lstPedidos;

                txtTotal.Text =
                    lstPedidos.Count.ToString();

                txtHora.Text =
                    DateTime.Now.ToString("HH:mm:ss");
            }
        }

        private void btnIniciar_Click(object sender, RoutedEventArgs e)
        {
            if (cbxPais.SelectedItem == null)
            {
                MessageBox.Show("Seleccione un país");
                return;
            }

            timer.Start();

            txtEstado.Text = "Monitoreando";

            CargarPedidos();
        }
    }
}
