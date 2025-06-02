namespace TaskManagementApp.Models;

public class ClientModel
{
    public int ClientID { get; set; }
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public int? PhoneNo { get; set; }
    public string ShopName { get; set; } = null!;
}
