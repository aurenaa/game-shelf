using GameShelf.DTOs;
using GameShelf.Models;

namespace GameShelf.Mappers
{
    public class UserGameMapper
    {
        public static UserGameDto ToDto(UserGame userGame)
        {
            return new UserGameDto
            {
                Id = userGame.Id,
                GameId = userGame.GameId,
                Title = userGame.Game.Title,
                ImageUrl = userGame.Game.ImageUrl,
                Genre = userGame.Game.Genre,
                Status = userGame.Status,
                Rating = userGame.Rating,
                HoursPlayed = userGame.HoursPlayed,
                AddedAt = userGame.AddedAt
            };
        }

        public static List<UserGameDto> ToDtoList(List<UserGame> userGames)
        {
            return userGames.Select(ToDto).ToList();
        }
    }
}
