using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Models
{
    public class Plato
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public decimal Precio { get; set; }
        public string ImagenUrl { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public double Calificacion { get; set; } // Ej: 4.8 estrellas
        public int TiempoPreparacionMinutos { get; set; } // Ej: 20 min
    }
}
