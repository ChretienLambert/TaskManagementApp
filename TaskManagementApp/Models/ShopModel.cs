namespace TaskManagementApp.Models;
public class Shop
{
    public string Name { get; set; } = null!;
    public string? Address { get; set; }
    public string? Email { get; set; }
    public int? PhoneNo { get; set; }
    public string UserName { get; set; } = null!;  // FK to User.Name

    public User User { get; set; } = null!;
    public ICollection<Client> Clients { get; set; } = new List<Client>();
    public ICollection<Item> Items { get; set; } = new List<Item>();
    public ICollection<TaskModel> Tasks { get; set; } = new List<TaskModel>();
}