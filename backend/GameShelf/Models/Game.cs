namespace GameShelf.Models
{
    public class Game
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

        public Game() { }
        public Game(int id, string title, string description, string publisher, string genre, string imageUrl, GameType gameType, GameStatus gameStatus, int rating, int hoursPlayed, int minPlayers, int maxPlayers, int playtimeMinutes)
        {
            Id = id;
            Title = title;
            Description = description;
            Publisher = publisher;
            Genre = genre;
            ImageUrl = imageUrl;
            GameType = gameType;
            GameStatus = gameStatus;
            Rating = rating;
            HoursPlayed = hoursPlayed;
            MinPlayers = minPlayers;
            MaxPlayers = maxPlayers;
            PlaytimeMinutes = playtimeMinutes;
        }
    }
}
