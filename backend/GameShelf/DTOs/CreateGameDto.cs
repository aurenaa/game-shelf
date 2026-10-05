using GameShelf.Models;
using Microsoft.OpenApi.MicrosoftExtensions;
using System.ComponentModel.DataAnnotations;

namespace GameShelf.DTOs
{
    public class CreateGameDto
    {
        [Required(ErrorMessage = "The title is mandatory.")]
        [StringLength(100)]
        public string Title { get; set; } = string.Empty;
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
