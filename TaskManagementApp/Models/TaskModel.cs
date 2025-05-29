namespace TaskManagementApp.Models;
public class TaskModel
{
    public int TaskID { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Status { get; set; }  // Note: spelling matches your DB
    public string UserName { get; set; } = null!;  // FK User.Name
    public string SchoolName { get; set; } = null!;  // FK School.Name
    public string ShopName { get; set; } = null!;  // FK Shop.Name

    public User User { get; set; } = null!;
    public School School { get; set; } = null!;
    public Shop Shop { get; set; } = null!;
}