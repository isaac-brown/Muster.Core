// <copyright file="ITagRepository.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Repositories
{
    using System;
    using Muster.Core.Entity;

    /// <summary>
    /// Repository for <see cref="Tag"/>s.
    /// </summary>
    public interface ITagRepository : IRepository<Guid, Tag>
    {
    }
}
