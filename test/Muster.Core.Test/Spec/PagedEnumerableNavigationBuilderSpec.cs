// <copyright file="PagedEnumerableNavigationBuilderSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core.Utility.Pagination.Metadata;
  using PrettyTest;
  using Xunit;

  /// <summary>
  /// Tests for the <see cref="PagedEnumerableNavigationBuilder"/>.
  /// </summary>
  public class PagedEnumerableNavigationBuilderSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_no_inputs_When_Create_is_called_Then_defaults_are_set()
    {
      // Arrange.
      PagedEnumerableNavigationBuilder builder;

      // Act.
      builder = PagedEnumerableNavigationBuilder.Create();

      // Assert.
      builder.FirstPageNumber.Should().Be(0);
      builder.CurrentPageNumber.Should().Be(0);
      builder.LastPageNumber.Should().Be(0);
    }

    [PrettyFact]
    public void Given_a_negative_input_When_WithFirstPageNumber_is_called_Then_an_ArgumentOutOfRangeException_should_be_thrown()
    {
      // Arrange.
      int input = -1;
      var builder = PagedEnumerableNavigationBuilder.Create();

      // Act.
      Action testCode = () => builder.WithFirstPageNumber(input);

      // Assert.
      testCode
        .Should()
        .Throw<ArgumentOutOfRangeException>()
        .WithMessage("*firstPageNumber cannot be negative*");
    }

    [PrettyFact]
    public void Given_a_positive_input_When_WithFirstPageNumber_is_called_Then_CurrentPageNumber_should_equal_input()
    {
      // Arrange.
      int input = 1;
      var builder = PagedEnumerableNavigationBuilder.Create();

      // Act.
      builder = builder.WithFirstPageNumber(input);

      // Assert.
      builder.FirstPageNumber.Should().Be(input);
    }

    [PrettyFact]
    public void Given_a_negative_input_When_WithCurrentPageNumber_is_called_Then_an_ArgumentOutOfRangeException_should_be_thrown()
    {
      // Arrange.
      int input = -1;
      var builder = PagedEnumerableNavigationBuilder.Create();

      // Act.
      Action testCode = () => builder.WithCurrentPageNumber(input);

      // Assert.
      testCode
        .Should()
        .Throw<ArgumentOutOfRangeException>()
        .WithMessage("*currentPageNumber cannot be negative*");
    }

    [PrettyFact]
    public void Given_a_positive_input_When_WithCurrentPageNumber_is_called_Then_CurrentPageNumber_should_equal_input()
    {
      // Arrange.
      int input = 1;
      var builder = PagedEnumerableNavigationBuilder.Create();

      // Act.
      builder = builder.WithCurrentPageNumber(input);

      // Assert.
      builder.CurrentPageNumber.Should().Be(input);
    }

    [PrettyFact]
    public void Given_a_negative_input_When_WithLastPageNumber_is_called_Then_an_ArgumentOutOfRangeException_should_be_thrown()
    {
      // Arrange.
      int input = -1;
      var builder = PagedEnumerableNavigationBuilder.Create();

      // Act.
      Action testCode = () => builder.WithLastPageNumber(input);

      // Assert.
      testCode
        .Should()
        .Throw<ArgumentOutOfRangeException>()
        .WithMessage("*lastPageNumber cannot be negative*");
    }

    [PrettyFact]
    public void Given_a_positive_input_When_WithLastPageNumber_is_called_Then_LastPageNumber_should_equal_input()
    {
      // Arrange.
      int input = 1;
      var builder = PagedEnumerableNavigationBuilder.Create();

      // Act.
      builder = builder.WithLastPageNumber(input);

      // Assert.
      builder.LastPageNumber.Should().Be(input);
    }

    [PrettyFact]
    public void Given_valid_inputs_When_Build_is_called_Then_a_matching_PagedEnumerableNavigation_object_should_be_created()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 1;
      int lastPageNumber = 2;
      PagedEnumerableNavigation navigation;

      // Act.
      navigation = PagedEnumerableNavigationBuilder
                   .Create()
                   .WithFirstPageNumber(firstPageNumber)
                   .WithCurrentPageNumber(currentPageNumber)
                   .WithLastPageNumber(lastPageNumber)
                   .Build();

      // Assert.
      navigation.FirstPageNumber.Should().Be(firstPageNumber);
      navigation.CurrentPageNumber.Should().Be(currentPageNumber);
      navigation.LastPageNumber.Should().Be(lastPageNumber);
    }
  }
}
