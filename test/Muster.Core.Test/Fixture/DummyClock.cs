// <copyright file="DummyClock.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Test.Fixture
{
  using NodaTime;

  /// <summary>
  /// <para>
  ///     An <see cref="IClock"/> implementation that has no logic whatsoever, is to be used as a parameter, when that parameter will not be of use.
  /// </para>
  /// <remark>
  ///     For construction see the <see cref="Create"/> factory method.
  /// </remark>
  /// </summary>
  internal class DummyClock : IClock
  {
    private DummyClock()
        : base()
    {
    }

    /// <summary>
    /// Factory method to create a new instance of <see cref="DummyClock"/>.
    /// </summary>
    /// <returns>A new <see cref="DummyClock"/> instance.</returns>
    public static IClock Create()
    {
      return new DummyClock();
    }

    /// <inheritdoc/>
    public Instant GetCurrentInstant()
    {
      return default(Instant);
    }
  }
}
