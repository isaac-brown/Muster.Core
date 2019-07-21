// <copyright file="PagedEnumerableMetadata.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Utility.Pagination.Metadata
{
  /// <summary>
  /// Holds metadata for an <see cref="PagedEnumerable{TEntity}"/>.
  /// </summary>
  public class PagedEnumerableMetadata
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableMetadata"/> class
    /// using the given builder.
    /// </summary>
    /// <param name="builder">The builder to use.</param>
    private PagedEnumerableMetadata(PagedEnumerableMetadataBuilder builder)
    {
      if (builder is null)
      {
        throw new System.ArgumentNullException(nameof(builder));
      }

      this.Count = builder.Count ?? PagedEnumerableCount.Default();
      this.HasMore = builder.HasMore;
    }

    /// <summary>
    /// Gets metadata related to counts of pages.
    /// </summary>
    public PagedEnumerableCount Count { get; }

    /// <summary>
    /// Gets a value indicating whether more records are available.
    /// </summary>
    public bool HasMore { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableMetadata"/> class
    /// using the given builder.
    /// </summary>
    /// <param name="builder">The <see cref="PagedEnumerableMetadataBuilder"/> to use.</param>
    /// <returns>A new instance of the <see cref="PagedEnumerableMetadata"/> class.</returns>
    public static PagedEnumerableMetadata Create(PagedEnumerableMetadataBuilder builder)
    {
      return new PagedEnumerableMetadata(builder);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="PagedEnumerableMetadata"/> class with default values.
    /// </summary>
    /// <remarks>
    /// Think of this like a default constructor, all properties will have default values and be well formed.
    /// </remarks>
    /// <returns>A new instance of the <see cref="PagedEnumerableMetadata"/> class with default values.</returns>
    public static PagedEnumerableMetadata Default()
    {
      var metadata = PagedEnumerableMetadataBuilder.Create().Build();
      return metadata;
    }
  }
}