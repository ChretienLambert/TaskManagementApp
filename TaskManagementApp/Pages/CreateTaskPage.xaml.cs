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

        // Set default selections if needed
        TypePicker.SelectedIndex = 0;
        StatusPicker.SelectedIndex = 0;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        string title = TitleEntry.Text?.Trim() ?? string.Empty;
        string type = TypePicker.SelectedItem?.ToString() ?? "";
        string description = DescriptionEditor.Text?.Trim() ?? string.Empty;
        DateTime startDate = StartDatePicker.Date;
        DateTime dueDate = DueDatePicker.Date;
        string status = StatusPicker.SelectedItem?.ToString() ?? "";

        if (string.IsNullOrWhiteSpace(title))
        {
            await DisplayAlert("Validation Error", "Please fill in required fields: Title, School Name, Shop Name.", "OK");
            return;
        }

        var newTask = new TaskModel
        {
            Name = title,
            Description = description,
            Type = type,
            StartDate = startDate,
            EndDate = dueDate,
            Status = status,
        };

        var createdTask = await _apiService.CreateTaskAsync(newTask);
        if (createdTask != null)
        {
            await DisplayAlert("Success", "Task created successfully!", "OK");
            await Navigation.PopAsync(); // Go back to dashboard
        }
        else
        {
            StatusLabel.TextColor = Colors.Red;
            StatusLabel.Text = "Failed to create task.";
        }
    }

    private void OnCreateTaskClicked(object sender, EventArgs e)
    {
        // TODO: Add navigation or logic for creating a task
    }
}
