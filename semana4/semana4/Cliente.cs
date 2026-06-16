using System;
using System.Collections.Generic;
using System.Text;

namespace semana4
{
    internal class Cliente
    {
        public Cliente(String apellidos, string nombres, string dni, string direccion, string estadoCivil)
        {
            Apellidos = apellidos;
            Nombres = nombres;
            Dni = dni;
            EstadoCivil = estadoCivil;
        }
        public string Apellidos{ get; set;}
        public string Nombres { get; set; }
        public string Dni { get; set; }
        public string Direccion { get; set; }
        public String EstadoCivil { get; set; }
    }
}   

