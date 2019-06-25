// <copyright file="PagedEnumerableMetadataBuilderSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core.Utility.Pagination.Metadata;
  using PrettyTest;

  /// <summary>
  /// Unit tests for <see cref="PagedEnumerableMetadataBuilder"/>
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
      var defaultNavigation = PagedEnumerableNavigation.Default();
      PagedEnumerableMetadata metadata;

      // Act.
      metadata = PagedEnumerableMetadataBuilder.Create()
                                               .Build();

      // Assert.
      metadata.Count.Should().BeEquivalentTo(defaultCount);
      metadata.Navigation.Should().BeEquivalentTo(defaultNavigation);
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
      validInput = PagedEnumerableCountBuilder.Create()
                                              .WithCountSkipped(1)
                                              .WithCurrent(10)
                                              .WithTotal(100)
                                              .Build();

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
    public void Given_null_input_When_WithNavigation_is_called_Then_an_ArgumentNullException_will_be_thrown()
    {
      // Arrange.
      PagedEnumerableNavigation input = null;
      PagedEnumerableMetadataBuilder builder = PagedEnumerableMetadataBuilder.Create();

      // Act.
      Action testCode = () => builder.WithNavigation(input);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null* navigation*");
    }

    [PrettyFact]
    public void Given_valid_input_When_WithNavigation_is_called_Then_Navigation_will_be_set()
    {
      // Arrange.
      PagedEnumerableNavigation validInput;
      validInput = PagedEnumerableNavigationBuilder.Create()
                                                   .WithCurrentPageNumber(1)
                                                   .WithLastPageNumber(10)
                                                   .Build();

      PagedEnumerableMetadataBuilder builder = PagedEnumerableMetadataBuilder.Create();
      PagedEnumerableMetadata metadata;

      // Act.
      metadata = builder.WithNavigation(validInput)
                        .Build();

      // Assert.
      metadata.Navigation.Should()
                         .BeEquivalentTo(validInput);
    }

    [PrettyFact]
    public void Given_well_formed_inputs_When_Build_is_called_Then_a_matching_PagedEnumerableMetadata_should_be_created()
    {
      // Arrange.
      // TODO: Move into a factory class.
      PagedEnumerableCount count;
      count = PagedEnumerableCountBuilder.Create()
                                         .WithCountSkipped(1)
                                         .WithCurrent(10)
                                         .WithTotal(100)
                                         .Build();

      PagedEnumerableNavigation navigation;
      navigation = PagedEnumerableNavigationBuilder.Create()
                                                   .WithCurrentPageNumber(1)
                                                   .WithLastPageNumber(10)
                                                   .Build();

      PagedEnumerableMetadata metadata;

      // Act.
      metadata = PagedEnumerableMetadataBuilder
              .Create()
              .WithCount(count)
              .WithNavigation(navigation)
              .Build();

      // Assert.
      metadata.Count.Should().BeEquivalentTo(count);
      metadata.Navigation.Should().BeEquivalentTo(navigation);
    }
  }
}