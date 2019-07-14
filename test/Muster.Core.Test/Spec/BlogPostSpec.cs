// <copyright file="BlogPostSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core;
  using Muster.Core.Entity;
  using Muster.Core.Entity.Builders;
  using Muster.Core.Exception;
  using Muster.Core.Test.Fixture;
  using NodaTime;
  using PrettyTest;

  /// <summary>
  /// Unit Tests for the <see cref="BlogPost"/> object.
  /// </summary>
  public class BlogPostSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_builder_is_null_When_Create_is_called_Then_a_ArgumentNullException_should_be_thrown()
    {
      // Given.
      BlogPost blogPost;
      BlogPostBuilder builder = null;

      // When.
      Action action = () => blogPost = BlogPost.Create(builder);

      // Then.
      action.Should().Throw<ArgumentNullException>()
            .WithMessage("*cannot be null*builder*");
    }

    [PrettyFact]
    public void Given_a_BlogPost_that_has_a_status_of_Draft_When_it_is_published_Then_the_status_should_be_Published()
    {
      // Given.
      BlogPost blogPost = DraftBlogPost.Create();

      // When.
      blogPost.Publish();

      // Then.
      blogPost.Status.Should().Be(BlogPostStatus.Published);
    }

    [PrettyFact]
    public void Given_a_BlogPost_that_has_a_status_of_Published_When_it_is_published_Then_an_BlogPostAlreadyPublishedException_should_be_Thrown()
    {
      // Given.
      BlogPost blogPost = PublishedBlogPost.Create();

      // When.
      Action action = () => blogPost.Publish();

      // Then.
      action.Should().Throw<BlogPostAlreadyPublishedException>("Because blog posts cannot be published more than once");
    }
  }
}
