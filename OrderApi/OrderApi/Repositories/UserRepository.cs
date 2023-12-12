using Microsoft.EntityFrameworkCore;
using OrderApi.Data;
using OrderApi.Models.Security;
using OrderApi.Repositories.Interfaces;

namespace OrderApi.Repositories
{
    /// <summary>
    ///     MS SQL implementation of <see cref="IUserRepository"/>
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private readonly OptimizersDbContext _context;

        public UserRepository(OptimizersDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User entity)
        {
            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            User user = await GetAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exists(Guid id)
        {
            return await _context.Users.AnyAsync(u => u.Id == id);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetAsync(Guid id)
        {
            return await _context.Users.SingleAsync(u => u.Id == id);
        }

        public async Task<User> GetByUsernameAsync(string userName)
        {
            return await _context.Users.SingleAsync(u => u.Username == userName);
        }

        public async Task<User> UpdateAsync(User entity)
        {
            _context.Users.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> UserNameExistsAsync(string userName)
        {
            return await _context.Users.AnyAsync(u => u.Username == userName);
        }
    }
}
