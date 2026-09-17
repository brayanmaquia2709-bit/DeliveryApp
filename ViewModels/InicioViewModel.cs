using System.Collections.ObjectModel;
using System.Windows.Input;
using DeliveryApp.Models;
using DeliveryApp.Services;
using DeliveryApp.Views;

namespace DeliveryApp.ViewModels;

public class InicioViewModel : BaseViewModel
{
    private readonly MockDeliveryService _deliveryService;
    private List<Plato> _todosLosPlatos = new();

    public ObservableCollection<Categoria> Categorias { get; set; } = new();
    public ObservableCollection<Plato> PlatosFiltrados { get; set; } = new();

    public ICommand SeleccionarCategoriaCommand { get; }
    public ICommand AgregarAlCarritoCommand { get; }
    public ICommand VerCarritoCommand { get; }

    public InicioViewModel()
    {
        Titulo = "FastBite Delivery 🚀";
        _deliveryService = new MockDeliveryService();

        SeleccionarCategoriaCommand = new Command<Categoria>(SeleccionarCategoria);
        AgregarAlCarritoCommand = new Command<Plato>(AgregarAlCarrito);
        VerCarritoCommand = new Command(AbrirPantallaCarrito);

        CargarDatos();
    }

    private void CargarDatos()
    {
        EstaCargando = true;

        var categorias = _deliveryService.ObtenerCategorias();
        Categorias.Clear();
        foreach (var cat in categorias)
        {
            Categorias.Add(cat);
        }

        _todosLosPlatos = _deliveryService.ObtenerPlatos();
        FiltrarPlatos("Todos");

        EstaCargando = false;
    }

    private void SeleccionarCategoria(Categoria categoriaSeleccionada)
    {
        if (categoriaSeleccionada == null) return;

        foreach (var cat in Categorias)
        {
            cat.EsSeleccionada = (cat.Id == categoriaSeleccionada.Id);
        }

        FiltrarPlatos(categoriaSeleccionada.Nombre);
    }

    private void FiltrarPlatos(string nombreCategoria)
    {
        PlatosFiltrados.Clear();

        var lista = (nombreCategoria == "Todos")
            ? _todosLosPlatos
            : _todosLosPlatos.Where(p => p.Categoria == nombreCategoria).ToList();

        foreach (var plato in lista)
        {
            PlatosFiltrados.Add(plato);
        }
    }

    // 🛒 Función que se dispara al tocar "+ Agregar"
    private void AgregarAlCarrito(Plato plato)
    {
        if (plato == null) return;

        // Guardamos el producto en nuestro servicio global
        CarritoService.Instancia.AgregarProducto(plato);

        // Mostramos una alerta rápida en pantalla
        Application.Current?.Windows[0].Page?.DisplayAlert("¡Agregado!", $"{plato.Nombre} fue añadido al carrito.", "OK");
    }

    // 🚀 Navegar a la pantalla del Carrito
    private async void AbrirPantallaCarrito()
    {
        await Application.Current?.Windows[0].Page?.Navigation.PushAsync(new CarritoPage())!;
    }
}