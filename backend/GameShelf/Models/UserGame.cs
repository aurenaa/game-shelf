namespace GameShelf.Models
{
    public class UserGame
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public int GameId { get; set; }
        public Game Game { get; set; }
        public GameStatus Status { get; set; }
        public int? Rating { get; set; }
        public int? HoursPlayed { get; set; }
        public DateTime AddedAt { get; set; } = DateTime.UtcNow;
    }
}
