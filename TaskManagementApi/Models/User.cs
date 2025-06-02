public class User
{
    public string Name { get; set; } = null!;
    public string? Email { get; set; }
    public int? PhoneNo { get; set; }

    public ICollection<Shop> Shops { get; set; } = new List<Shop>();
    public ICollection<School> School { get; set; } = new List<School>();
    public ICollection<Task> Tasks { get; set; } = new List<Task>();
}