namespace TaskManagementApp.Models;

public class CreateTaskModel
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Description { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public string? Status { get; set; }
    public string UserName { get; set; } = "AnneNgoue";
    public string SchoolName { get; set; } = "ExcellenceAcademy";
    public string ShopName { get; set; } = "ZewouShop";
}