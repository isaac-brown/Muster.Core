// <copyright file="BlogPost.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Blog.Core.Entity
{
    using System;
    using System.Collections.Generic;
    using Blog.Core.Exception;
    using NodaTime;

    /// <summary>
    /// Represents a single blog post.
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost"/> class.
        /// </summary>
        /// <param name="content">The content of the post.</param>
        /// <param name="clock">The clock that will be used.</param>
        private BlogPost(string content, IClock clock)
        {
            if (clock == null)
            {
                throw new ArgumentNullException(nameof(clock));
            }

            this.Content = content;
            this.Created = clock.GetCurrentInstant();
            this.Status = BlogPostStatus.Draft;
            this.Id = Guid.NewGuid();
        }

        /// <summary>
        /// Gets the unique identifier for this <see cref="BlogPost"/>.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets the text content of the <see cref="BlogPost"/>.
        /// </summary>
        public string Content { get; private set; }

        /// <summary>
        /// Gets the instant that the <see cref="BlogPost"/> was created.
        /// </summary>
        public Instant Created { get; }

        /// <summary>
        /// Gets the <see cref="BlogPostStatus"/> for the <see cref="BlogPost"/>.
        /// </summary>
        public BlogPostStatus Status { get; private set; }

        /// <summary>
        /// Gets the list of <see cref="Tag"/>s associated with the <see cref="BlogPost"/>.
        /// </summary>
        public IList<Tag> Tags { get; } = new List<Tag>();

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPost"/> class.
        /// </summary>
        /// <param name="content">The content of the post.</param>
        /// <param name="clock">The clock that will be used.</param>
        /// <returns>A new instance of the <see cref="BlogPost"/> class.</returns>
        public static BlogPost Create(string content, IClock clock)
        {
            return new BlogPost(content, clock);
        }

        /// <summary>
        /// Publishes the <see cref="BlogPost"/>, marking it as being visible to viewers.
        /// </summary>
        public void Publish()
        {
            if (this.Status == BlogPostStatus.Published)
            {
                throw new BlogPostAlreadyPublishedException();
            }

            this.Status = BlogPostStatus.Published;
        }
    }
}