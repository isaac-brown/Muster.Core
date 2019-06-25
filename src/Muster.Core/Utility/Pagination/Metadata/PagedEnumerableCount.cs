// <copyright file="PagedEnumerableCount.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Utility.Pagination.Metadata
{
  using System;

  /// <summary>
  /// Provides metadata for a <see cref="PagedEnumerable{TEntity}"/> regarding counts.
  /// </summary>
  public class PagedEnumerableCount
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableCount"/> class.
    /// </summary>
    /// <param name="builder">The builder to use for constructing this instance.</param>
    protected PagedEnumerableCount(PagedEnumerableCountBuilder builder)
    {
      if (builder is null)
      {
        throw new System.ArgumentNullException(nameof(builder));
      }

      this.Current = builder.Current;
      this.Total = builder.Total;
      this.Skipped = builder.CountSkipped;
    }

    /// <summary>
    /// Gets the number of records in the current page.
    /// </summary>
    public long Current { get; }

    /// <summary>
    /// Gets the number of records total across all pages.
    /// </summary>
    public long Total { get; }

    /// <summary>
    /// Gets the number of records that were skipped.
    /// </summary>
    public long Skipped { get; }

    /// <summary>
    /// Creates a new instance of <see cref="PagedEnumerableCount"/>.
    /// </summary>
    /// <param name="builder">The builder to use for constructing the instance.</param>
    /// <returns>A new instance of <see cref="PagedEnumerableCount"/>.</returns>
    public static PagedEnumerableCount Create(PagedEnumerableCountBuilder builder)
    {
      return new PagedEnumerableCount(builder);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableCount"/> class with default values.
    /// </summary>
    /// <remarks>
    /// Think of this like a default constructor, all properties will have default values and be well formed.
    /// </remarks>
    /// <returns>A new instance of the <see cref="PagedEnumerableCount"/> class with default values.</returns>
    public static PagedEnumerableCount Default()
    {
      return Create(PagedEnumerableCountBuilder.Create());
    }
  }
}