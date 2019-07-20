// <copyright file="BlogPostBuilderSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using System.Collections.Immutable;
  using FluentAssertions;
  using Muster.Core.Entity;
  using Muster.Core.Entity.Builders;
  using Muster.Core.Test.Fixture;
  using NodaTime;
  using PrettyTest;

  /// <summary>
  /// Unit tests for the <see cref="BlogPostBuilder"/> class.
  /// </summary>
  public class BlogPostBuilderSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_a_valid_IClock_When_Create_is_called_Then_builder_should_have_defaults_set()
    {
      // Arrange.
      BlogPostBuilder builder;
      IClock clock = ConstantClockStub.Create(0);

      // Act.
      builder = BlogPostBuilder.Create();

      // Assert.
      builder.Id.Should().Be(null);
      builder.Content.Should().Be(string.Empty);
      builder.Created.Should().Be(clock.GetCurrentInstant());
      builder.Status.Should().BeEquivalentTo(BlogPostStatus.Draft);
      builder.Tags.Should().BeEmpty();
    }

    [PrettyFact]
    public void Given_a_valid_guid_When_WithId_is_called_Then_Id_should_be_set()
    {
      // Arrange.
      BlogPostBuilder builder = BlogPostBuilder.Create();
      string id = $"{Guid.NewGuid()}";

      // Act.
      builder = builder.WithId(id);

      // Assert.
      builder.Id.Should().Be(id);
    }

    [PrettyFact]
    public void Given_a_valid_Instant_When_WithCreated_is_called_Then_Created_Should_be_set()
    {
      // Arrange.
      BlogPostBuilder builder = BlogPostBuilder.Create();
      Instant created = Instant.FromUnixTimeMilliseconds(100000);

      // Act.
      builder = builder.WithCreated(created);

      // Assert.
      builder.Created.Should().Be(created);
    }

    [PrettyFact]
    public void Given_stauts_is_null_When_WithStatus_is_called_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Arrange.
      BlogPostBuilder builder = BlogPostBuilder.Create();
      BlogPostStatus status = null;

      // Act.
      Action testCode = () => builder.WithStatus(status);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*status*");
    }

    [PrettyFact]
    public void Given_status_is_not_null_When_WithStatus_is_called_Then_Status_should_be_set()
    {
      // Arrange.
      BlogPostBuilder builder = BlogPostBuilder.Create();
      BlogPostStatus status = BlogPostStatus.Published;

      // Act.
      builder = builder.WithStatus(status);

      // Assert.
      builder.Status.Should().Be(status);
    }

    [PrettyFact]
    public void Given_content_is_null_When_WithContent_is_called_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Arrange.
      BlogPostBuilder builder = BlogPostBuilder.Create();
      string content = null;

      // Act.
      Action testCode = () => builder.WithContent(content);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*content*");
    }

    [PrettyFact]
    public void Given_content_is_not_null_When_WithContent_is_called_Then_Content_should_be_set()
    {
      // Arrange.
      BlogPostBuilder builder = BlogPostBuilder.Create();
      string content = "Content";

      // Act.
      builder = builder.WithContent(content);

      // Assert.
      builder.Content.Should().Be(content);
    }

    [PrettyFact]
    public void Given_tags_is_null_When_WithTags_is_called_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Arrange.
      BlogPostBuilder builder = BlogPostBuilder.Create();
      IImmutableSet<Tag> tags = null;

      // Act.
      Action testCode = () => builder.WithTags(tags);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*tags*");
    }

    [PrettyFact]
    public void Given_tags_is_not_null_When_WithTags_is_called_Then_Tags_should_be_set()
    {
      // Arrange.
      BlogPostBuilder builder = BlogPostBuilder.Create();
      IImmutableSet<Tag> tags = ImmutableHashSet.Create(Tag.Create("name"));

      // Act.
      builder = builder.WithTags(tags);

      // Assert.
      builder.Tags.Should().BeEquivalentTo(tags);
    }

    [PrettyFact]
    public void Given_two_sets_of_tags_When_WithTags_is_called_Then_Tags_should_be_last_set_of_tags()
    {
      // Arrange.
      BlogPostBuilder builder = BlogPostBuilder.Create();
      IImmutableSet<Tag> tags = ImmutableHashSet.Create(Tag.Create("name"), Tag.Create("pizza"));
      IImmutableSet<Tag> otherTags = ImmutableHashSet.Create(Tag.Create("name"), Tag.Create("age"));

      // Act.
      builder = builder.WithTags(tags)
                       .WithTags(otherTags);

      // Assert.
      builder.Tags.Should().BeEquivalentTo(otherTags);
    }

    [PrettyFact]
    public void Given_a_valid_BlogPostBuilder_When_Build_is_called_Then_a_matching_BlogPost_is_constructed()
    {
      // Arrange.
      BlogPostBuilder builder;
      BlogPost blogPost;

      string id = $"{Guid.NewGuid()}";
      const string content = "Content";
      BlogPostStatus draft = BlogPostStatus.Draft;
      ImmutableHashSet<Tag> tags = ImmutableHashSet.Create(Tag.Create("tag"));

      builder = BlogPostBuilder.Create()
                               .WithId(id)
                               .WithContent(content)
                               .WithStatus(draft)
                               .WithTags(tags);

      // Act.
      blogPost = builder.Build();

      // Assert.
      blogPost.Should().BeEquivalentTo(builder);
    }
  }
}