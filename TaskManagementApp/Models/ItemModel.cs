namespace TaskManagementApp.Models;

public class ItemModel
{
    public int ItemID { get; set; }
    public string? Type { get; set; }
    public int? Quantity { get; set; }
    public string ShopName { get; set; } = null!;
}
