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

namespace Statica.Models
{
    public class StaticSitemap
    {
        /// <summary>
        /// Gets/sets the available items.
        /// </summary>
        public IList<StaticPage> Items { get; set; } = new List<StaticPage>();

        /// <summary>
        /// Gets/sets the available routes.
        /// </summary>
        public IDictionary<string, StaticPage> Routes { get; set; } = new Dictionary<string, StaticPage>();
    }
}