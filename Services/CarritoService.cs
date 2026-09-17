using System.Collections.ObjectModel;
using DeliveryApp.Models;

namespace DeliveryApp.Services;

public class CarritoService
{
    // Instancia única (Singleton) para que toda la app use el mismo carrito
    private static CarritoService? _instancia;
    public static CarritoService Instancia => _instancia ??= new CarritoService();

    // Lista observable de los productos seleccionados
    public ObservableCollection<ItemCarrito> Items { get; set; } = new();

    // Costo fijo de envío por domicilio
    public decimal CostoEnvio => Items.Any() ? 4500m : 0m;

    // Cálculo automático de Subtotal (Suma de todos los ítems)
    public decimal Subtotal => Items.Sum(i => i.Subtotal);

    // Cálculo automático del Total Final
    public decimal Total => Subtotal + CostoEnvio;

    // Método para agregar un plato al carrito
    public void AgregarProducto(Plato plato)
    {
        var itemExistente = Items.FirstOrDefault(i => i.Producto.Id == plato.Id);

        if (itemExistente != null)
        {
            // Si ya existía en el carrito, solo le sumamos 1 a la cantidad
            itemExistente.Cantidad++;
        }
        else
        {
            // Si no existía, agregamos un nuevo ItemCarrito
            Items.Add(new ItemCarrito { Producto = plato, Cantidad = 1 });
        }
    }

    // Aumentar la cantidad de un ítem
    public void Incrementar(ItemCarrito item)
    {
        item.Cantidad++;
    }

    // Disminuir la cantidad o eliminar si llega a 0
    public void Decrementar(ItemCarrito item)
    {
        if (item.Cantidad > 1)
        {
            item.Cantidad--;
        }
        else
        {
            Items.Remove(item);
        }
    }

    // Limpiar el carrito después de hacer la compra
    public void LimpiarCarrito()
    {
        Items.Clear();
    }
}