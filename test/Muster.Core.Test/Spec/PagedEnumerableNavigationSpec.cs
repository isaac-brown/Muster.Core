// <copyright file="PagedEnumerableNavigationSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core.Utility.Pagination.Metadata;
  using PrettyTest;

  /// <summary>
  /// Unit tests for <see cref="PagedEnumerableNavigation"/>.
  /// </summary>
  /// <remarks>
  /// One reason this is here is to test the where non-negative inputs are passed to a builder,
  /// but inputs aren't valid at the time we create a <see cref="PagedEnumerableNavigation"/>.
  /// For reference, this is the summary of what this tests:
  ///
  /// | V Smaller/Larger -> |   First   |  Current  | Last |
  /// | ------------------- | :-------: | :-------: | :--: |
  /// | First               |     X     |     -     |  -   |
  /// | Current             | Exception |     X     |  -   |
  /// | Last                | Exception | Exception |  X   |
  ///
  /// > Note: Labels on the `X` axis have a larger value than those on the `Y` axis.
  ///
  /// Legend:
  ///  * `X` not applicable.
  ///  * `-` no exception should be thrown.
  ///  * `Exception` an exception should be thrown.
  /// </remarks>
  public class PagedEnumerableNavigationSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_a_builder_with_FirstPageNumber_greater_than_LastPageNumber_When_Create_is_called_Then_an_ArgumentOutOfRangeException_should_be_thrown()
    {
      // Arrange.
      var builder = PagedEnumerableNavigationBuilder
                    .Create()
                    .WithFirstPageNumber(10)
                    .WithCurrentPageNumber(1)
                    .WithLastPageNumber(1);

      // Act.
      Action testCode = () => PagedEnumerableNavigation.Create(builder);

      // Assert.
      testCode.Should()
              .Throw<ArgumentOutOfRangeException>()
              .WithMessage("*FirstPageNumber* must be less than *LastPageNumber*");
    }

    [PrettyFact]
    public void Given_a_builder_with_FirstPageNumber_greater_than_CurrentPageNumber_When_Create_is_called_Then_an_ArgumentOutOfRangeException_should_be_thrown()
    {
      // Arrange.
      var builder = PagedEnumerableNavigationBuilder
                    .Create()
                    .WithFirstPageNumber(1)
                    .WithCurrentPageNumber(0)
                    .WithLastPageNumber(1);

      // Act.
      Action testCode = () => PagedEnumerableNavigation.Create(builder);

      // Assert.
      testCode.Should()
              .Throw<ArgumentOutOfRangeException>()
              .WithMessage("*FirstPageNumber* must be less than *CurrentPageNumber*");
    }

    [PrettyFact]
    public void Given_a_builder_with_CurrentPageNumber_greater_than_LastPageNumber_When_Create_is_called_Then_an_ArgumentOutOfRangeException_should_be_thrown()
    {
      // Arrange.
      var builder = PagedEnumerableNavigationBuilder
                    .Create()
                    .WithFirstPageNumber(0)
                    .WithCurrentPageNumber(2)
                    .WithLastPageNumber(1);

      // Act.
      Action testCode = () => PagedEnumerableNavigation.Create(builder);

      // Assert.
      testCode.Should()
              .Throw<ArgumentOutOfRangeException>()
              .WithMessage("*CurrentPageNumber* must be less than *LastPageNumber*");
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_equal_to_FirstPageNumber_Then_HasPreviousPage_should_be_false()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 0;
      int lastPageNumber = 0;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.HasPreviousPage.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_equal_to_FirstPageNumber_Then_PreviousPageNumber_should_be_null()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 0;
      int lastPageNumber = 0;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.PreviousPageNumber.Should().BeNull();
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_equal_to_FirstPageNumber_Then_IsFirstPage_should_be_true()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 0;
      int lastPageNumber = 0;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.IsFirstPage.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_greater_than_FirstPageNumber_Then_HasPreviousPage_should_be_true()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 1;
      int lastPageNumber = 1;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.HasPreviousPage.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_greater_than_FirstPageNumber_Then_PreviousPageNumber_should_be_CurrentPageNumber_minus_one()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 1;
      int lastPageNumber = 1;
      int currentPageNumberMinusOne = currentPageNumber - 1;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.PreviousPageNumber.Should().Be(currentPageNumberMinusOne);
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_equal_to_LastPageNumber_Then_HasNextPage_should_be_false()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 0;
      int lastPageNumber = 0;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.HasNextPage.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_equal_to_LastPageNumber_Then_NextPageNumber_should_be_null()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 0;
      int lastPageNumber = 0;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.NextPageNumber.Should().BeNull();
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_equal_to_LastPageNumber_Then_IsLastPage_should_be_true()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 0;
      int lastPageNumber = 0;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.IsLastPage.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_less_than_LastPageNumber_Then_HasNextPage_should_be_true()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 1;
      int lastPageNumber = 2;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.HasNextPage.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_CurrentPageNumber_is_less_than_LastPageNumber_Then_NextPageNumber_should_be_CurrentPageNumber_plus_one()
    {
      // Arrange.
      int firstPageNumber = 0;
      int currentPageNumber = 1;
      int lastPageNumber = 2;
      int currentPageNumberPlusOne = currentPageNumber + 1;

      var navigation = PagedEnumerableNavigationBuilder
                       .Create()
                       .WithFirstPageNumber(firstPageNumber)
                       .WithCurrentPageNumber(currentPageNumber)
                       .WithLastPageNumber(lastPageNumber)
                       .Build();

      // Assert.
      navigation.NextPageNumber.Should().Be(currentPageNumberPlusOne);
    }

    [PrettyFact]
    public void Given_a_null_builder_When_Create_is_called_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Arrange.
      PagedEnumerableNavigationBuilder builder = null;

      // Act.
      Action testCode = () => PagedEnumerableNavigation.Create(builder);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*builder*");
    }

    [PrettyFact]
    public void When_Default_is_called_Then_FirstPageNumber_CurrentPageNumber_and_LastPageNumber_should_be_0()
    {
      // Act.
      var defaultNavigation = PagedEnumerableNavigation.Default();

      // Assert.
      defaultNavigation.FirstPageNumber.Should().Be(0L);
      defaultNavigation.CurrentPageNumber.Should().Be(0L);
      defaultNavigation.LastPageNumber.Should().Be(0L);
    }
  }
}