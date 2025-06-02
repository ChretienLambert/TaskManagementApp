public static class MappingExtensions
{
    public static UserDto ToDto(this User user) => new()
    {
        Name = user.Name,
        Email = user.Email,
        PhoneNo = user.PhoneNo
    };
    public static User ToEntity(this CreateUserDto dto) => new()
    {
        Name = dto.Name,
        Email = dto.Email,
        PhoneNo = dto.PhoneNo
    };

    public static ShopDto ToDto(this Shop shop) => new()
    {
        Name = shop.Name,
        Address = shop.Address,
        Email = shop.Email,
        PhoneNo = shop.PhoneNo,
        UserName = shop.UserName
    };
    public static Shop ToEntity(this CreateShopDto dto) => new()
    {
        Name = dto.Name,
        Address = dto.Address,
        Email = dto.Email,
        PhoneNo = dto.PhoneNo,
        UserName = dto.UserName
    };

    public static SchoolDto ToDto(this School school) => new()
    {
        Name = school.Name,
        Address = school.Address,
        Email = school.Email,
        PhoneNo = school.PhoneNo,
        UserName = school.UserName
    };
    public static School ToEntity(this CreateSchoolDto dto) => new()
    {
        Name = dto.Name,
        Address = dto.Address,
        Email = dto.Email,
        PhoneNo = dto.PhoneNo,
        UserName = dto.UserName
    };

    public static ClientDto ToDto(this Client client) => new()
    {
        ClientID = client.ClientID,
        Name = client.Name,
        Email = client.Email,
        PhoneNo = client.PhoneNo,
        ShopName = client.ShopName
    };
    public static Client ToEntity(this CreateClientDto dto) => new()
    {
        Name = dto.Name,
        Email = dto.Email,
        PhoneNo = dto.PhoneNo,
        ShopName = dto.ShopName ?? string.Empty
    };

    public static ItemDto ToDto(this Item item) => new()
    {
        ItemID = item.ItemID,
        Type = item.Type,
        Quantity = item.Quantity,
        ShopName = item.ShopName
    };
    public static Item ToEntity(this CreateItemDto dto) => new()
    {
        Type = dto.Type,
        Quantity = dto.Quantity,
        ShopName = dto.ShopName ?? string.Empty
    };

    // Task mapping (assuming you have a Task entity)
    public static TaskDto ToDto(this Task task) => new()
    {
        TaskID = task.TaskID,
        Name = task.Name,
        Type = task.Type,
        Description = task.Description,
        StartDate = task.StartDate,
        EndDate = task.EndDate,
        Status = task.Status,
        UserName = task.UserName,
        SchoolName = task.SchoolName,
        ShopName = task.ShopName
    };
    public static Task ToEntity(this CreateTaskDto dto) => new()
    {
        Name = dto.Name,
        Type = dto.Type,
        Description = dto.Description,
        StartDate = dto.StartDate,
        EndDate = dto.EndDate,
        Status = dto.Status,
        UserName = dto.UserName,
        SchoolName = dto.SchoolName,
        ShopName = dto.ShopName
    };
}