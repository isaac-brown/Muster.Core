// <copyright file="DraftBlogPost.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Fixture
{
  using System;
  using Muster.Core.Entity;
  using Muster.Core.Entity.Builders;
  using NodaTime;

  /// <summary>
  /// Represents a <see cref="BlogPost"/> that is well formed and in <see cref="BlogPostStatus.Draft"/> status.
  /// </summary>
  internal class DraftBlogPost
  {
    /// <summary>
    /// Initialize a new <see cref="BlogPost"/> that is a draft.
    /// </summary>
    /// <returns>A draft <see cref="BlogPost"/>.</returns>
    internal static BlogPost Create()
    {
      string content = "# Something\nWords and things and such.";
      IClock clock = SystemClock.Instance;
      BlogPost blogPost = BlogPostBuilder.Create()
                                         .WithId($"{Guid.NewGuid()}")
                                         .WithContent(content)
                                         .WithCreated(clock.GetCurrentInstant())
                                         .Build();

      return blogPost;
    }
  }
}
