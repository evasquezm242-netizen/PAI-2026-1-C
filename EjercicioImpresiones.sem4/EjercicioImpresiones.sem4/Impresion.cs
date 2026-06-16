using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioImpresiones.sem4
{
    class Impresion
    {
        public string Cliente { get; set; }
        public string Celular { get; set; }
        public int Cantidad { get; set; }
        public string Tarifa { get; set; }
        public double Importe { get; set; }

        public Impresion(string cliente, string celular,
                         int cantidad, string tarifa,
                         double importe)
        {
            Cliente = cliente;
            Celular = celular;
            Cantidad = cantidad;
            Tarifa = tarifa;
            Importe = importe;
        }
    }
}
