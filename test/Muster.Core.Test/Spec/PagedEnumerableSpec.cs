// <copyright file="PagedEnumerableSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using FluentAssertions;
  using Muster.Core.Utility.Pagination;
  using PrettyTest;

  /// <summary>
  /// Test cases for the <see cref="PagedEnumerable{T}"/> class.
  /// </summary>
  public class PagedEnumerableSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyFact]
    public void Given_builder_which_is_null_When_a_PagedEnumerable_is_created_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Given.
      PagedEnumerableBuilder<object> builder = null;

      // When.
      Action testCode = () => PagedEnumerable<object>.Create(builder);

      // Then.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*builder*");
    }
  }
}
