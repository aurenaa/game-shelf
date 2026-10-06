namespace GameShelf.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string ExternalId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? Publisher { get; set; }
        public string? Genre { get; set; }
        public string? ImageUrl { get; set; }
        public string? BackgroundImage { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? MetacriticScore { get; set; }
        public List<UserGame> UserGames { get; set; } = new();

        public Game() { }
    }
}
