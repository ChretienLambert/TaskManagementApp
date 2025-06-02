using TaskManagementApp.Models;
using TaskManagementApp.Services;

namespace TaskManagementApp.Pages;

public partial class CreateTaskPage : ContentPage
{
    private readonly ApiService _apiService;

    public CreateTaskPage(ApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    private async void OnCreateTaskClicked(object sender, EventArgs e)
    {
        var newTask = new TaskModel
        {
            Name = TitleEntry.Text,
            Description = DescriptionEditor.Text,
            Type = TypeComboBox.SelectedItem?.ToString() ?? "",
            Status = StatusComboBox.SelectedItem?.ToString() ?? "",
            StartDate = StartDatePicker.Date,
            EndDate = DueDatePicker.Date
        };

        Console.WriteLine($"[DEBUG] Creating task: {System.Text.Json.JsonSerializer.Serialize(newTask)}");

        var created = await _apiService.CreateTaskAsync(newTask);
        if (created != null)
        {
            Console.WriteLine("[DEBUG] Task created successfully.");
            await DisplayAlert("Success", "Task created!", "OK");
            await Navigation.PopAsync();
        }
        else
        {
            Console.WriteLine("[DEBUG] Task creation failed.");
            await DisplayAlert("Error", "Failed to create task.", "OK");
        }
    }
}
