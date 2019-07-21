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
    private PagedEnumerableCountBuilder(int countCurrent, int countTotal, int countTaken)
    {
      this.Current = countCurrent;
      this.Total = countTotal;
      this.Taken = countTaken;
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
    /// Gets the number of records that were requested, this is the upper limit of <see cref="Current"/>.
    /// </summary>
    public int Taken { get; }

    /// <summary>
    /// Creates a new instance of <see cref="PagedEnumerableCountBuilder"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="PagedEnumerableCountBuilder"/>.</returns>
    public static PagedEnumerableCountBuilder Create()
    {
      return new PagedEnumerableCountBuilder(countCurrent: 0, countTotal: 0, countTaken: 0);
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
          nameof(current),
          current,
          $"Argument cannot be negative.");
      }

      return new PagedEnumerableCountBuilder(
        countCurrent: current,
        countTotal: this.Total,
        countTaken: this.Taken);
    }

    /// <summary>
    /// Creates a new <see cref="PagedEnumerableCountBuilder"/> with <see cref="Taken"/> set.
    /// </summary>
    /// <param name="taken">The number of records that were requested, this is the upper limit of <see cref="Current"/>.</param>
    /// <returns>A new <see cref="PagedEnumerableCountBuilder"/> with <see cref="Taken"/> set.</returns>
    public PagedEnumerableCountBuilder WithTaken(int taken)
    {
      if (taken < 0)
      {
        throw new ArgumentOutOfRangeException(nameof(taken), taken, "Argument cannot be negative");
      }

      return new PagedEnumerableCountBuilder(
        countCurrent: this.Current,
        countTotal: this.Total,
        countTaken: taken);
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
          nameof(total),
          total,
          $"Argument cannot be negative.");
      }

      return new PagedEnumerableCountBuilder(
        countCurrent: this.Current,
        countTotal: total,
        countTaken: this.Taken);
    }

    /// <inheritdoc/>
    public PagedEnumerableCount Build()
    {
      return PagedEnumerableCount.Create(this);
    }
  }
}