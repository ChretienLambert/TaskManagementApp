using TaskManagementApp.Models;
using TaskManagementApp.Services;

namespace TaskManagementApp.Pages;

public partial class UpdateTaskPage : ContentPage
{
    private readonly ApiService _apiService;
    private readonly TaskModel _task;

    public List<string> Types { get; } = new() { "General", "Homework", "Other" };
    public List<string> Statuses { get; } = new() { "Pending", "In Progress", "Completed" };

    public string SelectedType { get; set; }
    public string SelectedStatus { get; set; }

    public UpdateTaskPage(ApiService apiService, TaskModel task)
    {
        InitializeComponent();
        _apiService = apiService;
        _task = task;
        BindingContext = this;

        TitleEntry.Text = task.Name;
        DescriptionEditor.Text = task.Description;
        SelectedType = Types.Contains(task.Type ?? string.Empty) ? (task.Type ?? Types.First()) : Types.First();
        SelectedStatus = Statuses.Contains(task.Status ?? string.Empty) ? (task.Status ?? Statuses.First()) : Statuses.First();
        StartDatePicker.Date = task.StartDate ?? DateTime.Now;
        EndDatePicker.Date = task.EndDate ?? DateTime.Now;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _task.Name = TitleEntry.Text;
        _task.Description = DescriptionEditor.Text;
        _task.Type = SelectedType;
        _task.Status = SelectedStatus;
        _task.StartDate = StartDatePicker.Date;
        _task.EndDate = EndDatePicker.Date;

        var updated = await _apiService.UpdateTaskAsync(_task);
        if (updated)
        {
            await DisplayAlert("Success", "Task updated!", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            await DisplayAlert("Error", "Failed to update task.", "OK");
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

public class UpdateTypeCheckedConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (parameter is not ContentPage page || page.BindingContext is not UpdateTaskPage vm || value is not string type)
            return false;
        return vm.SelectedType == type;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        => throw new NotImplementedException();
}

public class UpdateStatusCheckedConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
    {
        if (parameter is not ContentPage page || page.BindingContext is not UpdateTaskPage vm || value is not string status)
            return false;
        return vm.SelectedStatus == status;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, System.Globalization.CultureInfo culture)
        => throw new NotImplementedException();
}