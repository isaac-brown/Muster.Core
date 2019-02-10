// <copyright file="PublishedBlogPost.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Blog.Core.Test.Fixture
{
    using Blog.Core.Entity;

    /// <summary>
    /// Represents a <see cref="BlogPost"/> that is well formed and in <see cref="BlogPostStatus.Published"/> status.
    /// </summary>
    internal class PublishedBlogPost
    {
        /// <summary>
        /// Initialize a new <see cref="BlogPost"/> that is a published.
        /// </summary>
        /// <returns>A published <see cref="BlogPost"/>.</returns>
        internal static BlogPost Create()
        {
            BlogPost blogPost = DraftBlogPost.Create();

            blogPost.Publish();

            return blogPost;
        }
    }
}