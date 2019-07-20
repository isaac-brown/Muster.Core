// <copyright file="BlogPost.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Entity
{
  using System;
  using System.Collections.Immutable;
  using Muster.Core.Entity.Builders;
  using Muster.Core.Exception;
  using NodaTime;

  /// <summary>
  /// Represents a single blog post.
  /// </summary>
  public class BlogPost
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPost"/> class
    /// using the given <see cref="BlogPostBuilder"/>.
    /// </summary>
    /// <param name="builder">The builder to use.</param>
    public BlogPost(BlogPostBuilder builder)
    {
      this.Id = builder.Id;
      this.Content = builder.Content;
      this.Created = builder.Created;
      this.Status = builder.Status;
      this.Tags = builder.Tags;
    }

    /// <summary>
    /// Gets the unique identifier for this <see cref="BlogPost"/>.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the text content of the <see cref="BlogPost"/>.
    /// </summary>
    public string Content { get; private set; }

    /// <summary>
    /// Gets the instant that the <see cref="BlogPost"/> was created.
    /// </summary>
    public Instant Created { get; }

    /// <summary>
    /// Gets the <see cref="BlogPostStatus"/> for the <see cref="BlogPost"/>.
    /// </summary>
    public BlogPostStatus Status { get; private set; }

    /// <summary>
    /// Gets the list of <see cref="Tag"/>s associated with the <see cref="BlogPost"/>.
    /// </summary>
    public IImmutableSet<Tag> Tags { get; } = ImmutableHashSet.Create<Tag>();

    /// <summary>
    /// Initializes a new instance of the <see cref="BlogPost"/> class.
    /// </summary>
    /// <param name="builder">The builder to create the post from.</param>
    /// <returns>A new instance of the <see cref="BlogPost"/> class.</returns>
    public static BlogPost Create(BlogPostBuilder builder)
    {
      if (builder is null)
      {
        throw new ArgumentNullException(nameof(builder));
      }

      return new BlogPost(builder);
    }

    /// <summary>
    /// Publishes the <see cref="BlogPost"/>, marking it as being visible to viewers.
    /// </summary>
    public void Publish()
    {
      if (this.Status == BlogPostStatus.Published)
      {
        throw new BlogPostAlreadyPublishedException();
      }

      this.Status = BlogPostStatus.Published;
    }
  }
}