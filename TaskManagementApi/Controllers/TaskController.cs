using Microsoft.AspNetCore.Mvc;          // For ApiController, ControllerBase, HttpGet, HttpPost, ActionResult
using Microsoft.EntityFrameworkCore;     // For Include() extension method
[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly TaskDbContext _context;
    public TasksController(TaskDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IEnumerable<Task>> GetTasks()
    {
        return await _context.Tasks
            .Include(t => t.User)
            .Include(t => t.School)
            .Include(t => t.Shop)
            .ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Task>> PostTask(Task task)
    {
        _context.Tasks.Add(task);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTasks), new { id = task.TaskID }, task);
    }
}
