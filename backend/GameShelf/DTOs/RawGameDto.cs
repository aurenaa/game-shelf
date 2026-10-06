using System.Text.Json.Serialization;

namespace GameShelf.DTOs
{
    public class RawgGameDto
    {
        [JsonPropertyName("id")]
        public int RawgId { get; set; }

        [JsonPropertyName("name")]
        public string Title { get; set; } = string.Empty;

        [JsonPropertyName("description_raw")]
        public string? Description { get; set; }

        [JsonPropertyName("background_image")]
        public string? ImageUrl { get; set; }

        [JsonPropertyName("released")]
        public DateTime? ReleaseDate { get; set; }

        [JsonPropertyName("metacritic")]
        public int? MetacriticScore { get; set; }

        [JsonPropertyName("genres")]
        public List<RawgGenreDto>? Genres { get; set; }

        [JsonPropertyName("publishers")]
        public List<RawgPublisherDto>? Publishers { get; set; }
    }

    public class RawgGenreDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class RawgPublisherDto
    {
        [JsonPropertyName("name")]
        public string Name { get; set; } = string.Empty;
    }

    public class RawgSearchResponse
    {
        [JsonPropertyName("count")]
        public int Count { get; set; }

        [JsonPropertyName("results")]
        public List<RawgGameDto> Results { get; set; } = new();
    }
}
