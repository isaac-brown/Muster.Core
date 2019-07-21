// <copyright file="Tag.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Entity
{
  using System;

  /// <summary>
  /// A tag to help describe and categorize a <see cref="BlogPost"/>.
  /// </summary>
  public class Tag
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Tag"/> class
    /// using the given name.
    /// </summary>
    /// <param name="name">The name for the tag.</param>
    protected Tag(string name)
    {
      string trimmedName = name?.Trim();
      if (trimmedName == string.Empty)
      {
        throw new ArgumentException("cannot be empty or whitespace", nameof(name));
      }

      this.Name = trimmedName ?? throw new ArgumentNullException(nameof(name));
    }

    /// <summary>
    /// Gets the name of the <see cref="Tag"/>.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Tag"/> class
    /// using the given name.
    /// </summary>
    /// <param name="name">The name for the tag.</param>
    /// <returns>A new <see cref="Tag"/> instance.</returns>
    public static Tag FromName(string name)
    {
      return new Tag(name);
    }
  }
}