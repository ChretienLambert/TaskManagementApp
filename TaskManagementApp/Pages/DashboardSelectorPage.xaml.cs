namespace TaskManagementApp.Pages;

public partial class DashboardSelectorPage : ContentPage
{
    public DashboardSelectorPage()
    {
        InitializeComponent();
    }

    private async void OnSchoolDashboardClicked(object sender, EventArgs e)
{
    if (App.Services is not null)
    {
        var schoolPage = App.Services.GetRequiredService<SchoolDashboardPage>();
        await Navigation.PushAsync(schoolPage);
    }
    else
    {
        // Handle the null case appropriately, e.g., show an error message
        await DisplayAlert("Error", "Service provider is not available.", "OK");
    }
}

    private async void OnShopDashboardClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShopDashboardPage());
    }
}
