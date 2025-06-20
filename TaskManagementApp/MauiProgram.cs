using TaskManagementApp.Services;
using TaskManagementApp.Pages;
using TaskManagementApp;
using CommunityToolkit.Maui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>() // This tells Maui to use the App class as the root
            .UseMauiCommunityToolkit() // <-- Add this line
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        // Dependency Injection setup
        builder.Services.AddHttpClient<ApiService>();
        builder.Services.AddTransient<SchoolDashboardPage>();
        builder.Services.AddTransient<DashboardSelectorPage>();
        builder.Services.AddTransient<CreateTaskPage>();
        builder.Services.AddSingleton<App>();

        // Register App so DI can inject IServiceProvider
        builder.Services.AddSingleton<App>();

        // ✅ Now build the app
        var mauiApp = builder.Build();

        // ✅ Assign the global service provider for later use
        App.Services = mauiApp.Services;

        return mauiApp;
    }
}