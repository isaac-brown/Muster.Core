// <copyright file="IRepository.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Repositories
{
  using Muster.Core.Utility.Pagination;

  /// <summary>
  /// A generic repository interface which defines the most basic operations a repository should implement.
  /// </summary>
  /// <typeparam name="TKey">The identifier for the given <typeparamref name="TEntity"/></typeparam>
  /// <typeparam name="TEntity">The type of object this repository will return.</typeparam>
  public interface IRepository<TKey, TEntity>
  {
    /// <summary>
    /// Adds an <typeparamref name="TEntity"/> to the repository.
    /// </summary>
    /// <param name="entity">The <typeparamref name="TEntity"/> to add.</param>
    /// <returns>The <typeparamref name="TEntity"/> that was added.</returns>
    TEntity Add(TEntity entity);

    /// <summary>
    /// Checks for the existence of a <typeparamref name="TEntity"/>.
    /// </summary>
    /// <param name="id">The identifier of the <typeparamref name="TEntity"/> to check the existence of.</param>
    /// <returns>true if there is a <typeparamref name="TEntity"/> with the given <paramref name="id"/>, false otherwise.</returns>
    bool Exists(TKey id);

    /// <summary>
    /// Get a <typeparamref name="TEntity"/> by it's id.
    /// </summary>
    /// <param name="id">The identifier of the <typeparamref name="TEntity"/> to find.</param>
    /// <returns>The entity with the given <paramref name="id"/>, or null if it doesn't exist.</returns>
    TEntity GetById(TKey id);

    /// <summary>
    /// Gets a paged collection of <typeparamref name="TEntity"/>s, skipping and then taking a given number of records.
    /// </summary>
    /// <param name="take">The number of records to take. Default is `100`</param>
    /// <param name="skip">The number of records to skip. Default is `0`</param>
    /// <returns>A paged collection of <typeparamref name="TEntity"/>s</returns>
    PagedEnumerable<TEntity> GetPaged(long take = 100, long skip = 0);

    /// <summary>
    /// Updates an <typeparamref name="TEntity"/> in the repository.
    /// </summary>
    /// <param name="entity">The <typeparamref name="TEntity"/> to update.</param>
    /// <returns>The <typeparamref name="TEntity"/> that was updated.</returns>
    TEntity Update(TEntity entity);
  }
}