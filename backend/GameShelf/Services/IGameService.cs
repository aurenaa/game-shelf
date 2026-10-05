using GameShelf.DTOs;

namespace GameShelf.Services;

public interface IGameService
{
    Task<List<GameDto>> GetAllAsync();
    Task<GameDto?> GetByIdAsync(int id);
    Task<GameDto?> CreateAsync(CreateGameDto dto);
    Task<GameDto?> UpdateAsync(int id, UpdateGameDto dto);
    Task<bool> DeleteAsync(int id);
}