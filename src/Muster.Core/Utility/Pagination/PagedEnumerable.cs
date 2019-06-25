// <copyright file="PagedEnumerable.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Utility.Pagination
{
  using System.Collections.Generic;
  using System.ComponentModel;
  using Muster.Core.Utility.Pagination.Metadata;

  /// <summary>
  /// A generic object for storing a collection of objects along with some pagination metadata about the page.
  /// </summary>
  /// <typeparam name="TEntity">The type of object that will be stored in this enumerable.</typeparam>
  [ImmutableObject(immutable: true)]
  public class PagedEnumerable<TEntity>
  {
    private PagedEnumerable(PagedEnumerableBuilder<TEntity> builder)
    {
      if (builder is null)
      {
        throw new System.ArgumentNullException(nameof(builder));
      }

      this.Metadata = builder.Metadata;
      this.Records = builder.Records;
    }

    /// <summary>
    /// Gets the <see cref="PagedEnumerableMetadata"/> for this page.
    /// </summary>
    public PagedEnumerableMetadata Metadata { get; }

    /// <summary>
    /// Gets the <typeparamref name="TEntity"/>s that are contained in this page.
    /// </summary>
    public IEnumerable<TEntity> Records { get; }

    /// <summary>
    /// Initializes a new instance of <see cref="PagedEnumerable{TEntity}"/> from the given builder.
    /// </summary>
    /// <param name="builder">The builder to create the instance from.</param>
    /// <returns>A new instance of <see cref="PagedEnumerable{TEntity}"/>.</returns>
    public static PagedEnumerable<TEntity> Create(PagedEnumerableBuilder<TEntity> builder)
    {
      return new PagedEnumerable<TEntity>(builder);
    }
  }
}