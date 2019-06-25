// <copyright file="PagedEnumerableNavigation.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Utility.Pagination.Metadata
{
  using System;
  using System.ComponentModel;

  /// <summary>
  /// Holds metadata used to navigate between pages/about the current page.
  /// </summary>
  [ImmutableObject(immutable: true)]
  public class PagedEnumerableNavigation
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableNavigation"/> class using the
    /// given builder.
    /// </summary>
    /// <param name="builder">The builder to use.</param>
    private PagedEnumerableNavigation(PagedEnumerableNavigationBuilder builder)
    {
      if (builder is null)
      {
        throw new ArgumentNullException(nameof(builder));
      }

      if (builder.FirstPageNumber > builder.LastPageNumber)
      {
        throw new ArgumentOutOfRangeException(
          paramName: $"{nameof(builder.FirstPageNumber)}",
          message: $"Parameter: {nameof(builder.FirstPageNumber)} must be less than parameter: ${nameof(builder.LastPageNumber)}");
      }

      if (builder.FirstPageNumber > builder.CurrentPageNumber)
      {
        throw new ArgumentOutOfRangeException(
          paramName: $"{nameof(builder.FirstPageNumber)}",
          message: $"Parameter: {nameof(builder.FirstPageNumber)} must be less than parameter: ${nameof(builder.CurrentPageNumber)}");
      }

      if (builder.CurrentPageNumber > builder.LastPageNumber)
      {
        throw new ArgumentOutOfRangeException(
          paramName: $"{nameof(builder.CurrentPageNumber)}",
          message: $"Parameter: {nameof(builder.CurrentPageNumber)} must be less than parameter: ${nameof(builder.LastPageNumber)}");
      }

      this.FirstPageNumber = builder.FirstPageNumber;
      this.CurrentPageNumber = builder.CurrentPageNumber;
      this.LastPageNumber = builder.LastPageNumber;
    }

    /// <summary>
    /// Gets the number of the first page.
    /// </summary>
    public long FirstPageNumber { get; }

    /// <summary>
    /// Gets the number of the current page.
    /// </summary>
    public long CurrentPageNumber { get; }

    /// <summary>
    /// Gets the number of the last page.
    /// </summary>
    public long LastPageNumber { get; }

    /// <summary>
    /// Gets the page number of the next page, or null if this is the last page.
    /// </summary>
    public long? NextPageNumber => this.IsLastPage ? default(long?) : this.CurrentPageNumber + 1;

    /// <summary>
    /// Gets the page number of the previous page, or null if this is the first page.
    /// </summary>
    public long? PreviousPageNumber => this.IsFirstPage ? default(long?) : this.CurrentPageNumber - 1;

    /// <summary>
    /// Gets a value indicating whether this is the first page.
    /// </summary>
    public bool IsFirstPage => this.CurrentPageNumber == this.FirstPageNumber;

    /// <summary>
    /// Gets a value indicating whether this is the last page.
    /// </summary>
    public bool IsLastPage => this.CurrentPageNumber == this.LastPageNumber;

    /// <summary>
    /// Gets a value indicating whether there is a page after this one.
    /// </summary>
    public bool HasNextPage => !this.IsLastPage;

    /// <summary>
    /// Gets a value indicating whether there is a page before this one.
    /// </summary>
    public bool HasPreviousPage => !this.IsFirstPage;

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableNavigation"/> class using the
    /// given first, last and current page numbers.
    /// </summary>
    /// <param name="builder">The builder to use.</param>
    /// <returns>A new instance of <see cref="PagedEnumerableNavigation"/>.</returns>
    public static PagedEnumerableNavigation Create(PagedEnumerableNavigationBuilder builder)
    {
      return new PagedEnumerableNavigation(builder);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableNavigation"/> class with default values.
    /// </summary>
    /// <remarks>
    /// Think of this like a default constructor, all properties will have default values and be well formed.
    /// </remarks>
    /// <returns>A new instance of the <see cref="PagedEnumerableNavigation"/> class with default values.</returns>
    public static PagedEnumerableNavigation Default()
    {
      // TODO: Unit tests for this.
      return Create(PagedEnumerableNavigationBuilder.Create());
    }
  }
}
