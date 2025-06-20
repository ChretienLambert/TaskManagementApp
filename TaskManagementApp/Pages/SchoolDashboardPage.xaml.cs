using System.Collections.ObjectModel;
using System.Windows.Input;
using TaskManagementApp.Models;
using TaskManagementApp.Services;

namespace TaskManagementApp.Pages;

public partial class SchoolDashboardPage : ContentPage
{
    private readonly ApiService _apiService;

    public ObservableCollection<TaskModel> Tasks { get; set; } = new();

    public ICommand DeleteTaskCommand { get; }
    public ICommand UpdateTaskCommand { get; }

    public List<string> Types { get; } = new() { "General", "Homework", "Other" };
    public List<string> Statuses { get; } = new() { "Pending", "In Progress", "Completed" };

    public SchoolDashboardPage(ApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
        BindingContext = this;

        DeleteTaskCommand = new Command<TaskModel>(async (task) => await DeleteTaskAsync(task));
        UpdateTaskCommand = new Command<TaskModel>(async (task) => await UpdateTaskAsync(task));
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTasks();
    }

    private async void LoadTasks()
    {
        try
        {
            var allTasks = await _apiService.GetTasksAsync();
            Tasks.Clear();
            foreach (var task in allTasks)
                Tasks.Add(task);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Failed to load tasks: {ex.Message}");
        }
    }

    private async void OnCreateTaskClicked(object sender, EventArgs e)
    {
        if (App.Services is not null)
        {
            var createPage = App.Services.GetRequiredService<CreateTaskPage>();
            await Navigation.PushAsync(createPage);
        }
        else
        {
            await DisplayAlert("Error", "Service provider is not available.", "OK");
        }
    }

    private async Task DeleteTaskAsync(TaskModel task)
    {
        bool confirm = await DisplayAlert("Delete", $"Delete task '{task.Name}'?", "Yes", "No");
        if (!confirm) return;

        bool success = await _apiService.DeleteTaskAsync(task.TaskID);
        if (success)
        {
            Tasks.Remove(task);
        }
        else
        {
            await DisplayAlert("Error", "Failed to delete task.", "OK");
        }
    }

    private async Task UpdateTaskAsync(TaskModel task)
    {
        await Navigation.PushAsync(new UpdateTaskPage(_apiService, task));
    }
}
