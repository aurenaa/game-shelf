using GameShelf.DTOs;

namespace GameShelf.Services;

public interface IGameService
{
    Task<List<GameDto>> GetAllAsync();
    Task<GameDto?> GetByIdAsync(int id);
    Task<GameDto?> GetByExternalIdAsync(string externalId);
    Task<GameDto> CreateFromRawgAsync(RawgGameDto rawGame);
}