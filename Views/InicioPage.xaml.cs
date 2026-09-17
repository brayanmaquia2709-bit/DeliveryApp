using System;
using System.Collections.Generic;
using System.Text;
using DeliveryApp.ViewModels;

namespace DeliveryApp.Views;

public partial class InicioPage : ContentPage
{
    public InicioPage()
    {
        InitializeComponent();

        // 🔗 Asignamos el ViewModel como el cerebro de datos de esta pantalla
        BindingContext = new InicioViewModel();
    }
}