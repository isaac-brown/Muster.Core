// <copyright file="BlogPostSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
    using System;
    using Muster.Core;
    using Muster.Core.Entity;
    using Muster.Core.Exception;
    using Muster.Core.Test.Fixture;
    using FluentAssertions;
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
        public void Given_a_null_IClock_When_a_BlogPost_is_created_Then_a_ArgumentNullException_should_be_thrown()
        {
            // Given.
            BlogPost blogPost;
            IClock clock = null;

            // When.
            Action action = () => blogPost = BlogPost.Create(string.Empty, clock);

            // Then.
            action.Should().Throw<ArgumentNullException>("Because we need a valid clock reference to timestamp");
        }

        [PrettyFact]
        public void Given_content_that_is_null_When_a_BlogPost_is_created_Then_Content_should_be_null()
        {
            // Given.
            BlogPost blogPost;
            string content = null;

            // When.
            blogPost = BlogPost.Create(content, DummyClock.Create());

            // Then.
            blogPost.Content.Should().BeNull();
        }

        [PrettyFact]
        public void Given_content_that_is_empty_When_a_BlogPost_is_created_Then_Content_should_be_empty()
        {
            // Given.
            string content = string.Empty;
            BlogPost blogPost;

            // When.
            blogPost = BlogPost.Create(content, DummyClock.Create());

            // Then.
            blogPost.Content.Should().BeEmpty();
        }

        [PrettyFact]
        public void Given_a_current_Instant_When_a_BlogPost_is_created_Then_Created_is_equal_to_the_current_Instant()
        {
            // Given.
            IClock clock = ConstantClockStub.Create(10);
            Instant expected = clock.GetCurrentInstant();
            string content = "# Title\n\nHere is some content";

            // When.
            BlogPost blogPost = BlogPost.Create(content, clock);

            // Then.
            blogPost.Created.ToUnixTimeMilliseconds().Should().Be(10);
        }

        [PrettyFact]
        public void Given_valid_inputs_When_a_BlogPost_is_created_Then_Status_should_be_Draft()
        {
            // Given.
            IClock clock = DummyClock.Create();
            string content = string.Empty;

            // When.
            BlogPost blogPost = BlogPost.Create(content, clock);

            // Then.
            blogPost.Status.Should().Be(BlogPostStatus.Draft);
        }

        [PrettyFact]
        public void Given_valid_inputs_When_a_BlogPost_is_created_Then_Id_should_be_a_non_empty_Guid()
        {
            // Given.
            IClock clock = DummyClock.Create();
            string content = string.Empty;

            // When.
            BlogPost blogPost = BlogPost.Create(content, clock);

            // Then.
            blogPost.Id.Should().NotBeEmpty();
        }

        [PrettyFact]
        public void Given_valid_inputs_When_a_BlogPost_is_created_Then_Tags_should_be_empty()
        {
            // Given.
            BlogPost blogPost = DraftBlogPost.Create();

            // When.
            blogPost.Publish();

            // Then.
            blogPost.Tags.Should().BeEmpty();
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
