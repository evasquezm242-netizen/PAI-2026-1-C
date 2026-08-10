using System.Data;
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
using Microsoft.Data.SqlClient;

namespace SQLServerEjemplos
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string cadenaConexion = "Server=.;Database=Northwind;Integrated Security=True;TrustServerCertificate=True";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVerificarConexion_Click(object sender, RoutedEventArgs e)
        {
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                try
                {
                    con.Open();
                    MessageBox.Show($"Conexion exitosa: Base de Datos={con.Database}");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error en conexion: {ex.Message}");
                }
            }
        }

        private void btnCargarCategorias_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT CategoryID,CategoryName FROM dbo.Categories";

            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlCommand cmd = new SqlCommand(query, con);
                    con.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        cbxCategorias.Items.Clear();
                        while (reader.Read())
                        {
                            cbxCategorias.Items.Add(
                                new
                                {
                                    Id = reader.GetInt32(0),
                                    Nombre = reader.GetString(1)
                                }
                            );
                        }
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error al ejecutar la sentencia sql: {ex.Message}");
                }
            }
        }

        private void btnMostrarSeleccionado_Click(object sender, RoutedEventArgs e)
        {
            if (cbxCategorias.SelectedItem != null)
            {
                dynamic categoriaSeleccionada = cbxCategorias.SelectedItem;
                int id = categoriaSeleccionada.Id;
                string nombre = categoriaSeleccionada.Nombre;

                MessageBox.Show($"Calegoria Selecionada: Id={id}, Nombre={nombre}");


                MessageBox.Show($"Calegoria Selecionada: Id={cbxCategorias.SelectedValue}");
            }
        }

        private void btnCargarProductos_Click(object sender, RoutedEventArgs e)
        {
            string query = "SELECT ProductID, ProductName, UnitPrice, UnitsInStock FROM Products WHERE Discontinued = 0";
            using (SqlConnection con = new SqlConnection(cadenaConexion))
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, con);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "Producto");
                    dgProductos.ItemsSource = dataSet.Tables["Producto"].DefaultView;
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Error al ejecutar sql: {ex.Message}");
                }
            }
        }
    }
}