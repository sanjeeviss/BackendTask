using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskInterview.Data;
using TaskInterview.DTOs;
using TaskInterview.Models;

namespace TaskInterview.Controllers
{
    [ApiController]
    [Route("api/comments")]
    public class CommentsController : SessionControllerBase
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllComments()
        {
            var comments = await _context.Comments
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new
                {
                    c.Id,
                    c.Message,
                    c.CreatedAt,
                    c.TaskId
                })
                .ToListAsync();

            return Ok(comments);
        }


        [HttpGet("task/{taskId}")]
        public async Task<IActionResult> GetCommentsByTask(int taskId)
        {
            var comments = await _context.Comments
                .Where(c => c.TaskId == taskId)
                .Include(c => c.CreatedByUser)
                .OrderByDescending(c => c.CreatedAt)
                .Select(c => new CommentResponseDto
                {
                    Id = c.Id,
                    Message = c.Message,
                    CreatedAt = c.CreatedAt,
                    CreatedByUserId = c.CreatedByUserId,
                    CreatedByUserName = c.CreatedByUser.FullName
                })
                .ToListAsync();

            return Ok(comments);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(CommentDto dto)
        {
            try
            {
                int userId = GetUserId();

                var task = await _context.Tasks.FindAsync(dto.TaskId);
                if (task == null)
                    return NotFound("Task not found");

                var comment = new Comment
                {
                    Message = dto.Message,
                    TaskId = dto.TaskId,
                    CreatedByUserId = userId,
                    CreatedAt = DateTime.UtcNow
                };

                _context.Comments.Add(comment);
                await _context.SaveChangesAsync();

                return Ok(comment);
            }
            catch
            {
                return Unauthorized("Please login");
            }
        }

    }
}

