using GameShelf.DTOs;
using GameShelf.Services;
using Microsoft.AspNetCore.Mvc;

namespace GameShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IRawgService _rawgService;

        public GamesController(IGameService gameService, IRawgService rawgService)
        {
            _gameService = gameService;
            _rawgService = rawgService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var games = await _gameService.GetAllAsync();
            return Ok(games);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var game = await _gameService.GetByIdAsync(id);
            if (game == null) return NotFound();
            return Ok(game);
        }

        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Query is required.");

            var games = await _rawgService.SearchAsync(query);
            return Ok(games);
        }

    }
}
