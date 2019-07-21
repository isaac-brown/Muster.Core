// <copyright file="PagedEnumerableMetadataBuilderSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core.Test.Fixture;
  using Muster.Core.Utility.Pagination.Metadata;
  using PrettyTest;
  using Xunit;

  /// <summary>
  /// Unit tests for <see cref="PagedEnumerableMetadataBuilder"/>.
  /// </summary>
  public class PagedEnumerableMetadataBuilderSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_no_inputs_When_Create_is_called_Then_instance_will_have_Default_members()
    {
      // Arrange.
      var defaultCount = PagedEnumerableCount.Default();
      PagedEnumerableMetadataBuilder builder;

      // Act.
      builder = PagedEnumerableMetadataBuilder.Create();

      // Assert.
      builder.Count.Should().BeEquivalentTo(defaultCount);
      builder.HasMore.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_null_input_When_WithCount_is_called_Then_an_ArgumentNullException_will_be_thrown()
    {
      // Arrange.
      PagedEnumerableCount input = null;
      PagedEnumerableMetadataBuilder builder = PagedEnumerableMetadataBuilder.Create();

      // Act.
      Action testCode = () => builder.WithCount(input);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null* count*");
    }

    [PrettyFact]
    public void Given_valid_input_When_WithCount_is_called_Then_Count_will_be_set()
    {
      // Arrange.
      PagedEnumerableCount validInput;
      validInput = PagedEnumerableCountFactory.WellFormed();

      PagedEnumerableMetadataBuilder builder = PagedEnumerableMetadataBuilder.Create();
      PagedEnumerableMetadata metadata;

      // Act.
      metadata = builder.WithCount(validInput)
                        .Build();

      // Assert.
      metadata.Count.Should()
                    .BeEquivalentTo(validInput);
    }

    [PrettyFact]
    public void Given_valid_input_When_WithHasMore_is_called_Then_HasMore_will_be_set()
    {
      // Arrange.
      PagedEnumerableMetadataBuilder builder;
      builder = PagedEnumerableMetadataBuilder.Create();

      // Act.
      builder = builder.WithHasMore(true);

      // Assert.
      builder.HasMore.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_well_formed_inputs_When_Build_is_called_Then_a_matching_PagedEnumerableMetadata_should_be_created()
    {
      // Arrange.
      var count = PagedEnumerableCountFactory.WellFormed();

      PagedEnumerableMetadata metadata;
      const bool hasMore = true;

      // Act.
      metadata = PagedEnumerableMetadataBuilder
                 .Create()
                 .WithCount(count)
                 .WithHasMore(hasMore)
                 .Build();

      // Assert.
      metadata.Count.Should().BeEquivalentTo(count);
      metadata.HasMore.Should().Be(hasMore);
    }
  }
}