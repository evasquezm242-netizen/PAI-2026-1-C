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
    /// Lógica de interacción para Ventana3.xaml
    /// </summary>
    public partial class Ventana3 : Window
    {
        public Ventana3()
        {
            InitializeComponent();
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            if (lbFrutas.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una fruta");
                return;

            }
            ListBoxItem listBoxItem = lbFrutas.SelectedItem as ListBoxItem;
            string valorSeleccionado = listBoxItem.Content.ToString();
            MessageBox.Show($"Fruta Seleccionada: {valorSeleccionado}");
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            ListBoxItem nuevo = new ListBoxItem();
            nuevo.Content = txtNuevo.Text;

            lbFrutas.Items.Add( nuevo );

            txtNuevo.Clear();
        }
    }
}
