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
    /// Lógica de interacción para ListView.xaml
    /// </summary>
    public partial class ListView : Window
    {
        List<Alumno> alumnos = new List<Alumno>();
        public ListView()
        {
            InitializeComponent();
            alumnos.Add(new Alumno("Juan", "Perez", 30));
            alumnos.Add(new Alumno("Carlos", "Sanchez", 25));

            lvAlumnos.ItemsSource = alumnos;
        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text == "" || txtApellidos.Text == "" || txtEdad.Text == "")
            {
                MessageBox.Show("Todos los campos tienen que estar llenos");
                return;
            }
            Alumno nuevo = new Alumno(
                txtNombre.Text,
                txtApellidos.Text,
                Int32.Parse(txtEdad.Text)
                );
            alumnos.Add(nuevo);
            lvAlumnos.ItemsSource = null;
            lvAlumnos.ItemsSource = alumnos;

            txtNombre.Clear();
            txtApellidos.Clear();
            txtEdad.Clear();
        }

        private void btnMostrar_Click(object sender, RoutedEventArgs e)
        {
            if (lvAlumnos.SelectedItem != null)
            {
                Alumno alumno = (Alumno)lvAlumnos.SelectedItem;
                MessageBox.Show($"Alumno seleccionado: {alumno.Nombres} {alumno.Apellidos} {alumno.Edad}");
            }
            else {
                MessageBox.Show("No hay almunos selecionado");
            }
        }
    }
}
