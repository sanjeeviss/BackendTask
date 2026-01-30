using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskInterview.Data;
using TaskInterview.DTOs;
using TaskInterview.Models;

namespace TaskInterview.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TasksController : SessionControllerBase
    {
        private readonly AppDbContext _context;

        public TasksController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet("filter")]
        public async Task<IActionResult> FilterTasks(
    string? status,
    string? priority,
    DateTime? dueDate)
        {
            try
            {
                int userId = GetUserId();
                string role = GetUserRole();

                IQueryable<TaskItem> query = _context.Tasks;

                if (role == "Manager")
                    query = query.Where(t => t.CreatedByUserId == userId);
                else if (role == "User")
                    query = query.Where(t => t.AssignedToUserId == userId);

                if (!string.IsNullOrEmpty(status))
                    query = query.Where(t => t.Status == status);

                if (!string.IsNullOrEmpty(priority))
                    query = query.Where(t => t.Priority == priority);

                if (dueDate.HasValue)
                    query = query.Where(t => t.DueDate.Date == dueDate.Value.Date);

                var tasks = await query.ToListAsync();
                return Ok(tasks);
            }
            catch
            {
                return Unauthorized("Please login");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetTasks()
        {
            try
            {
                int userId = GetUserId();
                string role = GetUserRole();

                IQueryable<TaskItem> query = _context.Tasks
                    .Include(t => t.AssignedToUser);

                if (role == "Manager")
                    query = query.Where(t => t.CreatedByUserId == userId);
                else if (role == "User")
                    query = query.Where(t => t.AssignedToUserId == userId);

                var tasks = await query
     .Select(t => new TaskResponseDto
     {
         Id = t.Id,
         Title = t.Title,
         Description = t.Description,
         Status = t.Status,
         Priority = t.Priority,
         DueDate = t.DueDate,
         AssignedToUserId = t.AssignedToUserId,
         AssignedToUserName = t.AssignedToUser.FullName,
         CreatedByUserId = t.CreatedByUserId
     })
     .ToListAsync();


                return Ok(tasks);
            }
            catch
            {
                return Unauthorized("Please login");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            try
            {
                int userId = GetUserId();
                string role = GetUserRole();

                var task = await _context.Tasks
                    .Include(t => t.Comments)
                    .FirstOrDefaultAsync(t => t.Id == id);

                if (task == null)
                    return NotFound("Task not found");

                bool allowed =
                    role == "Admin" ||
                    task.CreatedByUserId == userId ||
                    task.AssignedToUserId == userId;

                if (!allowed)
                    return Forbid("Access denied");

                return Ok(task);
            }
            catch
            {
                return Unauthorized("Please login");
            }
        }


        [HttpPost]
        public async Task<IActionResult> CreateTask(TaskDto dto)
        {
            try
            {
                int userId = GetUserId();

                var task = new TaskItem
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    Priority = dto.Priority,
                    Status = "To Do",
                    DueDate = dto.DueDate,
                    AssignedToUserId = dto.AssignedToUserId,
                    CreatedByUserId = userId
                };

                _context.Tasks.Add(task);
                await _context.SaveChangesAsync();

                return Ok(task);
            }
            catch
            {
                return Unauthorized("Please login");
            }
        }
    }
}
