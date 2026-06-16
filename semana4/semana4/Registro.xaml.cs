using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace semana4
{
    /// <summary>
    /// Lógica de interacción para Registro.xaml
    /// </summary>
    public partial class Registro : Window
    {
        List<Cliente> clientes = new List<Cliente>();
        public Registro()
        {
            InitializeComponent();
            lvCliente.ItemsSource = clientes;
        }
        private void btnGrabar_Click(object sender, RoutedEventArgs e)
        {
            string nombres = txtNombres.Text;
            string apellidos = txtApellidos.Text;
            string dni = txtDNI.Text;
            string direccion = txtDireccion.Text;
            ComboBoxItem estadoCivilItem = (ComboBoxItem)cmbEstadoCivil;
        }
        private void btnNuevo_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void btnEstadistica_Click(object sender, RoutedEventArgs e)
        {
            int solteros = 0;
            int cansados = 0;

            for (int i = 0; i < clientes.Count; i++)
            {
                if (cliente )
            }

        }
    }
}
