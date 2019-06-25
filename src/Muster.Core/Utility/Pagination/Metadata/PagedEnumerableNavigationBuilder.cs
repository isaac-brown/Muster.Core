// <copyright file="PagedEnumerableNavigationBuilder.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Utility.Pagination.Metadata
{
  using System;
  using System.ComponentModel;

  /// <summary>
  /// Class for Building a <see cref="PagedEnumerableNavigation"/> object.
  /// </summary>
  [ImmutableObject(immutable: true)]
  public class PagedEnumerableNavigationBuilder : IBuilder<PagedEnumerableNavigation>
  {
    private PagedEnumerableNavigationBuilder(long firstPageNumber, long currentPageNumber, long lastPageNumber)
    {
      this.FirstPageNumber = firstPageNumber;
      this.CurrentPageNumber = currentPageNumber;
      this.LastPageNumber = lastPageNumber;
    }

    private PagedEnumerableNavigationBuilder()
    : this(firstPageNumber: 0, currentPageNumber: 0, lastPageNumber: 0)
    {
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
    /// Initializes a new instance of the <see cref="PagedEnumerableNavigationBuilder"/> class.
    /// </summary>
    /// <returns>A new instance of the <see cref="PagedEnumerableNavigationBuilder"/> class.</returns>
    public static PagedEnumerableNavigationBuilder Create()
    {
      return new PagedEnumerableNavigationBuilder();
    }

    /// <summary>
    /// Creates a new instance of <see cref="PagedEnumerableNavigationBuilder"/>
    /// with the given firstPageNumber.
    /// </summary>
    /// <param name="firstPageNumber">The number of the first page.</param>
    /// <returns>A new instance of <see cref="PagedEnumerableNavigationBuilder"/>.</returns>
    public PagedEnumerableNavigationBuilder WithFirstPageNumber(int firstPageNumber)
    {
      if (firstPageNumber < 0)
      {
        throw new ArgumentOutOfRangeException(
          $"Parameter {nameof(firstPageNumber)} cannot be negative. Actual value: {firstPageNumber}");
      }

      return new PagedEnumerableNavigationBuilder(
        firstPageNumber,
        this.CurrentPageNumber,
        this.LastPageNumber);
    }

    /// <summary>
    /// Creates a new instance of <see cref="PagedEnumerableNavigationBuilder"/>
    /// with the given currentPageNumber.
    /// </summary>
    /// <param name="currentPageNumber">The number of the current page.</param>
    /// <returns>A new instance of <see cref="PagedEnumerableNavigationBuilder"/>.</returns>
    public PagedEnumerableNavigationBuilder WithCurrentPageNumber(int currentPageNumber)
    {
      if (currentPageNumber < 0)
      {
        throw new ArgumentOutOfRangeException(
          $"Parameter {nameof(currentPageNumber)} cannot be negative. Actual value: {currentPageNumber}");
      }

      return new PagedEnumerableNavigationBuilder(
        this.FirstPageNumber,
        currentPageNumber,
        this.LastPageNumber);
    }

    /// <summary>
    /// Creates a new instance of <see cref="PagedEnumerableNavigationBuilder"/>
    /// with the given lastPageNumber.
    /// </summary>
    /// <param name="lastPageNumber">The number of the last page.</param>
    /// <returns>A new instance of <see cref="PagedEnumerableNavigationBuilder"/>.</returns>
    public PagedEnumerableNavigationBuilder WithLastPageNumber(int lastPageNumber)
    {
      if (lastPageNumber < 0)
      {
        throw new ArgumentOutOfRangeException(
          $"Parameter {nameof(lastPageNumber)} cannot be negative. Actual value: {lastPageNumber}");
      }

      return new PagedEnumerableNavigationBuilder(
        this.FirstPageNumber,
        this.CurrentPageNumber,
        lastPageNumber);
    }

    /// <inheritdoc/>
    public PagedEnumerableNavigation Build()
    {
      return PagedEnumerableNavigation.Create(this);
    }
  }
}
