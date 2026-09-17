using Microsoft.Extensions.DependencyInjection;

namespace DeliveryApp;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
        MainPage = new NavigationPage(new Views.InicioPage());
    }

	protected override Window CreateWindow(IActivationState? activationState)
	{
		return new Window(new AppShell());
	}
}