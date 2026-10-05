using GameShelf.Models;

namespace GameShelf.DTOs
{
    public class GameDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public string? ImageUrl { get; set; }
        public GameType GameType { get; set; }
        public GameStatus GameStatus { get; set; }
        public int? Rating { get; set; }
        public int? HoursPlayed { get; set; }
        public int? MinPlayers { get; set; }
        public int? MaxPlayers { get; set; }
        public int? PlaytimeMinutes { get; set; }
    }
}
