// <copyright file="EmployeeType.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Fixture
{
  using Muster.Core.Utility;

  /// <summary>
  /// Class for testing with <see cref="Enumeration"/>.
  /// </summary>
  public class EmployeeType : Enumeration
  {
    private EmployeeType(string keyCode, string displayName)
        : base(keyCode, displayName)
    {
    }

    /// <summary>
    /// Gets a value representing an employee that is permanent.
    /// </summary>
    public static EmployeeType Permanent => new EmployeeType("PERMANENT", "Permanent");
  }
}
