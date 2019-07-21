// <copyright file="PagedEnumerableMetadataBuilder.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Utility.Pagination.Metadata
{
  using System;
  using System.ComponentModel;

  /// <summary>
  /// Class to build <see cref="PagedEnumerableMetadata"/>.
  /// </summary>
  [ImmutableObject(immutable: true)]
  public class PagedEnumerableMetadataBuilder : IBuilder<PagedEnumerableMetadata>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableMetadataBuilder"/> class
    /// using the given <paramref name="count"/> and <paramref name="hasMore"/>.
    /// </summary>
    /// <param name="count">The count object to use.</param>
    /// <param name="hasMore">Indicates whether more records are available.</param>
    public PagedEnumerableMetadataBuilder(PagedEnumerableCount count, bool hasMore)
    {
      this.Count = count;
      this.HasMore = hasMore;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableMetadataBuilder"/> class.
    /// </summary>
    private PagedEnumerableMetadataBuilder()
      : this(count: PagedEnumerableCount.Default(), hasMore: false)
    {
    }

    /// <summary>
    /// Gets metadata related to counts of.
    /// </summary>
    public PagedEnumerableCount Count { get; }

    /// <summary>
    /// Gets a value indicating whether more records are available.
    /// </summary>
    public bool HasMore { get; }

    /// <summary>
    /// Creates a new <see cref="PagedEnumerableMetadataBuilder"/> object.
    /// </summary>
    /// <returns>A new <see cref="PagedEnumerableMetadataBuilder"/> object.</returns>
    public static PagedEnumerableMetadataBuilder Create()
    {
      return new PagedEnumerableMetadataBuilder();
    }

    /// <inheritdoc/>
    public PagedEnumerableMetadata Build()
    {
      return PagedEnumerableMetadata.Create(this);
    }

    /// <summary>
    /// Creates a new <see cref="PagedEnumerableMetadataBuilder"/> with <see cref="Count"/> set.
    /// </summary>
    /// <param name="count">The metadata related to counts of records.</param>
    /// <returns>A new <see cref="PagedEnumerableMetadataBuilder"/> with <see cref="Count"/> set.</returns>
    public PagedEnumerableMetadataBuilder WithCount(PagedEnumerableCount count)
    {
      if (count is null)
      {
        throw new ArgumentNullException(nameof(count));
      }

      return new PagedEnumerableMetadataBuilder(count, this.HasMore);
    }

    /// <summary>
    /// Creates a new <see cref="PagedEnumerableMetadataBuilder"/> with <see cref="HasMore"/> set.
    /// </summary>
    /// <param name="hasMore">Indicates whether more records are available.</param>
    /// <returns>A new <see cref="PagedEnumerableMetadataBuilder"/> with <see cref="HasMore"/> set.</returns>
    public PagedEnumerableMetadataBuilder WithHasMore(bool hasMore)
    {
      return new PagedEnumerableMetadataBuilder(this.Count, hasMore);
      throw new NotImplementedException();
    }
  }
}