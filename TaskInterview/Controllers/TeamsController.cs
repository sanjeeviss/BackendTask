using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskInterview.Data;
using TaskInterview.DTOs;
using TaskInterview.Models;

namespace TaskInterview.Controllers
{
    [ApiController]
    [Route("api/teams")]
    public class TeamsController : ControllerBase
    {
        private readonly AppDbContext _context;
        public TeamsController(AppDbContext context) => _context = context;

       
        [HttpPost]
        public async Task<IActionResult> CreateTeam(TeamDto dto)
        {
            var team = new Team
            {
                Name = dto.Name,
                ManagerId = dto.ManagerId
            };
            _context.Teams.Add(team);
            await _context.SaveChangesAsync();
            return Ok(team);
        }

        [HttpPost("{teamId}/users")]
        public async Task<IActionResult> AssignUsers(int teamId, [FromBody] List<int> userIds)
        {
            var team = await _context.Teams.FindAsync(teamId);
            if (team == null) return NotFound();

            foreach (var userId in userIds)
            {
                if (!await _context.TeamUsers.AnyAsync(tu => tu.TeamId == teamId && tu.UserId == userId))
                {
                    _context.TeamUsers.Add(new TeamUser
                    {
                        TeamId = teamId,
                        UserId = userId
                    });
                }
            }
            await _context.SaveChangesAsync();
            return Ok("Users assigned successfully.");
        }

       
        [HttpGet]
        public async Task<IActionResult> GetTeams()
        {
            var teams = await _context.Teams
                .Include(t => t.Manager)
                .Include(t => t.TeamUsers)
                    .ThenInclude(tu => tu.User)
                .Select(t => new TeamResponseDto
                {
                    Id = t.Id,
                    Name = t.Name,
                    ManagerId = t.ManagerId,
                    ManagerName = t.Manager.FullName,

                    Users = t.TeamUsers.Select(tu => new TeamUserDto
                    {
                        UserId = tu.UserId,
                        UserName = tu.User.FullName
                    }).ToList()
                })
                .ToListAsync();

            return Ok(teams);
        }

    }
}
