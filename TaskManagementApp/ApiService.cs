using System.Net.Http.Json;
using TaskManagementApp.Models;
using System.Collections.ObjectModel;

namespace TaskManagementApp.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "http://localhost:5257/api";
    // Change if needed

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TaskModel>> GetAllTasksAsync()
    {
        Console.WriteLine("[DEBUG] Fetching all tasks from API...");
        var result = await _httpClient.GetFromJsonAsync<List<TaskModel>>($"{BaseUrl}/tasks") ?? new();
        Console.WriteLine($"[DEBUG] API returned {result.Count} tasks.");
        return result;
    }

    public async Task<TaskModel?> CreateTaskAsync(TaskModel newTask)
    {
        Console.WriteLine("[DEBUG] Sending create task request to API...");
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/tasks", newTask);
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("[DEBUG] API create task success.");
            return await response.Content.ReadFromJsonAsync<TaskModel>();
        }
        Console.WriteLine("[DEBUG] API create task failed.");
        return null;
    }

    public ObservableCollection<TaskModel> Tasks { get; set; } = new();

    public async Task LoadTasksAsync()
    {
        var tasks = await GetAllTasksAsync();
        Tasks.Clear();
        foreach (var task in tasks)
            Tasks.Add(task);
    }
}
