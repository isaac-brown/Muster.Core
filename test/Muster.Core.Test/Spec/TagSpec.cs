// <copyright file="TagSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core.Entity;
  using PrettyTest;
  using Xunit;

  /// <summary>
  /// Unit tests for <see cref="Tag"/> object.
  /// </summary>
  public class TagSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_a_null_name_When_FromName_is_called_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Given.
      string name = null;

      // When.
      Action action = () => Tag.FromName(name);

      // Then.
      action.Should().Throw<ArgumentNullException>("Because null is not a good name for a tag which is visible");
    }

    [PrettyTheory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("   ")]
    [InlineData("\t")]
    [InlineData("\r\n")]
    public void Given_a_name_that_is_empty_is_blank_When_FromName_is_called_Then_an_ArgumentException_should_be_thrown(string name)
    {
      // Given.

      // When.
      Action action = () => Tag.FromName(name);

      // Then.
      action.Should().Throw<ArgumentException>("Because a blank string is not a good name for a tag which is visible");
    }

    [PrettyFact]
    public void Given_a_name_that_is_valid_When_FromName_is_called_Then_the_Tag_Name_should_be_set()
    {
      // Given.
      string name = "tag";

      // When.
      Tag tag = Tag.FromName(name);

      // Then.
      tag.Name.Should().BeEquivalentTo(name);
    }

    [PrettyTheory]
    [InlineData(" tag name ", "tag name")]
    [InlineData(" Shoes", "Shoes")]
    [InlineData("Blah ", "Blah")]
    [InlineData("\tTag", "Tag")]
    public void Given_a_whitepace_padded_name_that_is_valid_When_FromName_is_called_Then_the_Tag_Name_should_be_set(string name, string expected)
    {
      // Given.
      Tag tag;

      // When.
      tag = Tag.FromName(name);

      // Then.
      tag.Name.Should().BeEquivalentTo(expected);
    }

    [PrettyFact]
    public void Given_an_object_which_is_not_of_type_Tag_When_Equals_is_called_Then_false_should_be_returned()
    {
      // Arrange.
      object obj = new { field = "value" };
      Tag tag = Tag.FromName("Tag");

      // Act.
      bool result = tag.Equals(obj);

      // Assert.
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_an_object_which_null_When_Equals_is_called_Then_false_should_be_returned()
    {
      // Arrange.
      object obj = null;
      Tag tag = Tag.FromName("Tag");

      // Act.
      bool result = tag.Equals(obj);

      // Assert.
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_a_Tag_which_has_a_different_Name_When_Equals_is_called_Then_false_should_be_returned()
    {
      // Arrange.
      Tag tag = Tag.FromName("Tag");
      Tag otherTag = Tag.FromName("OtherTag");

      // Act.
      bool result = tag.Equals(otherTag);

      // Assert.
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_a_Tag_which_has_the_same_Name_When_Equals_is_called_Then_true_should_be_returned()
    {
      // Arrange.
      Tag tag = Tag.FromName("Tag");
      Tag otherTag = Tag.FromName("Tag");

      // Act.
      bool result = tag.Equals(otherTag);

      // Assert.
      result.Should().BeTrue();
    }
  }
}
