using DeliveryApp.ViewModels;

namespace DeliveryApp.Views;

public partial class RastreoPage : ContentPage
{
    public RastreoPage()
    {
        InitializeComponent();
        BindingContext = new RastreoViewModel();
    }
}