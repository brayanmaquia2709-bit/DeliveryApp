using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Models;

public class ItemCarrito
{
    public Plato Producto { get; set; } = new();
    public int Cantidad { get; set; } = 1;

    // Propiedad calculada: Multiplica el precio individual por la cantidad
    public decimal Subtotal => Producto.Precio * Cantidad;
}