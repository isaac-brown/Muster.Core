// <copyright file="PagedEnumerableMetadataSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core.Utility.Pagination.Metadata;
  using PrettyTest;

  /// <summary>
  /// Unit tests for the <see cref="PagedEnumerableMetadata"/> class.
  /// </summary>
  public class PagedEnumerableMetadataSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_a_null_builder_When_Create_is_called_Then_an_AgrumentNullException_should_be_thrown()
    {
      // Arrange.
      PagedEnumerableMetadataBuilder builder = null;

      // Act.
      Action testCode = () => PagedEnumerableMetadata.Create(builder);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*builder*");
    }

    [PrettyFact]
    public void When_Default_is_called_Then_Count_and_Navigation_should_equal_respective_Default()
    {
      // Act.
      var defaultMetadata = PagedEnumerableMetadata.Default();
      var defaultCount = PagedEnumerableCount.Default();
      var defaultNavigation = PagedEnumerableNavigation.Default();

      // Assert.
      defaultMetadata.Count.Should().BeEquivalentTo(defaultCount);
      defaultMetadata.Navigation.Should().BeEquivalentTo(defaultNavigation);
    }
  }
}