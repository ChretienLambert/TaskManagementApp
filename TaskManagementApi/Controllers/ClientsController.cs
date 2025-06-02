using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ClientsController : ControllerBase
{
    private readonly TaskDbContext _context;
    public ClientsController(TaskDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ClientDto>>> GetClients()
        => await _context.Clients.Select(c => c.ToDto()).ToListAsync();

    [HttpGet("{id}")]
    public async Task<ActionResult<ClientDto>> GetClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        return client == null ? NotFound() : client.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<ClientDto>> PostClient(CreateClientDto dto)
    {
        var client = dto.ToEntity();
        _context.Clients.Add(client);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetClient), new { id = client.ClientID }, client.ToDto());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutClient(int id, CreateClientDto dto)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return NotFound();
        client.Name = dto.Name;
        client.Email = dto.Email;
        client.PhoneNo = dto.PhoneNo;
        client.ShopName = dto.ShopName;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteClient(int id)
    {
        var client = await _context.Clients.FindAsync(id);
        if (client == null) return NotFound();
        _context.Clients.Remove(client);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}