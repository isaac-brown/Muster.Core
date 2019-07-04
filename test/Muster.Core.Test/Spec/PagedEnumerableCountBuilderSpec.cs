// <copyright file="PagedEnumerableCountBuilderSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core.Utility.Pagination.Metadata;
  using PrettyTest;

  /// <summary>
  /// Unit tests for <see cref="PagedEnumerableCountBuilder"/>.
  /// </summary>
  public class PagedEnumerableCountBuilderSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_no_inputs_When_Create_is_called_Then_defaults_are_correct()
    {
      // Arrange.
      PagedEnumerableCountBuilder builder;

      // Act.
      builder = PagedEnumerableCountBuilder.Create();

      // Assert.
      builder.Current.Should().Be(0);
      builder.Total.Should().Be(0);
      builder.CountSkipped.Should().Be(0);
    }

    [PrettyFact]
    public void Given_a_negative_input_When_WithCurrent_is_called_Then_an_ArgumentOutOfRangeException_should_be_thrown()
    {
      // Arrange.
      var input = -1;
      var builder = PagedEnumerableCountBuilder.Create();

      // Act.
      Action testCode = () => builder.WithCurrent(input);

      // Assert.
      testCode.Should()
              .Throw<ArgumentOutOfRangeException>()
              .WithMessage($"Argument cannot be negative*Parameter name: current*Actual value was {input}.");
    }

    [PrettyFact]
    public void Given_a_non_negative_input_When_WithCurrent_is_called_Then_Current_should_equal_input()
    {
      // Arrange.
      var input = 1;
      var builder = PagedEnumerableCountBuilder.Create();

      // Act.
      builder = builder.WithCurrent(input);

      // Assert.
      builder.Current.Should().Be(input);
    }

    [PrettyFact]
    public void Given_a_negative_input_When_WithTotal_is_called_Then_an_ArgumentOutOfRangeException_should_be_thrown()
    {
      // Arrange.
      var input = -1;
      var builder = PagedEnumerableCountBuilder.Create();

      // Act.
      Action testCode = () => builder.WithTotal(input);

      // Assert.
      testCode.Should()
              .Throw<ArgumentOutOfRangeException>()
              .WithMessage($"Argument cannot be negative*Parameter name: total*Actual value was {input}.");
    }

    [PrettyFact]
    public void Given_a_non_negative_input_When_WithTotal_is_called_Then_Current_should_equal_input()
    {
      // Arrange.
      var input = 1;
      var builder = PagedEnumerableCountBuilder.Create();

      // Act.
      builder = builder.WithTotal(input);

      // Assert.
      builder.Total.Should().Be(input);
    }

    [PrettyFact]
    public void Given_a_negative_input_When_WithCountSkipped_is_called_Then_an_ArgumentOutOfRangeException_should_be_thrown()
    {
      // Arrange.
      var input = -1;
      var builder = PagedEnumerableCountBuilder.Create();

      // Act.
      Action testCode = () => builder.WithCountSkipped(input);

      // Assert.
      testCode.Should()
              .Throw<ArgumentOutOfRangeException>()
              .WithMessage($"Argument cannot be negative*Parameter name: countSkipped*Actual value was {input}.");
    }

    [PrettyFact]
    public void Given_a_non_negative_input_When_WithCountSkipped_is_called_Then_Current_should_equal_input()
    {
      // Arrange.
      var input = 1;
      var builder = PagedEnumerableCountBuilder.Create();

      // Act.
      builder = builder.WithCountSkipped(input);

      // Assert.
      builder.CountSkipped.Should().Be(input);
    }

    [PrettyFact]
    public void Given_well_formed_inputs_When_Build_is_called_Then_a_matching_PagedEnumerableCount_should_be_created()
    {
      // Arrange.
      int countSkipped = 1;
      int current = 2;
      int total = 3;

      PagedEnumerableCount count;

      // Act.
      count = PagedEnumerableCountBuilder
              .Create()
              .WithCurrent(current)
              .WithTotal(total)
              .WithCountSkipped(countSkipped)
              .Build();

      // Assert.
      count.Current.Should().Be(current);
      count.Total.Should().Be(total);
      count.Skipped.Should().Be(countSkipped);
    }
  }
}