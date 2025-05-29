// Data/TaskDbContext.cs
using Microsoft.EntityFrameworkCore;
public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) {}

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Shop> Shops { get; set; } = null!;
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Item> Items { get; set; } = null!;
    public DbSet<School> Schools { get; set; } = null!;
    public DbSet<Task> Tasks { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().HasKey(u => u.Name);
        modelBuilder.Entity<Shop>().HasKey(s => s.Name);
        modelBuilder.Entity<School>().HasKey(s => s.Name);
        modelBuilder.Entity<Client>().HasKey(c => c.ClientID);
        modelBuilder.Entity<Item>().HasKey(i => i.ItemID);
        modelBuilder.Entity<Task>().HasKey(t => t.TaskID);

        modelBuilder.Entity<Shop>()
            .HasOne(s => s.User)
            .WithMany(u => u.Shops)
            .HasForeignKey(s => s.UserName);

        modelBuilder.Entity<Client>()
            .HasOne(c => c.Shop)
            .WithMany(s => s.Clients)
            .HasForeignKey(c => c.ShopName);

        modelBuilder.Entity<Item>()
            .HasOne(i => i.Shop)
            .WithMany(s => s.Items)
            .HasForeignKey(i => i.ShopName);

        modelBuilder.Entity<School>()
            .HasOne(s => s.User)
            .WithMany(u => u.School)
            .HasForeignKey(s => s.UserName);

        modelBuilder.Entity<Task>()
            .HasOne(t => t.User)
            .WithMany(u => u.Tasks)
            .HasForeignKey(t => t.UserName)
            .OnDelete(DeleteBehavior.Restrict); // 🚫 No cascade delete

        modelBuilder.Entity<Task>()
            .HasOne(t => t.School)
            .WithMany(s => s.Tasks)
            .HasForeignKey(t => t.SchoolName)
            .OnDelete(DeleteBehavior.Restrict); // 🚫 No cascade delete

        modelBuilder.Entity<Task>()
            .HasOne(t => t.Shop)
            .WithMany(s => s.Tasks)
            .HasForeignKey(t => t.ShopName)
            .OnDelete(DeleteBehavior.Restrict); // 🚫 No cascade delete
    }
}