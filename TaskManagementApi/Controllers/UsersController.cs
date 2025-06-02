using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly TaskDbContext _context;
    public UsersController(TaskDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        => await _context.Users.Select(u => u.ToDto()).ToListAsync();

    [HttpGet("{name}")]
    public async Task<ActionResult<UserDto>> GetUser(string name)
    {
        var user = await _context.Users.FindAsync(name);
        return user == null ? NotFound() : user.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<UserDto>> PostUser(CreateUserDto dto)
    {
        var user = dto.ToEntity();
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetUser), new { name = user.Name }, user.ToDto());
    }

    [HttpPut("{name}")]
    public async Task<IActionResult> PutUser(string name, CreateUserDto dto)
    {
        var user = await _context.Users.FindAsync(name);
        if (user == null) return NotFound();
        user.Email = dto.Email;
        user.PhoneNo = dto.PhoneNo;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteUser(string name)
    {
        var user = await _context.Users.FindAsync(name);
        if (user == null) return NotFound();
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}