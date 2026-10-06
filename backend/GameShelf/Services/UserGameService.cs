using GameShelf.DTOs;

namespace GameShelf.Services
{
    public class UserGameService : IUserGameService
    {
        public async Task<UserGameDto> AddAsync(int userId, AddUserGameDto dto)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserGameDto>> GetByUserIdAsync(int userId)
        {
            var userGames =
        }

        public async Task<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserGameDto> UpdateAsync(int userId, UpdateUserGameDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
