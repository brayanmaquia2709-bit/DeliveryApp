using System.Collections.ObjectModel;
using System.Windows.Input;
using DeliveryApp.Models;
using DeliveryApp.Services;
using DeliveryApp.Views;

namespace DeliveryApp.ViewModels;

public class CarritoViewModel : BaseViewModel
{
    // Leemos directamente los ítems de nuestro servicio Singleton
    public ObservableCollection<ItemCarrito> Items => CarritoService.Instancia.Items;

    public decimal Subtotal => CarritoService.Instancia.Subtotal;
    public decimal CostoEnvio => CarritoService.Instancia.CostoEnvio;
    public decimal Total => CarritoService.Instancia.Total;

    // Comandos de la pantalla
    public ICommand IncrementarCommand { get; }
    public ICommand DecrementarCommand { get; }
    public ICommand RealizarPedidoCommand { get; }

    public CarritoViewModel()
    {
        Titulo = "Mi Pedido 🛒";

        IncrementarCommand = new Command<ItemCarrito>(Incrementar);
        DecrementarCommand = new Command<ItemCarrito>(Decrementar);
        RealizarPedidoCommand = new Command(RealizarPedido);
    }

    private void Incrementar(ItemCarrito item)
    {
        if (item == null) return;
        CarritoService.Instancia.Incrementar(item);
        RefrescarTotales();
    }

    private void Decrementar(ItemCarrito item)
    {
        if (item == null) return;
        CarritoService.Instancia.Decrementar(item);
        RefrescarTotales();
    }

    // Le avisa a la pantalla XAML que los totales financieros cambiaron
    private void RefrescarTotales()
    {
        OnPropertyChanged(nameof(Subtotal));
        OnPropertyChanged(nameof(CostoEnvio));
        OnPropertyChanged(nameof(Total));
        OnPropertyChanged(nameof(Items));
    }

    private async void RealizarPedido()
    {
        if (!Items.Any())
        {
            await Application.Current?.Windows[0].Page?.DisplayAlert("Carrito Vacío", "Por favor agrega al menos un producto para continuar.", "OK")!;
            return;
        }

        // Navegar a la pantalla de Rastreo de Pedido en Tiempo Real
        await Application.Current?.Windows[0].Page?.Navigation.PushAsync(new RastreoPage())!;
    }
}