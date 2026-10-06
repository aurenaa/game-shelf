using GameShelf.DTOs;
using GameShelf.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserGamesController : ControllerBase
    {
        private readonly IUserGameService _userGameService;

        public UserGamesController(IUserGameService userGameService)
        {
            _userGameService = userGameService;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAll(int userId)
        {
            var games = await _userGameService.GetByUserIdAsync(userId);
            return Ok(games);
        }

        [HttpPost("{userId}")]
        public async Task<IActionResult> AddUserGame(int userId, [FromBody] AddUserGameDto dto)
        {
            var userGame = await _userGameService.AddAsync(userId, dto);
            return Ok(userGame);
        }

        [HttpDelete("{userId}/{id}")]
        public async Task<IActionResult> RemoveUserGame(int userId, int id)
        {
            var deleted = await _userGameService.RemoveAsync(id, userId);
            if (!deleted) return NotFound();
            return NoContent();
        }

        [HttpPut("{userId}/{id}")]
        public async Task<IActionResult> UpdateUserGame(int userId, int id, [FromBody] UpdateUserGameDto dto)
        {
            var userGame = await _userGameService.UpdateAsync(id, dto);
            if (userGame == null) return NotFound();
            return Ok(userGame);
        }
    }
}
