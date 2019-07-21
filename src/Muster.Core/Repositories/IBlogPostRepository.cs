// <copyright file="IBlogPostRepository.cs" company="Isaac Brown">
// Licensed under the MIT license. See LICENSE file in the project root for full license information.
// </copyright>

namespace Muster.Core.Repositories
{
  using Muster.Core.Entity;

  /// <summary>
  /// Repository for <see cref="BlogPost"/>s.
  /// </summary>
  public interface IBlogPostRepository : IRepository<string, BlogPost>, IAsyncRepository<string, BlogPost>
  {
  }
}
