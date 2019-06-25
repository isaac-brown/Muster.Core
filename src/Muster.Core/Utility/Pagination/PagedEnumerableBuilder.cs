// <copyright file="PagedEnumerableBuilder.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Utility.Pagination
{
  using System;
  using System.Collections.Generic;
  using System.Collections.Immutable;
  using System.ComponentModel;
  using Muster.Core.Utility.Pagination.Metadata;

  /// <summary>
  /// Class for Building a <see cref="PagedEnumerable{T}"/> object.
  /// </summary>
  /// <typeparam name="T">The type of Paged Enumerable that will be built.</typeparam>
  [ImmutableObject(immutable: true)]
  public class PagedEnumerableBuilder<T> : IBuilder<PagedEnumerable<T>>
  {
    private PagedEnumerableBuilder()
    {
    }

    private PagedEnumerableBuilder(PagedEnumerableMetadata metadata, IEnumerable<T> records)
    {
      this.Records = ImmutableList.CreateRange(records);
      this.Metadata = metadata;
    }

    /// <summary>
    /// Gets the records for this builder.
    /// </summary>
    /// <returns>The records for this builder.</returns>
    public IEnumerable<T> Records { get; } = ImmutableList.Create<T>();

    /// <summary>
    /// Gets the metadata for this builder.
    /// </summary>
    /// <value>The metadata for this builder.</value>
    public PagedEnumerableMetadata Metadata { get; } = PagedEnumerableMetadata.Default();

    /// <summary>
    /// Creates a new instance of <see cref="PagedEnumerableBuilder{T}"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="PagedEnumerableBuilder{T}"/>.</returns>
    public static PagedEnumerableBuilder<T> Create()
    {
      return new PagedEnumerableBuilder<T>();
    }

    /// <summary>
    /// Sets the records to be used by the builder.
    /// </summary>
    /// <param name="records">The <see cref="IEnumerable{T}"/> to use.</param>
    /// <returns>A new <see cref="PagedEnumerableBuilder{T}"/> with the given <paramref name="records"/>.</returns>
    public PagedEnumerableBuilder<T> WithRecords(IEnumerable<T> records)
    {
      if (records is null)
      {
        throw new ArgumentNullException(nameof(records));
      }

      return new PagedEnumerableBuilder<T>(this.Metadata, records);
    }

    /// <summary>
    /// Sets the metadata to be used by the builder.
    /// </summary>
    /// <param name="metadata">The <see cref="PagedEnumerableMetadata"/> to use.</param>
    /// <returns>A new <see cref="PagedEnumerableBuilder{T}"/> with the given <paramref name="metadata"/>.</returns>
    public PagedEnumerableBuilder<T> WithMetadata(PagedEnumerableMetadata metadata)
    {
      if (metadata is null)
      {
        throw new ArgumentNullException(nameof(metadata));
      }

      return new PagedEnumerableBuilder<T>(metadata, this.Records);
    }

    /// <summary>
    /// Builds an instance of <see cref="PagedEnumerable{TEntity}"/> based on the current builder.
    /// </summary>
    /// <returns>An instance of <see cref="PagedEnumerable{TEntity}"/> based on the current builder.</returns>
    public PagedEnumerable<T> Build()
    {
      return PagedEnumerable<T>.Create(this);
    }
  }
}
