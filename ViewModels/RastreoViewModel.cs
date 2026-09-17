using System.Windows.Input;
using DeliveryApp.Services;

namespace DeliveryApp.ViewModels;

public class RastreoViewModel : BaseViewModel
{
    private string _estadoTexto = "📋 Pedido Recibido";
    public string EstadoTexto
    {
        get => _estadoTexto;
        set => SetProperty(ref _estadoTexto, value);
    }

    private string _mensajeDetalle = "El restaurante ha recibido tu pedido y lo está confirmando.";
    public string MensajeDetalle
    {
        get => _mensajeDetalle;
        set => SetProperty(ref _mensajeDetalle, value);
    }

    private double _progresoPorcentaje = 0.25;
    public double ProgresoPorcentaje
    {
        get => _progresoPorcentaje;
        set => SetProperty(ref _progresoPorcentaje, value);
    }

    private string _iconoEstado = "📋";
    public string IconoEstado
    {
        get => _iconoEstado;
        set => SetProperty(ref _iconoEstado, value);
    }

    public ICommand VolverAlInicioCommand { get; }

    public RastreoViewModel()
    {
        Titulo = "Seguimiento de tu Pedido 🛵";
        VolverAlInicioCommand = new Command(VolverAlInicio);

        // Iniciar la simulación en tiempo real
        SimularProgresoPedido();
    }

    private async void SimularProgresoPedido()
    {
        // Estado 1: Pedido Recibido (0 - 4 segundos)
        await Task.Delay(4000);

        // Estado 2: En Cocina
        IconoEstado = "👨‍🍳";
        EstadoTexto = "👨‍🍳 En Preparación";
        MensajeDetalle = "¡El chef está preparando tus platillos con ingredientes frescos!";
        ProgresoPorcentaje = 0.50;

        await Task.Delay(5000);

        // Estado 3: En Camino
        IconoEstado = "🛵";
        EstadoTexto = "🛵 Repartidor en Camino";
        MensajeDetalle = "Tu pedido ya va en la moto. Tiempo estimado de llegada: 12 min.";
        ProgresoPorcentaje = 0.75;

        await Task.Delay(5000);

        // Estado 4: ¡Entregado!
        IconoEstado = "🎉";
        EstadoTexto = "🎉 ¡Pedido Entregado!";
        MensajeDetalle = "Tu pedido ha sido entregado en la puerta de tu casa. ¡Buen provecho!";
        ProgresoPorcentaje = 1.0;

        // Limpiamos el carrito de compras pues la orden se completó
        CarritoService.Instancia.LimpiarCarrito();
    }

    private async void VolverAlInicio()
    {
        // Regresa a la pantalla principal de la app
        await Application.Current?.Windows[0].Page?.Navigation.PopToRootAsync()!;
    }
}