// LoginPage.xaml.cs
namespace TaskManagementApp.Pages;
public partial class LoginPage : ContentPage
{
    private const string correctCode = "123456"; // Temporary hardcoded PIN
    public LoginPage()
{
        try
        {
            InitializeComponent();
            Console.WriteLine("Reached here");
    }
        catch (Exception ex)
        {
            System.Diagnostics.Debug.WriteLine($"LoginPage constructor error: {ex}");
            throw;
        }
}

    // This stub prevents compile errors if the designer fails to generate the method.
    // Ensure your XAML file is named LoginPage.xaml and set to build action "XAML" for proper generation.
    private async void OnLoginClicked(object sender, EventArgs e)
    {
        if (CodeEntry.Text == correctCode)
        {
            await Navigation.PushAsync(new DashboardSelectorPage());
        }
        else
        {
            ErrorLabel.Text = "Invalid code. Please try again.";
            ErrorLabel.IsVisible = true;
        }
    }
}
