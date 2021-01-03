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
    }
}