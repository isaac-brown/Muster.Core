// <copyright file="EnumerationSpec.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Spec
{
  using System;
  using System.Collections.Generic;
  using FluentAssertions;
  using Muster.Core.Test.Fixture;
  using Muster.Core.Utility;
  using PrettyTest;
  using Xunit;

  /// <summary>
  /// Unit tests for <see cref="Enumeration"/>.
  /// </summary>
  public partial class EnumerationSpec
  {
#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
#pragma warning disable SA1600 // Elements must be documented

    [PrettyTheory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" \t\r\n\v")]
    public void Given_null_empty_or_whitespace_displayName_When_an_instance_is_constructed_Then_an_ArgumentException_should_be_thrown(string invalidDisplayName)
    {
      // Arrange.
      string validKeyCode = "KEYCODE";

      // Act.
      Action testCode = () => new TestEnumeration(validKeyCode, invalidDisplayName);

      // Assert.
      testCode.Should()
              .Throw<ArgumentException>()
              .WithMessage("*cannot be null*displayName*");
    }

    [PrettyTheory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData(" \t\r\n\v")]
    public void Given_null_empty_or_whitespace_keyCode_When_an_instance_is_constructed_Then_an_ArgumentException_should_be_thrown(string invalidKeyCode)
    {
      // Arrange.
      string validDisplayName = "Display name";

      // Act.
      Action testCode = () => new TestEnumeration(invalidKeyCode, validDisplayName);

      // Assert.
      testCode.Should()
              .Throw<ArgumentException>()
              .WithMessage("*cannot be null*keyCode*");
    }

    [PrettyFact]
    public void Given_null_displayName_When_FromDisplayName_is_called_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Arrange.
      string displayName = null;

      // Act.
      Action testCode = () => Enumeration.FromDisplayName<EmployeeType>(displayName);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*displayName*");
    }

    [PrettyFact]
    public void Given_a_non_existant_displayName_When_FromDisplayName_is_called_Then_an_ApplicationException_should_be_thrown()
    {
      // Arrange.
      string displayName = "Invalid display name";

      // Act.
      Action testCode = () => Enumeration.FromDisplayName<EmployeeType>(displayName);

      // Assert.
      testCode.Should()
              .Throw<ApplicationException>()
              .WithMessage($"*'{displayName}' is not a valid displayName of *{nameof(EmployeeType)}*");
    }

    [PrettyFact]
    public void Given_a_valid_displayName_When_FromDisplayName_is_called_Then_an_Enumeration_with_the_same_DisplayName_should_be_returned()
    {
      // Arrange.
      string displayName = "Permanent";
      EmployeeType employeeType;

      // Act.
      employeeType = Enumeration.FromDisplayName<EmployeeType>(displayName);

      // Assert.
      employeeType.Should()
                  .NotBeNull();

      employeeType.DisplayName
                  .Should()
                  .Be(displayName);
    }

    [PrettyFact]
    public void Given_null_keyCode_When_FromKeyCode_is_called_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Arrange.
      string keyCode = null;

      // Act.
      Action testCode = () => Enumeration.FromKeyCode<EmployeeType>(keyCode);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*keyCode*");
    }

    [PrettyFact]
    public void Given_a_non_existant_keyCode_When_FromKeyCode_is_called_Then_an_ApplicationException_should_be_thrown()
    {
      // Arrange.
      string keyCode = "Invalid key code";

      // Act.
      Action testCode = () => Enumeration.FromKeyCode<EmployeeType>(keyCode);

      // Assert.
      testCode.Should()
              .Throw<ApplicationException>()
              .WithMessage($"*'{keyCode}' is not a valid keyCode of *{nameof(EmployeeType)}*");
    }

    [PrettyFact]
    public void Given_a_valid_keyCode_When_FromKeyCode_is_called_Then_an_Enumeration_with_the_same_KeyCode_should_be_returned()
    {
      // Arrange.
      string keyCode = "PERMANENT";
      EmployeeType employeeType;

      // Act.
      employeeType = Enumeration.FromKeyCode<EmployeeType>(keyCode);

      // Assert.
      employeeType.Should()
                  .NotBeNull();

      employeeType.KeyCode
                  .Should()
                  .Be(keyCode);
    }

    [PrettyFact]
    public void Given_an_object_which_is_null_When_Equals_is_called_Then_false_should_be_returned()
    {
      // Arrange.
      object nullObject = null;
      Enumeration enumeration = EmployeeType.Permanent;

      // Act.
      bool result = enumeration.Equals(nullObject);

      // Assert.
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_an_object_which_has_the_same_KeyCode_value_but_does_not_extend_Enumeration_When_Equals_is_called_Then_false_should_be_returned()
    {
      // Arrange.
      Enumeration enumeration = EmployeeType.Permanent;
      object objWithSameKeyCodeValue = new ObjectWithKeyCode(enumeration.KeyCode);

      // Act.
      bool result = enumeration.Equals(objWithSameKeyCodeValue);

      // Assert.
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_an_object_which_has_the_same_KeyCode_value_and_extends_Enumeration_but_is_not_of_the_same_Type_When_Equals_is_called_Then_false_should_be_returned()
    {
      // Arrange.
      Enumeration enumeration = EmployeeType.Permanent;
      Enumeration enumerationWithSameKeyCodeValue = new TestEnumeration(enumeration.KeyCode, "display name");

      // Act.
      bool result = enumeration.Equals(enumerationWithSameKeyCodeValue);

      // Assert.
      enumeration.KeyCode.Should().BeEquivalentTo(enumerationWithSameKeyCodeValue.KeyCode);
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_an_object_which_has_the_same_KeyCode_value_and_has_the_same_Type_When_Equals_is_called_Then_true_should_be_returned()
    {
      // Arrange.
      Enumeration enumeration = new TestEnumeration("SALAD", "Yummy yummy");
      Enumeration otherEnumeration = new TestEnumeration("SALAD", "In my tummy");

      // Act.
      bool result = enumeration.Equals(otherEnumeration);

      // Assert.
      // Ensure that we are asserting that Equals does equivalency by value of `KeyCode` rather than by reference equality.
      enumeration.Should().NotBeSameAs(otherEnumeration);
      result.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_both_objects_are_null_When_Equality_operator_is_invoked_Then_false_should_be_returned()
    {
      // Arrange.
      Enumeration leftHandSide = null;
      Enumeration rightHandSide = null;

      // Act.
      bool result = leftHandSide == rightHandSide;

      // Assert.
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_left_hand_object_is_null_When_Equality_operator_is_invoked_Then_false_should_be_returned()
    {
      // Arrange.
      Enumeration leftHandSide = null;
      Enumeration rightHandSide = EmployeeType.Permanent;

      // Act.
      bool result = leftHandSide == rightHandSide;

      // Assert.
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_right_hand_object_is_null_When_Equality_operator_is_invoked_Then_false_should_be_returned()
    {
      // Arrange.
      Enumeration leftHandSide = EmployeeType.Permanent;
      Enumeration rightHandSide = null;

      // Act.
      bool result = leftHandSide == rightHandSide;

      // Assert.
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_both_enumerations_have_the_same_KeyCode_value_and_Type_When_Equality_operator_is_invoked_Then_true_should_be_returned()
    {
      // Arrange.
      Enumeration enumeration = new TestEnumeration("BEANS", "are great");
      Enumeration otherEnumeration = new TestEnumeration("BEANS", "are good");

      // Act.
      bool result = enumeration == otherEnumeration;

      // Assert.
      enumeration.Should().NotBeSameAs(otherEnumeration);
      result.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_both_enumerations_have_the_same_KeyCode_value_but_different_Type_When_Equality_operator_is_invoked_Then_false_should_be_returned()
    {
      // Arrange.
      Enumeration enumeration = EmployeeType.Permanent;
      Enumeration otherEnumeration = new TestEnumeration(enumeration.KeyCode, enumeration.DisplayName);

      // Act.
      bool result = enumeration == otherEnumeration;

      // Assert.
      enumeration.Should().NotBeSameAs(otherEnumeration);
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_both_objects_are_null_When_Inequality_operator_is_invoked_Then_true_should_be_returned()
    {
      // Arrange.
      Enumeration leftHandSide = null;
      Enumeration rightHandSide = null;

      // Act.
      bool result = leftHandSide != rightHandSide;

      // Assert.
      result.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_left_hand_object_is_null_When_Inequality_operator_is_invoked_Then_true_should_be_returned()
    {
      // Arrange.
      Enumeration leftHandSide = null;
      Enumeration rightHandSide = EmployeeType.Permanent;

      // Act.
      bool result = leftHandSide != rightHandSide;

      // Assert.
      result.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_right_hand_object_is_null_When_Inequality_operator_is_invoked_Then_true_should_be_returned()
    {
      // Arrange.
      Enumeration leftHandSide = EmployeeType.Permanent;
      Enumeration rightHandSide = null;

      // Act.
      bool result = leftHandSide != rightHandSide;

      // Assert.
      result.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_both_enumerations_have_the_same_KeyCode_value_and_Type_When_Inequality_operator_is_invoked_Then_false_should_be_returned()
    {
      // Arrange.
      Enumeration enumeration = new TestEnumeration("BEANS", "Beans");
      Enumeration otherEnumeration = new TestEnumeration("BEANS", "Maybe not");

      // Act.
      bool result = enumeration != otherEnumeration;

      // Assert.
      enumeration.Should().NotBeSameAs(otherEnumeration);
      result.Should().BeFalse();
    }

    [PrettyFact]
    public void Given_both_enumerations_have_the_same_KeyCode_value_but_different_Type_When_Inequality_operator_is_invoked_Then_true_should_be_returned()
    {
      // Arrange.
      Enumeration enumeration = EmployeeType.Permanent;
      Enumeration otherEnumeration = new TestEnumeration(enumeration.KeyCode, enumeration.DisplayName);

      // Act.
      bool result = enumeration != otherEnumeration;

      // Assert.
      enumeration.Should().NotBeSameAs(otherEnumeration);
      result.Should().BeTrue();
    }

    [PrettyFact]
    public void Given_an_Enumeration_with_no_public_static_getters_When_GetAll_is_called_Then_an_empty_array_should_be_returned()
    {
      // Arrange.
      IEnumerable<EmptyEnumeration> options;

      // Act.
      options = Enumeration.GetAll<EmptyEnumeration>();

      // Assert.
      options.Should().BeEmpty();
    }

    [PrettyFact]
    public void Given_an_Enumeration_with_a_public_static_getter_that_returns_an_object_which_is_not_of_type_Enumeration_When_GetAll_is_called_Then_an_empty_array_should_be_returned()
    {
      // Arrange.
      IEnumerable<NoValidOptionsEnumeration> options;

      // Act.
      options = Enumeration.GetAll<NoValidOptionsEnumeration>();

      // Assert.
      options.Should().BeEmpty();
    }

    [PrettyFact]
    public void Given_a_class_with_one_or_more_public_static_getters_that_returns_an_object_of_type_Enumeration_When_GetAll_is_called_Then_an_array_with_items_should_be_returned()
    {
      // Arrange.
      IEnumerable<Enumeration> options;
      IEnumerable<Enumeration> expectedOptions = new List<Enumeration>()
      {
        EmployeeType.Permanent,
      };

      // Act.
      options = Enumeration.GetAll<EmployeeType>();

      // Assert.
      options.Should().BeEquivalentTo(expectedOptions);
    }

    [PrettyTheory]
    [InlineData("KEYCODE", "Display Name")]
    [InlineData("blah", "Something or the other")]
    [InlineData("Something", "Something")]
    public void Given_an_instance_of_Enumeration_When_ToString_is_called_Then_the_DisplayName_should_be_returned(string keyCode, string displayName)
    {
      // Arrange.
      Enumeration instanceOfEnumeration = new TestEnumeration(keyCode, displayName);
      string expected = instanceOfEnumeration.DisplayName;

      // Act.
      string actual = instanceOfEnumeration.ToString();

      // Assert.
      actual.Should().Be(expected);
    }

    [PrettyTheory]
    [InlineData("KEYCODE", "Display Name")]
    [InlineData("blah", "Something or the other")]
    [InlineData("Something", "Something")]
    public void Given_an_instance_of_Enumeration_When_GetHashCode_is_called_Then_the_hash_of_KeyCode_should_be_returned(string keyCode, string displayName)
    {
      // Arrange.
      Enumeration instanceOfEnumeration = new TestEnumeration(keyCode, displayName);
      int expectedHashCode = instanceOfEnumeration.KeyCode.GetHashCode();

      // Act.
      int actualHashCode = instanceOfEnumeration.GetHashCode();

      // Assert.
      actualHashCode.Should().Be(expectedHashCode);
    }

    [PrettyFact]
    public void Given_instances_with_the_same_KeyCode_When_CompareTo_is_called_Then_result_should_be_0()
    {
      // Arrange.
      Enumeration enumeration = EmployeeType.Permanent;
      Enumeration otherEnumeration = EmployeeType.Permanent;

      // Act.
      int result = enumeration.CompareTo(otherEnumeration);

      // Assert.
      result.Should().Be(0);
    }

    [PrettyFact]
    public void Given_other_enumeration_has_a_KeyCode_with_a_higher_value_When_CompareTo_is_called_Then_result_should_be_negative_one()
    {
      // Arrange.
      Enumeration enumeration = new TestEnumeration("A", "enumeration");
      Enumeration otherEnumeration = new TestEnumeration("B", "other enumeration");

      // Act.
      int result = enumeration.CompareTo(otherEnumeration);

      // Assert.
      result.Should().Be(-1);
    }

    [PrettyFact]
    public void Given_other_enumeration_has_a_KeyCode_with_a_lower_value_When_CompareTo_is_called_Then_result_should_be_1()
    {
      // Arrange.
      Enumeration enumeration = new TestEnumeration("B", "other enumeration");
      Enumeration otherEnumeration = new TestEnumeration("A", "enumeration");

      // Act.
      int result = enumeration.CompareTo(otherEnumeration);

      // Assert.
      result.Should().Be(1);
    }

    [PrettyFact]
    public void Given_other_object_is_not_of_type_Enumeration_When_CompareTo_is_called_Then_an_ArgumentException_should_be_thrown()
    {
      // Arrange.
      Enumeration enumeration = new TestEnumeration("B", "other enumeration");
      object otherObject = new { something = "1" };

      // Act.
      Action testCode = () => enumeration.CompareTo(otherObject);

      // Assert.
      testCode.Should()
              .Throw<ArgumentException>()
              .WithMessage($"*expected to be of type [{typeof(Enumeration)}]*found [{otherObject.GetType()}]*Parameter name: other*");
    }

    [PrettyFact]
    public void Given_other_object_is_null_When_CompareTo_is_called_Then_an_ArgumentNullException_should_be_thrown()
    {
      // Arrange.
      Enumeration enumeration = new TestEnumeration("B", "other enumeration");
      object otherObject = null;

      // Act.
      Action testCode = () => enumeration.CompareTo(otherObject);

      // Assert.
      testCode.Should()
              .Throw<ArgumentNullException>()
              .WithMessage("*cannot be null*Parameter name: other*");
    }

    /// <summary>
    /// Test class that has a property KeyCode, but which doesn't extend <see cref="Enumeration"/>.
    /// </summary>
    private class ObjectWithKeyCode
    {
      public ObjectWithKeyCode(string keyCode)
      {
        this.KeyCode = keyCode;
      }

      public string KeyCode { get; set; }
    }

    private class TestEnumeration : Enumeration
    {
      public TestEnumeration(string keyCode, string displayName)
        : base(keyCode, displayName)
      {
      }
    }

    private class EmptyEnumeration : Enumeration
    {
      protected EmptyEnumeration(string keyCode, string displayName)
        : base(keyCode, displayName)
      {
      }
    }

    /// <summary>
    /// Class which has no public static properties declared which return a value which extends type <see cref="Enumeration"/>.
    /// The whole point of this is to ensure that we can test cases exhibit the correct behaviour.
    /// </summary>
    private class NoValidOptionsEnumeration : Enumeration
    {
      private NoValidOptionsEnumeration(string keyCode, string displayName)
          : base(keyCode, displayName)
      {
      }

      public static ObjectWithKeyCode PublicStaticNonEnumerationOption => new ObjectWithKeyCode("3");

      public NoValidOptionsEnumeration PublicInstanceOption => new NoValidOptionsEnumeration("2", "2");

      private static NoValidOptionsEnumeration PrivateStaticOption => new NoValidOptionsEnumeration("1", "1");
    }
  }
}