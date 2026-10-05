using GameShelf.Data;
using GameShelf.DTOs;
using GameShelf.Mappers;
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

        public async Task<GameDto?> CreateAsync(CreateGameDto dto)
        {
            var game = GameMapper.ToModel(dto);
            _appDbContext.Games.Add(game);
            await _appDbContext.SaveChangesAsync();
            return GameMapper.ToDto(game);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var game = await _appDbContext.Games.FindAsync(id);
            if (game == null) return false;

            _appDbContext.Games.Remove(game);
            await _appDbContext.SaveChangesAsync();
            return true;
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

        public async Task<GameDto?> UpdateAsync(int id, UpdateGameDto dto)
        {
            var game = await _appDbContext.Games.FindAsync(id);
            if (game == null) return null;

            game.Title = dto.Title;
            game.Description = dto.Description;
            game.Publisher = dto.Publisher;
            game.Genre = dto.Genre;
            game.ImageUrl = dto.ImageUrl;
            game.GameType = dto.GameType;
            game.GameStatus = dto.GameStatus;
            game.Rating = dto.Rating;
            game.HoursPlayed = dto.HoursPlayed;
            game.MinPlayers = dto.MinPlayers;
            game.MaxPlayers = dto.MaxPlayers;
            game.PlaytimeMinutes = dto.PlaytimeMinutes;

            await _appDbContext.SaveChangesAsync();
            return GameMapper.ToDto(game);
        }
    }
}
