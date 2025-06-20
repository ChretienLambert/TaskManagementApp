using TaskManagementApp.Models;
using TaskManagementApp.Services;

namespace TaskManagementApp.Pages;

public partial class CreateTaskPage : ContentPage
{
    private readonly ApiService _apiService;

    public List<string> Types { get; } = new() { "General", "Homework", "Other" };
    public List<string> Statuses { get; } = new() { "Pending", "In Progress", "Completed" };

    public string SelectedType { get; set; }
    public string SelectedStatus { get; set; }

    public CreateTaskPage(ApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
        BindingContext = this;
        SelectedType = Types.First();
        SelectedStatus = Statuses.First();
    }

    private async void OnCreateTaskClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TitleEntry.Text) ||
            string.IsNullOrWhiteSpace(DescriptionEditor.Text))
        {
            await DisplayAlert("Validation", "Please enter a title and description.", "OK");
            return;
        }

        var newTask = new CreateTaskModel
        {
            Name = TitleEntry.Text,
            Description = DescriptionEditor.Text,
            Type = SelectedType,
            Status = SelectedStatus,
            StartDate = StartDatePicker.Date,
            EndDate = DueDatePicker.Date,
            UserName = "AnneNgoue",
            SchoolName = "ExcellenceAcademy",
            ShopName = "ZewouShop"
        };

        var created = await _apiService.CreateTaskAsync(newTask);
        if (created != null)
        {
            await DisplayAlert("Success", "Task created!", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Failed to create task.", "OK");
        }
    }

    private void OnTypeCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            SelectedType = (string)((CheckBox)sender).BindingContext;
            OnPropertyChanged(nameof(SelectedType));
        }
    }

    private void OnStatusCheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value)
        {
            SelectedStatus = (string)((CheckBox)sender).BindingContext;
            OnPropertyChanged(nameof(SelectedStatus));
        }
    }
}

public class CreateTypeCheckedConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (parameter is not ContentPage page || page.BindingContext is not CreateTaskPage vm || value is not string type)
            return false;
        return vm.SelectedType == type;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        => throw new NotImplementedException();
}

public class CreateStatusCheckedConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (parameter is not ContentPage page || page.BindingContext is not CreateTaskPage vm || value is not string status)
            return false;
        return vm.SelectedStatus == status;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        => throw new NotImplementedException();
}
