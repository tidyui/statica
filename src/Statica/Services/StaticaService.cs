/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

using System.Collections.Generic;
using Statica.Models;

namespace Statica.Services
{
    public class StaticaService : IStaticaService
    {
        // The available data structures
        private readonly Dictionary<string, IStructureService> _structures =
            new Dictionary<string, IStructureService>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="structures">The available structures</param>
        public StaticaService(params StaticStructure[] structures)
        {
            foreach (var structure in structures)
            {
                _structures[structure.Id] =
                    new StructureService(structure.BaseSlug, structure.DataPath);
            }
        }

        /// <summary>
        /// Gets the structure for the given slug.
        /// </summary>
        /// <param name="slug">The base slug</param>
        /// <returns>The structure</returns>
        public IStructureService GetStructure(string id)
        {
            if (_structures.TryGetValue(id, out var structure))
            {
                return structure;
            }
            return null;
        }
    }
}