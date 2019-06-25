// <copyright file="PagedEnumerableBuilderSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Muster.Core.Test.Fixture;
  using Muster.Core.Utility.Pagination;
  using Muster.Core.Utility.Pagination.Metadata;
  using PrettyTest;
  using Xunit;

  /// <summary>
  /// Unit tests for <see cref="PagedEnumerableBuilder{T}"/>.
  /// </summary>
  public class PagedEnumerableBuilderSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    public static IEnumerable<object[]> GetValidMetadata()
    {
      yield return new object[] { PagedEnumerableMetadataFactory.WellFormed() };
    }

    [PrettyFact]
    public void Given_null_records_When_WithRecords_is_called_Then_should_throw_ArgumentNullException()
    {
      // Arrange.
      IEnumerable<object> records = null;
      var builder = PagedEnumerableBuilder<object>.Create();

      // Act.
      Action testAction = () => builder.WithRecords(records);

      // Assert.
      testAction.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("*cannot be null*records*");
    }

    [PrettyFact]
    public void Given_null_metadata_When_WithMetadata_is_called_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Arrange.
      var metadata = PagedEnumerableMetadataFactory.Null();
      var builder = PagedEnumerableBuilder<object>.Create();

      // Act.
      Action testAction = () => builder.WithMetadata(metadata);

      // Assert.
      testAction.Should()
                .Throw<ArgumentNullException>()
                .WithMessage("*cannot be null*metadata*");
    }

    [PrettyFact]
    public void Given_no_inputs_When_Create_is_called_Then_Metadata_should_be_same_as_Default_PagedEnumerableMetadata()
    {
      // Arrange.
      PagedEnumerableMetadata defaultMetadata = PagedEnumerableMetadata.Default();
      PagedEnumerableBuilder<object> builder;

      // Act.
      builder = PagedEnumerableBuilder<object>.Create();

      // Assert.
      builder.Metadata.Should().BeEquivalentTo(defaultMetadata);
    }

    [PrettyFact]
    public void Given_no_inputs_When_Create_is_called_Then_Records_should_be_empty()
    {
      // Arrange.
      PagedEnumerableBuilder<object> builder;

      // Act.
      builder = PagedEnumerableBuilder<object>.Create();

      // Assert.
      builder.Records.Should().BeEmpty();
    }

    [PrettyTheory]
    [InlineData("hello", "world")]
    public void Given_valid_input_When_WithRecords_is_called_Then_Records_should_equal_input(params string[] input)
    {
      // Arrange.
      var builder = PagedEnumerableBuilder<string>.Create();

      // Act.
      builder = builder.WithRecords(input);

      // Assert.
      builder.Records.Should().BeEquivalentTo(input);
    }

    [PrettyTheory]
    [MemberData(nameof(GetValidMetadata))]
    public void Given_valid_input_When_WithMetadata_is_called_Then_Metadata_should_equal_input(PagedEnumerableMetadata metadata)
    {
      // Arrange.
      var builder = PagedEnumerableBuilder<object>.Create();

      // Act.
      builder = builder.WithMetadata(metadata);

      // Assert.
      builder.Metadata.Should().BeEquivalentTo(metadata);
    }

    [PrettyFact]
    public void Given_valid_inputs_When_Build_is_called_Then_a_matching_PagedEnumerable_should_be_created()
    {
      // Arrange.
      IEnumerable<object> records = new object[] { "Hello", "World" };
      PagedEnumerableMetadata metadata = PagedEnumerableMetadataFactory.WellFormed();

      var builder = PagedEnumerableBuilder<object>.Create()
        .WithMetadata(metadata)
        .WithRecords(records);

      // Act.
      var pagedEnumerable = builder.Build();

      // Assert.
      pagedEnumerable.Records.Should().BeEquivalentTo(records);
      pagedEnumerable.Metadata.Should().BeEquivalentTo(metadata);
    }
  }
}