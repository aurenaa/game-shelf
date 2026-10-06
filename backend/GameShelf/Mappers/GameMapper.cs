using GameShelf.DTOs;
using GameShelf.Models;

namespace GameShelf.Mappers
{
    public static class GameMapper
    {
        public static GameDto ToDto(Game game)
        {
            return new GameDto
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Publisher = game.Publisher,
                Genre = game.Genre,
                ImageUrl = game.ImageUrl,
                GameStatus = game.GameStatus,
                Rating = game.Rating,
                HoursPlayed = game.HoursPlayed,
                MinPlayers = game.MinPlayers,
                MaxPlayers = game.MaxPlayers,
                PlaytimeMinutes = game.PlaytimeMinutes,
            };
        }

        public static Game ToModel(CreateGameDto dto)
        {
            return new Game
            {
                Title = dto.Title,
                Description = dto.Description,
                Publisher = dto.Publisher,
                Genre = dto.Genre,
                ImageUrl = dto.ImageUrl,
                GameStatus = dto.GameStatus,
                Rating = dto.Rating,
                HoursPlayed = dto.HoursPlayed,
                MinPlayers = dto.MinPlayers,
                MaxPlayers = dto.MaxPlayers,
                PlaytimeMinutes = dto.PlaytimeMinutes,
            };
        }

        public static List<GameDto> ToDtoList(List<Game> games)
        {
            return games.Select(ToDto).ToList();
        }
    }
}