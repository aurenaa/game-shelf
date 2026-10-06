using GameShelf.Data;
using GameShelf.DTOs;
using GameShelf.Mappers;
using GameShelf.Models;
using Microsoft.EntityFrameworkCore;

namespace GameShelf.Services
{
    public class UserGameService : IUserGameService
    {
        private readonly IGameService _gameService;
        private readonly IRawgService _rwgService;
        private readonly AppDbContext _appDbContext;

        public UserGameService(IGameService gameService, IRawgService rawgService, AppDbContext appDbContext)
        {
            _gameService = gameService;
            _rwgService = rawgService;
            _appDbContext = appDbContext;
        }

        public async Task<UserGameDto> AddAsync(int userId, AddUserGameDto dto)
        {
            var user = await GetUserAsync(userId);
            var game = await GetGameAsync(dto.ExternalId);
            await CheckIfAddedAsync(userId, game.Id);

            var userGame = await CreateUserGameAsync(userId, game, dto);
            return UserGameMapper.ToDto(userGame);
        }

        private async Task<User> GetUserAsync(int userId)
        {
            var user = await _appDbContext.Users.FindAsync(userId);
            if (user == null) throw new Exception("User not found.");
            return user;
        }

        private async Task<Game> GetGameAsync(string externalId)
        {
            var game = await _appDbContext.Games
                .FirstOrDefaultAsync(g => g.ExternalId == externalId);

            if (game != null) return game;

            var rawgGame = await _rwgService.GetByIdAsync(externalId);
            if (rawgGame == null) throw new Exception("Game not found on RAWG.");

            game = new Game
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
            return game;
        }

        private async Task CheckIfAddedAsync(int userId, int gameId)
        {
            var exists = await _appDbContext.UserGames
                .AnyAsync(ug => ug.UserId == userId && ug.GameId == gameId);

            if (exists) throw new Exception("Game already added to profile.");
        }

        private async Task<UserGame> CreateUserGameAsync(int userId, Game game, AddUserGameDto dto)
        {
            var userGame = new UserGame
            {
                UserId = userId,
                GameId = game.Id,
                Status = dto.Status,
                Rating = dto.Rating,
                HoursPlayed = dto.HoursPlayed,
                AddedAt = DateTime.UtcNow
            };

            _appDbContext.UserGames.Add(userGame);
            await _appDbContext.SaveChangesAsync();

            userGame.Game = game;
            return userGame;
        }

        public async Task<List<UserGameDto>> GetByUserIdAsync(int userId)
        {
            var userGames = await _appDbContext.UserGames
                .Include(ug => ug.Game)
                .Where(ug => ug.UserId == userId)
                .ToListAsync();

            return UserGameMapper.ToDtoList(userGames);
        }

        public async Task<bool> RemoveAsync(int id, int userId)
        {
            var userGame = await _appDbContext.UserGames
                .FirstOrDefaultAsync(ug => ug.Id == id && ug.UserId == userId);

            if (userGame == null) return false;

            _appDbContext.UserGames.Remove(userGame);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<UserGameDto> UpdateAsync(int id, UpdateUserGameDto dto)
        {
            var userGame = await _appDbContext.UserGames
                .Include(ug => ug.Game)
                .FirstOrDefaultAsync(ug =>  ug.Id == id);

            if (userGame == null) return null;

            userGame.Status = dto.Status;
            userGame.Rating = dto.Rating;
            userGame.HoursPlayed = dto.HoursPlayed;

            await _appDbContext.SaveChangesAsync();
            return UserGameMapper.ToDto(userGame);
        }
    }
}
