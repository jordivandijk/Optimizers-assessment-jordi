using OrderApi.Models;

namespace OrderApi.Repositories.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        /// <summary>
        ///     Gets the entity based on its id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        /// <returns><typeparamref name="T"/></returns>
        Task<T> GetAsync(Guid id);

        /// <summary>
        ///     Gets a list of al the <typeparamref name="T"/>
        /// </summary>
        /// <returns>A <see cref="List{T}"/> of al records</returns>
        Task<List<T>> GetAllAsync();

        /// <summary>
        ///     Updates the <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity">The updated entity object</param>
        /// <returns>The updated <typeparamref name="T"/></returns>
        Task<T> UpdateAsync(T entity);

        /// <summary>
        ///     Deletes the <typeparamref name="T"/> based on its id
        /// </summary>
        /// <param name="id">Id of the entity</param>
        Task DeleteAsync(Guid id);

        /// <summary>
        ///     Creates a new <typeparamref name="T"/>
        /// </summary>
        /// <param name="entity">The newly created entity object</param>
        /// <returns>The created <typeparamref name="T"/></returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        ///     Checks if a <typeparamref name="T"/> exists based on id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Exists(Guid id);
    }
}
