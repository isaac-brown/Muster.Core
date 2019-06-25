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
    /// using the given <paramref name="navigation"/>.
    /// </summary>
    /// <param name="navigation">The navigation object to use.</param>
    /// <param name="count">The count object to use.</param>
    private PagedEnumerableMetadataBuilder(
      PagedEnumerableCount count,
      PagedEnumerableNavigation navigation)
    {
      this.Count = count;
      this.Navigation = navigation;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableMetadataBuilder"/> class.
    /// </summary>
    private PagedEnumerableMetadataBuilder()
      : this(PagedEnumerableCount.Default(), PagedEnumerableNavigation.Default())
    {
    }

    /// <summary>
    /// Gets metadata related to counts of pages.
    /// </summary>
    public PagedEnumerableCount Count { get; }

    /// <summary>
    /// Gets metadata relating to navigation between pages.
    /// </summary>
    public PagedEnumerableNavigation Navigation { get; }

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
    /// <param name="count">The metadata related to counts of pages.</param>
    /// <returns>A new <see cref="PagedEnumerableMetadataBuilder"/> with <see cref="Count"/> set.</returns>
    public PagedEnumerableMetadataBuilder WithCount(PagedEnumerableCount count)
    {
      if (count is null)
      {
        throw new ArgumentNullException(nameof(count));
      }

      return new PagedEnumerableMetadataBuilder(count, this.Navigation);
    }

    /// <summary>
    /// Creates a new <see cref="PagedEnumerableMetadataBuilder"/> with <see cref="Navigation"/> set.
    /// </summary>
    /// <param name="navigation">The metadata relating to navigation between pages.</param>
    /// <returns>A new <see cref="PagedEnumerableMetadataBuilder"/> with <see cref="Navigation"/> set.</returns>
    public PagedEnumerableMetadataBuilder WithNavigation(PagedEnumerableNavigation navigation)
    {
      if (navigation is null)
      {
        throw new ArgumentNullException(nameof(navigation));
      }

      return new PagedEnumerableMetadataBuilder(this.Count, navigation);
    }
  }
}