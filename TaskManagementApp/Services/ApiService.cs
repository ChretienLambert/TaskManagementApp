using System.Net.Http.Json;
using TaskManagementApp.Models;

namespace TaskManagementApp.Services;

public class ApiService
{
    private readonly HttpClient _httpClient;
    private const string BaseUrl = "http://localhost:5000/api"; // Change if needed

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<TaskModel>> GetAllTasksAsync()
    {
        return await _httpClient.GetFromJsonAsync<List<TaskModel>>($"{BaseUrl}/tasks") ?? new();
    }

    public async Task<TaskModel?> CreateTaskAsync(TaskModel newTask)
    {
        var response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/tasks", newTask);
        if (response.IsSuccessStatusCode)
            return await response.Content.ReadFromJsonAsync<TaskModel>();
        return null;
    }
}
