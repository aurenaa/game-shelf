using GameShelf.DTOs;

namespace GameShelf.Services
{
    public interface IRawgService
    {
        Task<List<RawgGameDto>> SearchAsync(string query);
        Task<RawgGameDto?> GetByIdAsync(string externalId);
    }
}
