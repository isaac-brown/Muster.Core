// <copyright file="BlogPostBuilder.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Entity.Builders
{
  using System;
  using System.Collections.Immutable;
  using System.ComponentModel;
  using Muster.Core.Utility;
  using NodaTime;

  /// <summary>
  /// Class for building <see cref="BlogPost"/> instances.
  /// </summary>
  [ImmutableObject(immutable: true)]
  public class BlogPostBuilder : IBuilder<BlogPost>
  {
    private BlogPostBuilder()
    {
    }

    private BlogPostBuilder(string id, string content, Instant created, BlogPostStatus status, IImmutableSet<Tag> tags)
    {
      this.Id = id;
      this.Content = content;
      this.Created = created;
      this.Status = status;
      this.Tags = tags;
    }

    /// <summary>
    /// Gets the unique identifier for this <see cref="BlogPostBuilder"/>.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the text content of the <see cref="BlogPostBuilder"/>.
    /// </summary>
    /// <remarks>
    /// Default is <see cref="string.Empty"/>.
    /// </remarks>
    public string Content { get; } = string.Empty;

    /// <summary>
    /// Gets the instant that the <see cref="BlogPostBuilder"/> was created.
    /// </summary>
    /// <remarks>
    /// Default is <see cref="IClock.GetCurrentInstant"/>.
    /// </remarks>
    public Instant Created { get; }

    /// <summary>
    /// Gets the <see cref="BlogPostStatus"/> for the <see cref="BlogPostBuilder"/>.
    /// </summary>
    /// <remarks>
    /// Default is <see cref="BlogPostStatus.Draft"/>.
    /// </remarks>
    public BlogPostStatus Status { get; } = BlogPostStatus.Draft;

    /// <summary>
    /// Gets the list of <see cref="Tag"/>s associated with the <see cref="BlogPostBuilder"/>.
    /// </summary>
    /// <remarks>
    /// Default is <see cref="ImmutableHashSet{Tag}.Empty"/>.
    /// </remarks>
    public IImmutableSet<Tag> Tags { get; } = ImmutableHashSet<Tag>.Empty;

    /// <summary>
    /// Creates a new instance of <see cref="BlogPostBuilder"/>.
    /// </summary>
    /// <returns>A new instance of <see cref="BlogPostBuilder"/>.</returns>
    public static BlogPostBuilder Create()
    {
      return new BlogPostBuilder();
    }

    /// <summary>
    /// Sets the <see cref="Id"/> of the builder.
    /// </summary>
    /// <param name="id">The identifier to set as the id.</param>
    /// <returns>A new builder instance with the id set.</returns>
    public BlogPostBuilder WithId(string id)
    {
      return new BlogPostBuilder(id, this.Content, this.Created, this.Status, this.Tags);
    }

    /// <summary>
    /// Sets the <see cref="Content"/> of the builder.
    /// </summary>
    /// <param name="content">The <see cref="string"/> to set as the content.</param>
    /// <returns>A new builder instance with the content set.</returns>
    public BlogPostBuilder WithContent(string content)
    {
      if (content is null)
      {
        throw new ArgumentNullException(nameof(content));
      }

      return new BlogPostBuilder(this.Id, content, this.Created, this.Status, this.Tags);
    }

    /// <summary>
    /// Sets the <see cref="Created"/> of the builder.
    /// </summary>
    /// <param name="created">The <see cref="string"/> to set as the created.</param>
    /// <returns>A new builder instance with the created set.</returns>
    public BlogPostBuilder WithCreated(Instant created)
    {
      return new BlogPostBuilder(this.Id, this.Content, created, this.Status, this.Tags);
    }

    /// <summary>
    /// Sets the <see cref="Status"/> of the builder.
    /// </summary>
    /// <param name="status">The <see cref="string"/> to set as the status.</param>
    /// <returns>A new builder instance with the status set.</returns>
    public BlogPostBuilder WithStatus(BlogPostStatus status)
    {
      if (status is null)
      {
        throw new ArgumentNullException(nameof(status));
      }

      return new BlogPostBuilder(this.Id, this.Content, this.Created, status, this.Tags);
    }

    /// <summary>
    /// Sets the <see cref="Tags"/> of the builder.
    /// </summary>
    /// <param name="tags">The <see cref="string"/> to set as the tags.</param>
    /// <returns>A new builder instance with the tags set.</returns>
    public BlogPostBuilder WithTags(IImmutableSet<Tag> tags)
    {
      if (tags is null)
      {
        throw new ArgumentNullException(nameof(tags));
      }

      return new BlogPostBuilder(this.Id, this.Content, this.Created, this.Status, tags);
    }

    /// <summary>
    /// Builds a new instance of <see cref="BlogPost"/> based on this builder.
    /// </summary>
    /// <returns>A new instance of <see cref="BlogPost"/>.</returns>
    public BlogPost Build()
    {
      return BlogPost.Create(this);
    }
  }
}