using GameShelf.Models;
using System.ComponentModel.DataAnnotations;

namespace GameShelf.DTOs
{
    public class AddUserGameDto
    {
        [Required]
        public string ExternalId { get; set; } = string.Empty;
        public GameStatus Status { get; set; };
        [Range(1, 5)]
        public int? Rating { get; set; }
        public int? HoursPlayed {  get; set; }
    }
}
