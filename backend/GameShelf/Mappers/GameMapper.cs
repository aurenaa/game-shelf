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
                ExternalId = game.ExternalId,
                Title = game.Title,
                Description = game.Description,
                Publisher = game.Publisher,
                Genre = game.Genre,
                ImageUrl = game.ImageUrl,
                BackgroundImage = game.BackgroundImage,
                ReleaseDate = game.ReleaseDate,
                MetacriticScore = game.MetacriticScore
            };
        }

        public static List<GameDto> ToDtoList(List<Game> games)
        {
            return games.Select(ToDto).ToList();
        }
    }
}