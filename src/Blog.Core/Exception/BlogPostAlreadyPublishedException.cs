// <copyright file="BlogPostAlreadyPublishedException.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Blog.Core.Exception
{
    using System;
    using Blog.Core.Entity;

    /// <summary>
    /// An excpetion that indicates that a <see cref="BlogPost"/> which has already been published
    /// was attempted to be published again.
    /// </summary>
    [Serializable]
    public class BlogPostAlreadyPublishedException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostAlreadyPublishedException"/> class.
        /// </summary>
        public BlogPostAlreadyPublishedException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostAlreadyPublishedException"/> class with a specified error
        /// message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BlogPostAlreadyPublishedException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostAlreadyPublishedException"/> class with a specified error
        /// message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="inner">
        /// The exception that is the cause of the current exception, or a null reference
        /// (Nothing in Visual Basic) if no inner exception is specified.
        /// </param>
        public BlogPostAlreadyPublishedException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
