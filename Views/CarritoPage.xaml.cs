using DeliveryApp.ViewModels;

namespace DeliveryApp.Views;

public partial class CarritoPage : ContentPage
{
    public CarritoPage()
    {
        InitializeComponent();
        BindingContext = new CarritoViewModel();
    }
}