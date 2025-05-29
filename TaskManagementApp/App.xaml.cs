namespace TaskManagementApp;

using TaskManagementApp.Pages;
using Microsoft.Extensions.DependencyInjection;

public partial class App : Application
{
    public static IServiceProvider? Services { get; set; }

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();

        Services = serviceProvider;

        MainPage = new NavigationPage(serviceProvider.GetRequiredService<DashboardSelectorPage>());
    }
}
