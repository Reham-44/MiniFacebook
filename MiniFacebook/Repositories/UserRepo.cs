using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniFacebook.Data;
using MiniFacebook.DTOs;
using MiniFacebook.Models;

namespace MiniFacebook.Repositories
{
    public class UserRepo:IUserRepo
    {
        readonly AppDbContext dbContext;
        public UserRepo(AppDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }
        public async Task<User?> GetByIdAsync(int id)
        {
            return await dbContext.Users.FindAsync(id);
        }
        public async Task<User?> GetByEmailAsync(string email)
        {
            return await dbContext.Users.FirstOrDefaultAsync(u=>u.Email==email);
        }
        public async Task<User> AddAsync(User user)
        {
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateAsync(User user)
        {
            dbContext.Users.Update(user);
            await dbContext.SaveChangesAsync();

            return user;
        }
        
        public async Task<bool> DeleteAsync(int id)
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user == null)
                return false;

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();

            return true;
        }

 
    public async Task<bool> IsUserExistsByEmail(string email)
        {
            return await dbContext.Users.AnyAsync(u => u.Email == email);
        }
     
    }
}
