// <copyright file="IAsyncRepository.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Repositories
{
  using System.Threading.Tasks;
  using Muster.Core.Utility.Pagination;

  /// <summary>
  /// A generic repository interface which defines the most basic operations a repository should implement,
  /// same as <see cref="IRepository{TKey, TEntity}"/> but all methods are asynchronous.
  /// </summary>
  /// <typeparam name="TKey">The identifier for the given <typeparamref name="TEntity"/>.</typeparam>
  /// <typeparam name="TEntity">The type of object this repository will return.</typeparam>
  public interface IAsyncRepository<TKey, TEntity>
  {
    /// <summary>
    /// Asynchronously adds a single <typeparamref name="TEntity"/> to the repository.
    /// </summary>
    /// <param name="entity">The <typeparamref name="TEntity"/> to add.</param>
    /// <returns>The <typeparamref name="TEntity"/> that was added.</returns>
    Task<TEntity> AddAsync(TEntity entity);

    /// <summary>
    /// Asynchronously checks for the existence of a single <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="id">The identifier of the <typeparamref name="TEntity"/> to check the existence of.</param>
    /// <returns>true if there is a <typeparamref name="TEntity"/> with the given <paramref name="id"/>, false otherwise.</returns>
    Task<bool> ExistsAsync(TKey id);

    /// <summary>
    /// Asynchronously get a single <typeparamref name="TEntity"/> by it's id.
    /// </summary>
    /// <param name="id">The identifier of the <typeparamref name="TEntity"/> to find.</param>
    /// <returns>The entity with the given <paramref name="id"/>, or null if it doesn't exist.</returns>
    Task<TEntity> GetByIdAsync(TKey id);

    /// <summary>
    /// Asynchronously gets a paged collection of <typeparamref name="TEntity"/>s, skipping records
    /// up until the given <paramref name="offset"/> and then taking a given number of records.
    /// </summary>
    /// <param name="offset">The <typeparamref name="TKey"/> of the last record to skip.
    /// Default the is default of <typeparamref name="TKey"/> which will skip no records.</param>
    /// <param name="take">The number of records to take. Default is `100`.</param>
    /// <returns>A paged collection of <typeparamref name="TEntity"/>s.</returns>
    Task<PagedEnumerable<TEntity>> GetPagedAsync(TKey offset = default, int take = 100);

    /// <summary>
    /// Asynchronously updates a single <typeparamref name="TEntity"/> in the repository.
    /// </summary>
    /// <param name="entity">The <typeparamref name="TEntity"/> to update.</param>
    /// <returns>The <typeparamref name="TEntity"/> that was updated.</returns>
    Task<TEntity> UpdateAsync(TEntity entity);
  }
}