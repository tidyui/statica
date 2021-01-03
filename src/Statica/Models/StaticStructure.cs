/*
 * Copyright (c) 2019-2021 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

namespace Statica.Models
{
    public class StaticStructure
    {
        /// <summary>
        /// Gets/sets the unique structure id.
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets/sets the optional title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets/sets the base slug.
        /// </summary>
        public string BaseSlug { get; set; }

        /// <summary>
        /// Gets/sets the data path for the structure.
        /// </summary>
        public string DataPath { get; set; }

        /// <summary>
        /// If assets should be used for the structure.
        /// </summary>
        public bool UseAssets { get; set; } = false;
    }
}