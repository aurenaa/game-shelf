using GameShelf.Models;

namespace GameShelf.DTOs
{
    public class UserGameDto
    {
        public int Id { get; set; }
        public int GameId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public string? Genre { get; set; }
        public GameStatus Status { get; set; }
        public int? Rating { get; set; }
        public int? HoursPlayed { get; set; }
        public DateTime AddedAt { get; set; }
    }
}
