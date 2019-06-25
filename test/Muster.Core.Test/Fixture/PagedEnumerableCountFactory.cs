// <copyright file="PagedEnumerableCountFactory.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Fixture
{
  using Muster.Core.Utility.Pagination.Metadata;

  /// <summary>
  /// Class for creating <see cref="PagedEnumerableCount"/>
  /// </summary>
  internal static class PagedEnumerableCountFactory
  {
    /// <summary>
    /// Creates a well formed <see cref="PagedEnumerableCount"/> object that can be used without throwing exceptions.
    /// </summary>
    /// <returns>A well formed <see cref="PagedEnumerableCount"/> object.</returns>
    internal static PagedEnumerableCount WellFormed()
    {
      PagedEnumerableCount count;
      count = PagedEnumerableCountBuilder.Create()
                                         .WithCountSkipped(1)
                                         .WithCurrent(1)
                                         .WithTotal(2)
                                         .Build();

      return count;
    }
  }
}