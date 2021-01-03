/*
 * Copyright (c) 2019-2021 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

using System.Threading.Tasks;
using Statica.Models;

namespace Statica.Services
{
    public interface IStructureService
    {
        /// <summary>
        /// Gets the unique structure id.
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Gets the optional title.
        /// </summary>
        string Title { get; }

        /// <summary>
        /// Gets the current sitemap.
        /// </summary>
        StaticSitemap Sitemap { get; }

        /// <summary>
        /// Gets the page with the given slug.
        /// </summary>
        /// <param name="slug">The slug</param>
        /// <returns>The page</returns>
        Task<StaticPageModel> GetPageAsync(string slug);
    }
}