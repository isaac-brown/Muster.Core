// <copyright file="IBuilder.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Utility
{
  /// <summary>
  /// Interface for the builder pattern.
  /// </summary>
  /// <typeparam name="T">The type of object that will be built.</typeparam>
  public interface IBuilder<T>
  {
    /// <summary>
    /// Builds an instance of <typeparamref name="T"/>.
    /// </summary>
    /// <returns>An instance of <typeparamref name="T"/>.</returns>
    T Build();
  }
}
