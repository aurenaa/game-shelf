using GameShelf.DTOs;

namespace GameShelf.Services
{
    public interface IUserGameService
    {
        Task<List<UserGameDto>> GetByUserIdAsync(int userId);
        Task<UserGameDto> AddAsync(int userId, AddUserGameDto dto);
        Task<UserGameDto> UpdateAsync(int userId, UpdateUserGameDto dto);
        Task<bool> RemoveAsync(int id);
    }
}
