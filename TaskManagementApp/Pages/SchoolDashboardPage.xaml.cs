using TaskManagementApp.Models;
using TaskManagementApp.Services;

namespace TaskManagementApp.Pages;

public partial class SchoolDashboardPage : ContentPage
{
    private readonly ApiService _apiService;

    public SchoolDashboardPage(ApiService apiService)
    {
        InitializeComponent();
        _apiService = apiService;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        LoadTasks(); // This should reload tasks from the DB/API
    }

    private async void LoadTasks()
    {
        var tasks = await _apiService.GetAllTasksAsync();
        TaskListView.ItemsSource = tasks;
    }

    private void OnTaskSelected(object sender, SelectionChangedEventArgs e)
    {
        var selectedTask = e.CurrentSelection.FirstOrDefault() as TaskModel;
        if (selectedTask != null)
        {
            // TODO: Handle selected task
        }
    }

    private async void OnCreateTaskClicked(object sender, EventArgs e)
    {
        var createTaskPage = App.Services?.GetRequiredService<CreateTaskPage>();
        if (createTaskPage != null)
            await Navigation.PushAsync(createTaskPage);
    }
}
