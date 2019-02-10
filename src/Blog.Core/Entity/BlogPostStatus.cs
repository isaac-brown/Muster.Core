// <copyright file="BlogPostStatus.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Blog.Core
{
    using Blog.Core.Entity;
    using Blog.Core.Utility;

    /// <summary>
    /// Represents the possible status' of a <see cref="BlogPost"/>.
    /// </summary>
    public class BlogPostStatus : Enumeration
    {
        private BlogPostStatus(string keyCode, string displayName)
            : base(keyCode, displayName)
        {
        }

        /// <summary>
        /// Gets a status that indicates that a <see cref="BlogPost"/> is a draft, and has not yet been published for viewing.
        /// </summary>
        public static BlogPostStatus Draft => new BlogPostStatus(nameof(Draft).ToUpperInvariant(), nameof(Draft));

        /// <summary>
        /// Gets a status that indicates that a <see cref="BlogPost"/> has been published for viewing.
        /// </summary>
        public static BlogPostStatus Published => new BlogPostStatus(nameof(Published).ToUpperInvariant(), nameof(Published));
    }
}