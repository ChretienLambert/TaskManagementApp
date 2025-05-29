public class Client
{
    public int ClientID { get; set; }
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public int? PhoneNo { get; set; }
    public string ShopName { get; set; } = null!;  // FK to Shop.Name

    public Shop Shop { get; set; } = null!;
}
