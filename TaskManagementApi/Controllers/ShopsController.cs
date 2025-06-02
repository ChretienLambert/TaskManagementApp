using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ShopsController : ControllerBase
{
    private readonly TaskDbContext _context;
    public ShopsController(TaskDbContext context) => _context = context;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ShopDto>>> GetShops()
        => await _context.Shops.Select(s => s.ToDto()).ToListAsync();

    [HttpGet("{name}")]
    public async Task<ActionResult<ShopDto>> GetShop(string name)
    {
        var shop = await _context.Shops.FindAsync(name);
        return shop == null ? NotFound() : shop.ToDto();
    }

    [HttpPost]
    public async Task<ActionResult<ShopDto>> PostShop(CreateShopDto dto)
    {
        var shop = dto.ToEntity();
        _context.Shops.Add(shop);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetShop), new { name = shop.Name }, shop.ToDto());
    }

    [HttpPut("{name}")]
    public async Task<IActionResult> PutShop(string name, CreateShopDto dto)
    {
        var shop = await _context.Shops.FindAsync(name);
        if (shop == null) return NotFound();
        shop.Address = dto.Address;
        shop.Email = dto.Email;
        shop.PhoneNo = dto.PhoneNo;
        shop.UserName = dto.UserName;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteShop(string name)
    {
        var shop = await _context.Shops.FindAsync(name);
        if (shop == null) return NotFound();
        _context.Shops.Remove(shop);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}