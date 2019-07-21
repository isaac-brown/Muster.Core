// <copyright file="PagedEnumerableMetadataFactory.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Fixture
{
  using Muster.Core.Utility.Pagination.Metadata;

  /// <summary>
  /// Class for creating <see cref="PagedEnumerableMetadata"/>.
  /// </summary>
  internal static class PagedEnumerableMetadataFactory
  {
    /// <summary>
    /// Creates a well formed <see cref="PagedEnumerableMetadata"/> object that can be used without throwing exceptions.
    /// </summary>
    /// <returns>A well formed <see cref="PagedEnumerableMetadata"/> object.</returns>
    internal static PagedEnumerableMetadata WellFormed()
    {
      var count = PagedEnumerableCountFactory.WellFormed();

      return PagedEnumerableMetadataBuilder.Create()
                                           .WithCount(count)
                                           .Build();
    }

    /// <summary>
    /// Returns null, but strongly typed as <see cref="PagedEnumerableMetadata"/>.
    /// </summary>
    /// <returns>null.</returns>
    internal static PagedEnumerableMetadata Null()
    {
      return null;
    }
  }
}