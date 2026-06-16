using System;
using System.Collections.Generic;
using System.Text;

namespace semana4
{
    class Alumno
    {
        public Alumno(string nombres, string apellidos, int edad) 
        {
            Nombres = nombres;
            Apellidos = apellidos;
            Edad = edad;
        }

        public string Nombres { get; set;}
        public string Apellidos { get; set; }
        public int Edad { get; set; }
    }
}
