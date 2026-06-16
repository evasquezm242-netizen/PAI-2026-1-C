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
    /// Lógica de interacción para VentanaPrincipal.xaml
    /// </summary>
    public partial class VentanaPrincipal : Window
    {
        public VentanaPrincipal()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow ventana1 = new MainWindow();
            ventana1.ShowDialog();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Ventana3 ventanaCb = new Ventana3();
            ventanaCb.ShowDialog();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ListView ventanaListView = new ListView();
            ventanaListView.ShowDialog();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Registro ventanaRegistro = new Registro();
            ventanaRegistro.ShowDialog();
        }
    }
}
