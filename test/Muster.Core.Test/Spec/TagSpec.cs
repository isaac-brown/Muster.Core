// <copyright file="TagSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
    using System;
    using Muster.Core.Entity;
    using FluentAssertions;
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
        public void Given_a_null_name_When_a_Tag_is_created_Then_an_ArgumentNullException_should_be_thrown()
        {
            // Given.
            string name = null;

            // When.
            Action action = () => Tag.Create(name);

            // Then.
            action.Should().Throw<ArgumentNullException>("Because null is not a good name for a tag which is visible");
        }

        [PrettyTheory]
        [InlineData("")]
        [InlineData(" ")]
        [InlineData("   ")]
        [InlineData("\t")]
        [InlineData("\r\n")]
        public void Given_a_name_that_is_empty_is_blank_When_a_Tag_is_created_Then_an_ArgumentException_should_be_thrown(string name)
        {
            // Given.

            // When.
            Action action = () => Tag.Create(name);

            // Then.
            action.Should().Throw<ArgumentException>("Because a blank string is not a good name for a tag which is visible");
        }

        [PrettyFact]
        public void Given_a_name_that_is_valid_When_a_Tag_is_created_Then_the_Tag_Name_should_be_set()
        {
            // Given.
            string name = "tag";

            // When.
            Tag tag = Tag.Create(name);

            // Then.
            tag.Name.Should().BeEquivalentTo(name);
        }

        [PrettyTheory]
        [InlineData(" tag name ", "tag name")]
        [InlineData(" Shoes", "Shoes")]
        [InlineData("Blah ", "Blah")]
        [InlineData("\tTag", "Tag")]
        public void Given_a_whitepace_padded_name_that_is_valid_When_a_Tag_is_created_Then_the_Tag_Name_should_be_set(string name, string expected)
        {
            // Given.
            Tag tag;

            // When.
            tag = Tag.Create(name);

            // Then.
            tag.Name.Should().BeEquivalentTo(expected);
        }

        [PrettyFact]
        public void Given_valid_inputs_When_a_Tag_is_created_Then_Tag_Id_should_be_a_non_empty_Guid()
        {
            // Given.
            string name = "tag name";

            // When.
            Tag tag = Tag.Create(name);

            // Then.
            tag.Id.Should().NotBeEmpty();
        }
    }
}
