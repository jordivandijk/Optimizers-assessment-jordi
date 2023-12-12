using OrderApi.Models.Security;

namespace OrderApi.Repositories.Interfaces
{
    /// <summary>
    ///     IRepository implementation for <see cref="User"/>  with added functionality
    /// </summary>
    public interface IUserRepository : IRepository<User>
    {
        /// <summary>
        ///     Gets <see cref="User"/> based on its username
        /// </summary>
        /// <param name="userName"></param>
        /// <returns><see cref="User"/></returns>
        Task<User> GetByUsernameAsync(string userName);

        /// <summary>
        ///     Checks if username exists
        /// </summary>
        /// <param name="userName"></param>
        /// <returns>Returns true if username exists</returns>
        Task<bool> UserNameExistsAsync(string userName);
    }
}
