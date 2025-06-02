using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class SchoolsController : ControllerBase
{
    private readonly TaskDbContext _context;
    public SchoolsController(TaskDbContext context) => _context = context;

    // GET: api/Schools
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SchoolDto>>> GetSchools() =>
        await _context.Schools.Select(s => s.ToDto()).ToListAsync();

    // GET: api/Schools/{name}
    [HttpGet("{name}")]
    public async Task<ActionResult<SchoolDto>> GetSchool(string name)
    {
        var school = await _context.Schools.FindAsync(name);
        return school == null ? NotFound() : school.ToDto();
    }

    // POST: api/Schools
    [HttpPost]
    public async Task<ActionResult<SchoolDto>> PostSchool(CreateSchoolDto dto)
    {
        var school = dto.ToEntity();
        _context.Schools.Add(school);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetSchool), new { name = school.Name }, school.ToDto());
    }

    // PUT: api/Schools/{name}
    [HttpPut("{name}")]
    public async Task<IActionResult> PutSchool(string name, CreateSchoolDto dto)
    {
        var school = await _context.Schools.FindAsync(name);
        if (school == null) return NotFound();
        school.Address = dto.Address;
        school.Email = dto.Email;
        school.PhoneNo = dto.PhoneNo;
        school.UserName = dto.UserName;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/Schools/{name}
    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteSchool(string name)
    {
        var school = await _context.Schools.FindAsync(name);
        if (school == null) return NotFound();
        _context.Schools.Remove(school);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}