// <copyright file="PagedEnumerableCountSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core.Utility.Pagination.Metadata;
  using PrettyTest;

  /// <summary>
  /// Unit tests for the <see cref="PagedEnumerableCount"/> class.
  /// </summary>
  public class PagedEnumerableCountSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_a_null_builder_When_Create_is_called_Then_an_AgrumentNullException_should_be_thrown()
    {
      // Arrange.
      PagedEnumerableCountBuilder builder = null;

      // Act.
      Action testCode = () => PagedEnumerableCount.Create(builder);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*builder*");
    }

    [PrettyFact]
    public void When_Default_is_called_Then_Taken_Total_and_Current_should_be_0()
    {
      // Act.
      var defaultCount = PagedEnumerableCount.Default();

      // Assert.
      defaultCount.Current.Should().Be(0);
      defaultCount.Taken.Should().Be(0);
      defaultCount.Total.Should().Be(0);
    }
  }
}