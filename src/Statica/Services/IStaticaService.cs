/*
 * Copyright (c) 2019-2021 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Statica.Services
{
    public interface IStaticaService
    {
        /// <summary>
        /// Gets the structure for the given slug.
        /// </summary>
        /// <param name="slug">The base slug</param>
        /// <returns>The structure</returns>
        IStructureService GetStructure(string slug);

        /// <summary>
        /// Gets all of the available structures.
        /// </summary>
        /// <returns>A collection of structures</returns>
        IEnumerable<IStructureService> GetStructures();

        /// <summary>
        /// Reloads all of the structures available of
        /// the structure identitifed by the given id.
        /// </summary>
        /// <param name="id">The optional structure id</param>
        Task Reload(string id = null);
    }
}