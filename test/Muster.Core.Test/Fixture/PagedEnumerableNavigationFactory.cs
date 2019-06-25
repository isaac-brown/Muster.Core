// <copyright file="PagedEnumerableNavigationFactory.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Fixture
{
  using Muster.Core.Utility.Pagination.Metadata;

  /// <summary>
  /// Class for creating <see cref="PagedEnumerableNavigation"/>
  /// </summary>
  internal static class PagedEnumerableNavigationFactory
  {
    /// <summary>
    /// Creates a well formed <see cref="PagedEnumerableNavigation"/> object that can be used without throwing exceptions.
    /// </summary>
    /// <returns>A well formed <see cref="PagedEnumerableNavigation"/> object.</returns>
    internal static PagedEnumerableNavigation WellFormed()
    {
      PagedEnumerableNavigation navigation;

      navigation = PagedEnumerableNavigationBuilder.Create()
                                                   .WithFirstPageNumber(0)
                                                   .WithCurrentPageNumber(1)
                                                   .WithLastPageNumber(1)
                                                   .Build();
      return navigation;
    }
  }
}