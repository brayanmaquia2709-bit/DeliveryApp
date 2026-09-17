using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Icono { get; set; } = string.Empty; // Ej: 🍔, 🍕, 🥤, 🍦
    public bool EsSeleccionada { get; set; }
}