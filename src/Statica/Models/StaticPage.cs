/*
 * Copyright (c) 2019 Håkan Edling
 *
 * This software may be modified and distributed under the terms
 * of the MIT license.  See the LICENSE file for details.
 *
 * http://github.com/tidyui/statica
 *
 */

using System;
using System.Collections.Generic;

namespace Statica.Models
{
    public class StaticPage
    {
        /// <summary>
        /// Gets/sets the navigation title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets/sets the slug.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets/sets the full path to the content.
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// Gets/sets the optional redirect.
        /// </summary>
        public string Redirect { get; set; }

        /// <summary>
        /// Gets the permalink to the page.
        /// </summary>
        public string Permalink
        {
            get { return "/" + (!string.IsNullOrWhiteSpace(Redirect) ? Redirect : Slug); }
        }

        /// <summary>
        /// Gets/sets the created date.
        /// </summary>
        public DateTime Created { get; set; }

        /// <summary>
        /// Gets/sets the last modification date.
        /// </summary>
        public DateTime LastModified { get; set; }

        /// <summary>
        /// Gets/sets the available subitems.
        /// </summary>
        public IList<StaticPage> Items { get; set; } = new List<StaticPage>();
    }
}