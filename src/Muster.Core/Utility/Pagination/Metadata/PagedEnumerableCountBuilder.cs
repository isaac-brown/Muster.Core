// <copyright file="PagedEnumerableCountBuilder.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Utility.Pagination.Metadata
{
  using System;
  using System.ComponentModel;
  using Muster.Core.Utility;
  using Muster.Core.Utility.Pagination;

  /// <summary>
  /// Class for building <see cref="PagedEnumerableCount"/>.
  /// </summary>
  [ImmutableObject(immutable: true)]
  public class PagedEnumerableCountBuilder : IBuilder<PagedEnumerableCount>
  {
    private PagedEnumerableCountBuilder(int current, int total, int countSkipped)
    {
      this.Current = current;
      this.Total = total;
      this.CountSkipped = countSkipped;
    }

    /// <summary>
    /// Gets the number of records contained in the <see cref="PagedEnumerable{T}"/>.
    /// </summary>
    public int Current { get; }

    /// <summary>
    /// Gets the total possible number of records.
    /// </summary>
    public int Total { get; }

    /// <summary>
    /// Gets the number of records skipped.
    /// </summary>
    public int CountSkipped { get; }

    /// <summary>
    /// Creates a new instance of <see cref="PagedEnumerableCountBuilder"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="PagedEnumerableCountBuilder"/>.</returns>
    public static PagedEnumerableCountBuilder Create()
    {
      return new PagedEnumerableCountBuilder(current: 0, total: 0, countSkipped: 0);
    }

    /// <summary>
    /// Creates a new <see cref="PagedEnumerableCountBuilder"/> with <see cref="Current"/> set.
    /// </summary>
    /// <param name="current">The Current possible number of records.</param>
    /// <returns>A new <see cref="PagedEnumerableCountBuilder"/> with <see cref="Current"/> set.</returns>
    public PagedEnumerableCountBuilder WithCurrent(int current)
    {
      if (current < 0)
      {
        throw new ArgumentOutOfRangeException(
          $"Parameter {nameof(current)} cannot be negative. Actual value: {current}");
      }

      return new PagedEnumerableCountBuilder(
        current: current,
        total: this.Total,
        countSkipped: this.CountSkipped);
    }

    /// <summary>
    /// Creates a new <see cref="PagedEnumerableCountBuilder"/> with <see cref="Total"/> set.
    /// </summary>
    /// <param name="total">The total possible number of records.</param>
    /// <returns>A new <see cref="PagedEnumerableCountBuilder"/> with <see cref="Total"/> set.</returns>
    public PagedEnumerableCountBuilder WithTotal(int total)
    {
      if (total < 0)
      {
        throw new ArgumentOutOfRangeException(
          $"Parameter {nameof(total)} cannot be negative. Actual value: {total}");
      }

      return new PagedEnumerableCountBuilder(
        current: this.Current,
        total: total,
        countSkipped: this.CountSkipped);
    }

    /// <summary>
    /// Creates a new <see cref="PagedEnumerableCountBuilder"/> with <see cref="CountSkipped"/> set.
    /// </summary>
    /// <param name="countSkipped">The number of records skipped.</param>
    /// <returns>A new <see cref="PagedEnumerableCountBuilder"/> with <see cref="CountSkipped"/> set.</returns>
    public PagedEnumerableCountBuilder WithCountSkipped(int countSkipped)
    {
      if (countSkipped < 0)
      {
        throw new ArgumentOutOfRangeException(
          $"Parameter {nameof(countSkipped)} cannot be negative. Actual value: {countSkipped}");
      }

      return new PagedEnumerableCountBuilder(
        current: this.Current,
        total: this.Total,
        countSkipped: countSkipped);
    }

    /// <inheritdoc/>
    public PagedEnumerableCount Build()
    {
      return PagedEnumerableCount.Create(this);
    }
  }
}