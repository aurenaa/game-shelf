using GameShelf.Data;
using GameShelf.DTOs;
using GameShelf.Mappers;
using GameShelf.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.Services
{
    public class GameService : IGameService
    {
        private readonly AppDbContext _appDbContext;

        public GameService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<GameDto>> GetAllAsync()
        {
            var games = await _appDbContext.Games.ToListAsync();
            return GameMapper.ToDtoList(games);
        }

        public async Task<GameDto?> GetByIdAsync(int id)
        {
            var game = await _appDbContext.Games.FindAsync(id);
            return game == null ? null : GameMapper.ToDto(game);
        }

        public async Task<GameDto?> GetByExternalIdAsync(string externalId)
        {
            var game = await _appDbContext.Games.FirstOrDefaultAsync(g => g.ExternalId == externalId);
            return game == null ? null : GameMapper.ToDto(game);
        }

        public async Task<GameDto> CreateFromRawgAsync(RawgGameDto rawgGame)
        {
            var game = new Game
            {
                ExternalId = rawgGame.RawgId.ToString(),
                Title = rawgGame.Title,
                Description = rawgGame.Description,
                ImageUrl = rawgGame.ImageUrl,
                Genre = rawgGame.Genres != null
                    ? string.Join(", ", rawgGame.Genres.Select(g => g.Name))
                    : null,
                Publisher = rawgGame.Publishers != null
                    ? string.Join(", ", rawgGame.Publishers.Select(p => p.Name))
                    : null,
                ReleaseDate = rawgGame.ReleaseDate,
                MetacriticScore = rawgGame.MetacriticScore
            };

            _appDbContext.Games.Add(game);
            await _appDbContext.SaveChangesAsync();

            return GameMapper.ToDto(game);
        }
    }
}
