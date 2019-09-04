/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

namespace Statica.Models
{
    public class StaticPageModel : StaticPage
    {
        /// <summary>
        /// Gets/sets the formatted HTML body.
        /// </summary>
        public string Body { get; set; }

        /// <summary>
        /// Gets/sets the raw markdown body.
        /// </summary>
        public string Markdown { get; set; }
    }
}