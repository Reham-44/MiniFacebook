using MiniFacebook.Models;

namespace MiniFacebook.Repositories
{
    public interface IUserRepo
    {
        Task<List<User>> GetAllAsync();
        Task<bool> IsUserExistsByEmail(string email);
        Task<User?> GetByEmailAsync(string email);
        Task<User> AddAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(int id);
        Task<User?> GetByIdAsync(int id);

    }
}
