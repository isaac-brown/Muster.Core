// <copyright file="ConstantClockStub.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Blog.Core.Test.Fixture
{
    using NodaTime;

    /// <summary>
    /// <para>
    ///     Test Stub that parrots a <see cref="Instant"/> based on the milliseconds since epoch used in construction of the object.
    /// </para>
    /// <remark>
    ///     For construction see the <see cref="Create(long)"/> factory method.
    /// </remark>
    /// </summary>
    internal class ConstantClockStub : IClock
    {
        private readonly long milliseconds;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstantClockStub"/> class.
        /// </summary>
        /// <param name="milliseconds">The number of millseconds since epoch.</param>
        protected ConstantClockStub(long milliseconds)
        {
            this.milliseconds = milliseconds;
        }

        /// <summary>
        /// Factory method to create a new instance of <see cref="ConstantClockStub"/>.
        /// </summary>
        /// <param name="milliseconds">The number of milliseconds since epoch.</param>
        /// <returns>A new <see cref="ConstantClockStub"/> instance.</returns>
        public static IClock Create(long milliseconds)
        {
            return new ConstantClockStub(milliseconds);
        }

        /// <inheritdoc/>
        public Instant GetCurrentInstant()
        {
            return Instant.FromUnixTimeMilliseconds(this.milliseconds);
        }
    }
}
