public class Item
{
    public int ItemID { get; set; }
    public string? Type { get; set; }
    public int? Quantity { get; set; }
    public string ShopName { get; set; } = null!;  // FK to Shop.Name

    public Shop Shop { get; set; } = null!;
}
